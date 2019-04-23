using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using bunnyWCF.Entities.Admin.Catalogs;
using System.Data;
using bunnyWCF.Connection;
using bunnyWCF.Utils;
using bunnyWCF.Utils.Helper;
namespace bunnyWCF.Controllers
{
    public class TypeUserController
    {
        private readonly static TypeUserController instance=new TypeUserController();

        public static TypeUserController Instance
        {
            get { return instance; }
        }

        private DataSet result;
        private TypeUserServiceEntity typesUser = new TypeUserServiceEntity();
        private List<TypeUserEntity> listTypeUser = new List<TypeUserEntity>();
        private TypeUserEntity typeUser;
        private MessageHelper message = new MessageHelper();
        
        public TypeUserServiceEntity OnGetTypesUser() 
        {
            listTypeUser.Clear();
            try
            {
                string[,] parameters = { { "@p_id_type_user", "1", "0" }, { "@p_type_user", "2", string.Empty }, { "@p_id_state", "1", "0" }, { "@p_option", "1", "2" }, { "@p_word_search", "2", string.Empty } };
                result = BDConnection.Instance.RunStoreProcedure("sp_maintenance_type_user",parameters);
                if (result != null && result.Tables != null && result.Tables[0].Rows.Count > 0) 
                {
                    foreach(DataRow row in result.Tables[0].Rows)
                    {
                        typeUser = new TypeUserEntity();
                        typeUser.Id = int.Parse(row.ItemArray[0].ToString());
                        typeUser.Value = row.ItemArray[1].ToString();
                        typeUser.IdState = int.Parse(row.ItemArray[2].ToString());
                        typeUser.State = row.ItemArray[3].ToString();
                        listTypeUser.Add(typeUser);
                    }
                    typesUser.ListTypeUser = listTypeUser;
                    typesUser.Message = GlobalMessage.Instance.OK;
                }
            }
            catch (Exception ex)
            {
                typesUser.ListTypeUser = listTypeUser;
                typesUser.Message = GlobalMessage.Instance.ERROR;
                typesUser.Message.Message = typesUser.Message.Message + " al obtener los tipos de usuario";
            }
            return typesUser;
        }
        public TypeUserServiceEntity OnGetTypesUserByWord(string WordSearch)
        {
            listTypeUser.Clear();
            try
            {
                string[,] parameters = { { "@p_id_type_user", "1", "0" }, { "@p_type_user", "2", string.Empty }, { "@p_id_state", "1", "0" }, { "@p_option", "1", "6" }, { "@p_word_search", "2", WordSearch } };
                result = BDConnection.Instance.RunStoreProcedure("sp_maintenance_type_user", parameters);
                if (result != null && result.Tables != null && result.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in result.Tables[0].Rows)
                    {
                        typeUser = new TypeUserEntity();
                        typeUser.Id = int.Parse(row.ItemArray[0].ToString());
                        typeUser.Value = row.ItemArray[1].ToString();
                        typeUser.IdState = int.Parse(row.ItemArray[2].ToString());
                        typeUser.State = row.ItemArray[3].ToString();
                        listTypeUser.Add(typeUser);
                    }
                    typesUser.ListTypeUser = listTypeUser;
                    typesUser.Message = GlobalMessage.Instance.OK;
                }
            }
            catch (Exception ex)
            {
                typesUser.ListTypeUser = listTypeUser;
                typesUser.Message = GlobalMessage.Instance.ERROR;
                typesUser.Message.Message = typesUser.Message.Message + " al obtener los tipos de usuario";
            }
            return typesUser;
        }
        public TypeUserServiceEntity OnGetTypesUserActives()
        {
            listTypeUser.Clear();
            try
            {
                string[,] parameters = { { "@p_id_type_user", "1", "0" }, { "@p_type_user", "2", string.Empty }, { "@p_id_state", "1", "0" }, { "@p_option", "1", "6" }, { "@p_word_search", "2", string.Empty } };
                result = BDConnection.Instance.RunStoreProcedure("sp_maintenance_type_user", parameters);
                if (result != null && result.Tables != null && result.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in result.Tables[0].Rows)
                    {
                        typeUser = new TypeUserEntity();
                        typeUser.Id = int.Parse(row.ItemArray[0].ToString());
                        typeUser.Value = row.ItemArray[1].ToString();
                        typeUser.IdState = int.Parse(row.ItemArray[2].ToString());
                        typeUser.State = row.ItemArray[3].ToString();
                        listTypeUser.Add(typeUser);
                    }
                    typesUser.ListTypeUser = listTypeUser;
                    typesUser.Message = GlobalMessage.Instance.OK;
                }
            }
            catch (Exception ex)
            {
                typesUser.ListTypeUser = listTypeUser;
                typesUser.Message = GlobalMessage.Instance.ERROR;
                typesUser.Message.Message = typesUser.Message.Message + " al obtener los tipos de usuario";
            }
            return typesUser;
        }
        public MessageHelper OnSetTypeUser(TypeUserEntity TypeUser) 
        {
            string msg = string.Empty;
            bool isUpdate = (TypeUser.Id != 0);
            try
            {
                string[,] parameters = { { "@p_id_type_user", "1", TypeUser.Id.ToString() }, { "@p_type_user", "2", TypeUser.Value }, { "@p_id_state", "1", (isUpdate)?TypeUser.IdState.ToString():"1" }, { "@p_option", "1", (isUpdate)?"3":"1" }, { "@p_word_search", "2", string.Empty } };
                result = BDConnection.Instance.RunStoreProcedure("sp_maintenance_type_user", parameters);
                if (result != null && result.Tables != null && result.Tables[0].Rows.Count > 0) 
                {
                    foreach(DataRow row in result.Tables[0].Rows)
                    {
                        switch (row.ItemArray[0].ToString())
                        {
                            case "200":
                                {
                                    message = GlobalMessage.Instance.OK;
                                    break;
                                }

                            case "201":
                                {
                                    message = GlobalMessage.Instance.EXIST;
                                    msg = (isUpdate) ? " del tipo de usuario que se desea actualizar" : " del tipo de usuario que desea ingresar";
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
                msg = (isUpdate) ? " de actualizar el tipo de usuario" : " de ingresar un nuevo tipo de usuario";
                message.Message = message.Message + msg;
            }
            return message;
        }
        public MessageHelper OnDeleteTypeUser(int Id)
        {
            try
            {
                string[,] parameters = { { "@p_id_type_user", "1", Id.ToString() }, { "@p_type_user", "2", string.Empty }, { "@p_id_state", "1", "0" }, { "@p_option", "1", "4" }, { "@p_word_search", "2", string.Empty } };
                result = BDConnection.Instance.RunStoreProcedure("sp_maintenance_type_user", parameters);
                if (result != null && result.Tables != null && result.Tables[0].Rows.Count > 0)
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
                message.Message = message.Message + " al eliminar un tipo de usuario";
            }
            return message;
        }
    }
}