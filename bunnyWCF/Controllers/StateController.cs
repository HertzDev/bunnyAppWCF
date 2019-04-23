using bunnyWCF.Connection;
using bunnyWCF.Entities.Admin.Catalogs;
using bunnyWCF.Utils;
using bunnyWCF.Utils.Helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace bunnyWCF.Controllers
{
    public class StateController
    {
        private readonly static StateController instance=new StateController();

        public static StateController Instance
        {
            get { return instance; }
        }

        private DataSet result;


        public StateServiceEntity OnGetStates() 
        {
            StateServiceEntity states = new StateServiceEntity();
            List<StateEntity> listState = new List<StateEntity>();
            StateEntity state; 
            try
            {
                string[,] parameters = { { "@p_id_state", "1", "0" }, { "@p_state","2",string.Empty},{"@p_option","1","2"},{"@p_word_search","2",string.Empty}};
                result = BDConnection.Instance.RunStoreProcedure("sp_maintenance_state", parameters);

                if (result != null && result.Tables !=null && result.Tables[0].Rows.Count>0) 
                {
                    foreach (DataRow row in result.Tables[0].Rows) 
                    {
                        state = new StateEntity();
                        state.Id = int.Parse(row.ItemArray[0].ToString());
                        state.Value = row.ItemArray[1].ToString();
                        listState.Add(state);
                    }
                    states.ListState = listState;
                    states.Message = GlobalMessage.Instance.OK;
                }
            }
            catch (Exception ex)
            {
                states.ListState = listState;
                states.Message = GlobalMessage.Instance.ERROR;
                states.Message.Message= states.Message.Message+" para obtener los estados";
            }
            return states;
        }

        public StateServiceEntity OnGetStatesByWord(string wordSearch)
        {
            StateServiceEntity states = new StateServiceEntity();
            List<StateEntity> listState = new List<StateEntity>();
            StateEntity state;
            try
            {
                string[,] parameters = { { "@p_id_state", "1", "0" }, { "@p_state", "2", string.Empty }, { "@p_option", "1", "5" },{"@p_word_search","2",wordSearch} };
                result = BDConnection.Instance.RunStoreProcedure("sp_maintenance_state", parameters);

                if (result != null && result.Tables != null && result.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in result.Tables[0].Rows)
                    {
                        state = new StateEntity();
                        state.Id = int.Parse(row.ItemArray[0].ToString());
                        state.Value = row.ItemArray[1].ToString();
                        listState.Add(state);
                    }
                    states.ListState = listState;
                    states.Message = GlobalMessage.Instance.OK;
                }
            }
            catch (Exception ex)
            {
                states.ListState = listState;
                states.Message = GlobalMessage.Instance.ERROR;
                states.Message.Message = states.Message.Message + " para obtener los estados";
            }
            return states;
        }

        public MessageHelper OnSetState(StateEntity state)
        {
            MessageHelper message = new MessageHelper();
            bool isUpdate = (state.Id != 0);
            string msg = string.Empty;
            try
            {
                string[,] parameters = { { "@p_id_state", "1", state.Id.ToString() }, { "@p_state", "2", state.Value }, { "@p_option", "1", isUpdate ? "3" : "1" }, { "@p_word_search", "2", string.Empty } };
                result = BDConnection.Instance.RunStoreProcedure("sp_maintenance_state", parameters);

                if (result!=null && result.Tables!=null && result.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in result.Tables[0].Rows)
                    {
                        switch (row.ItemArray[0].ToString())
                        {
                            case "200":
                                {
                                    message = GlobalMessage.Instance.OK;
                                    break;
                                }

                            case "401":
                                {
                                    message = GlobalMessage.Instance.EXIST;
                                    msg = (isUpdate) ? "del estado que se desea actualizar" : " del estado que desea ingresar";
                                    message.Message = message.Message + " " + msg;
                                    break;
                                }
                            default:
                                {
                                    message = GlobalMessage.Instance.ERROR;
                                    message.Message = row.ItemArray[1].ToString();
                                    break;

                                }

                        }

                    }
                }
            }
            catch (Exception ex)
            {
                message = GlobalMessage.Instance.ERROR;
                msg = (isUpdate) ? " de actualizar el material" : " de ingresar un nuevo material";
                message.Message = message.Message + msg;
            }

            return message;
        }


        public MessageHelper OnDeleteState(int Id)
        {
            MessageHelper message = new MessageHelper();
            try
            {
                string[,] parameters = { { "@p_id_state", "1", Id.ToString() }, { "@p_state", "2", string.Empty }, { "@p_option", "1", "4" }, { "@p_word_search", "2", string.Empty } };
                result = BDConnection.Instance.RunStoreProcedure("sp_maintenance_state", parameters);

                if (result!=null && result.Tables!=null && result.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in result.Tables[0].Rows)
                    {
                        switch (row.ItemArray[0].ToString())
                        {
                            case "200":
                                {
                                    message = GlobalMessage.Instance.OK;
                                    break;
                                }

                            case "401":
                                {
                                    message = GlobalMessage.Instance.EXIST;
                                    message.Message = message.Message + " del estado que desea eliminar";
                                    break;
                                }
                            default:
                                {
                                    message = GlobalMessage.Instance.ERROR;
                                    message.Message = row.ItemArray[1].ToString();
                                    break;

                                }

                        }

                    }
                }
            }
            catch (Exception ex)
            {
                message = GlobalMessage.Instance.ERROR;
                message.Message = message.Message + " de eliminar el estado";
            }

            return message;
        }

    }
}