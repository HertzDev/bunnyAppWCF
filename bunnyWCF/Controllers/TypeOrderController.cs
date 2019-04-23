using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using bunnyWCF.Connection;
using bunnyWCF.Entities.Admin.Catalogs;
using bunnyWCF.Utils;
using bunnyWCF.Utils.Helper;
using System.Data;
namespace bunnyWCF.Controllers
{
    public class TypeOrderController
    {
        private readonly static TypeOrderController instance=new TypeOrderController();

        public static TypeOrderController Instance
        {
            get { return instance; }
        }
        private DataSet result;
        private TypeOrderServiceEntity typesOrder = new TypeOrderServiceEntity();
        private List<TypeOrderEntity> listTypeOrder = new List<TypeOrderEntity>();
        private TypeOrderEntity typeOrder;
        private MessageHelper message = new MessageHelper();

        public TypeOrderServiceEntity OnGetTypesOrder() 
        {
            listTypeOrder.Clear();
            try
            {
                string[,] parameters = { { "@p_id_type_order", "1", "0" }, { "@p_type_order", "2", string.Empty }, { "@p_id_state", "1", "1" }, { "@p_option", "1", "2" }, { "@p_word_search", "2", string.Empty } };
                result = BDConnection.Instance.RunStoreProcedure("sp_maintenance_type_order", parameters);
                if (result != null && result.Tables != null && result.Tables[0].Rows.Count > 0) 
                {
                    foreach (DataRow row in result.Tables[0].Rows) 
                    {
                        typeOrder = new TypeOrderEntity();
                        typeOrder.Id = int.Parse(row.ItemArray[0].ToString());
                        typeOrder.Value = row.ItemArray[1].ToString();
                        typeOrder.IdState = int.Parse(row.ItemArray[2].ToString());
                        typeOrder.State = row.ItemArray[3].ToString();
                        listTypeOrder.Add(typeOrder);
                    }
                    typesOrder.ListTypeOrder = listTypeOrder;
                    typesOrder.Message = GlobalMessage.Instance.OK;
                }
            }
            catch (Exception ex)
            {
                typesOrder.ListTypeOrder = listTypeOrder;
                typesOrder.Message = GlobalMessage.Instance.ERROR;
                typesOrder.Message.Message = typesOrder.Message.Message + " al obtener el listado de los tipos de pedido";
            }

            return typesOrder;
        }
        public TypeOrderServiceEntity OnGetTypesOrderByWord(string WordSearch)
        {
            listTypeOrder.Clear();
            try
            {
                string[,] parameters = { { "@p_id_type_order", "1", "0" }, { "@p_type_order", "2", string.Empty }, { "@p_id_state", "1", "1" }, { "@p_option", "1", "5" }, { "@p_word_search", "2", WordSearch } };
                result = BDConnection.Instance.RunStoreProcedure("sp_maintenance_type_order", parameters);
                if (result != null && result.Tables != null && result.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in result.Tables[0].Rows)
                    {
                        typeOrder = new TypeOrderEntity();
                        typeOrder.Id = int.Parse(row.ItemArray[0].ToString());
                        typeOrder.Value = row.ItemArray[1].ToString();
                        typeOrder.IdState = int.Parse(row.ItemArray[2].ToString());
                        typeOrder.State = row.ItemArray[3].ToString();
                        listTypeOrder.Add(typeOrder);
                    }
                    typesOrder.ListTypeOrder = listTypeOrder;
                    typesOrder.Message = GlobalMessage.Instance.OK;
                }
            }
            catch (Exception ex)
            {
                typesOrder.ListTypeOrder = listTypeOrder;
                typesOrder.Message = GlobalMessage.Instance.ERROR;
                typesOrder.Message.Message = typesOrder.Message.Message + " al obtener el listado de los tipos de pedido";
            }

            return typesOrder;
        }
        public TypeOrderServiceEntity OnGetTypesOrderActive()
        {
            listTypeOrder.Clear();
            try
            {
                string[,] parameters = { { "@p_id_type_order", "1", "0" }, { "@p_type_order", "2", string.Empty }, { "@p_id_state", "1", "1" }, { "@p_option", "1", "6" }, { "@p_word_search", "2", string.Empty} };
                result = BDConnection.Instance.RunStoreProcedure("sp_maintenance_type_order", parameters);
                if (result != null && result.Tables != null && result.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in result.Tables[0].Rows)
                    {
                        typeOrder = new TypeOrderEntity();
                        typeOrder.Id = int.Parse(row.ItemArray[0].ToString());
                        typeOrder.Value = row.ItemArray[1].ToString();
                        typeOrder.IdState = int.Parse(row.ItemArray[2].ToString());
                        typeOrder.State = row.ItemArray[3].ToString();
                        listTypeOrder.Add(typeOrder);
                    }
                    typesOrder.ListTypeOrder = listTypeOrder;
                    typesOrder.Message = GlobalMessage.Instance.OK;
                }
            }
            catch (Exception ex)
            {
                typesOrder.ListTypeOrder = listTypeOrder;
                typesOrder.Message = GlobalMessage.Instance.ERROR;
                typesOrder.Message.Message = typesOrder.Message.Message + " al obtener el listado de los tipos de pedido";
            }

            return typesOrder;
        }
        public MessageHelper OnSetTypeOrder(TypeOrderEntity TypeOrder) 
        {
            string msg = string.Empty;
            bool isUpdate = (TypeOrder.Id != 0);
            try
            {
                string[,] parameters = { { "@p_id_type_order", "1", TypeOrder.Id.ToString()}, { "@p_type_order", "2", TypeOrder.Value.ToString() }, { "@p_id_state", "1", (isUpdate)?TypeOrder.IdState.ToString():"1" }, { "@p_option", "1", (isUpdate)?"3":"1" }, { "@p_word_search", "2", string.Empty} };
                result = BDConnection.Instance.RunStoreProcedure("sp_maintenance_type_order", parameters);
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
                            case "201":
                                {
                                    message = GlobalMessage.Instance.EXIST;
                                    msg = (isUpdate) ? "del tipo de pedido que se desea actualizar" : " del tipo de pedido que desea ingresar";
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
                msg = (isUpdate) ? " de actualizar el tipo de pedido" : " de ingresar un nuevo tipo de pedido";
                message.Message = message.Message + msg;
          
            }

            return message;
        }
        public MessageHelper OnDeleteTypeOrder(int Id)
        {
            try
            {
                string[,] parameters = { { "@p_id_type_order", "1",Id.ToString()}, { "@p_type_order", "2", string.Empty }, { "@p_id_state", "1", "1" }, { "@p_option", "1", "4" }, { "@p_word_search", "2", string.Empty } };
                result = BDConnection.Instance.RunStoreProcedure("sp_maintenance_type_order", parameters);
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
                message.Message = message.Message + " al eliminar un tipo de pedido";

            }

            return message;
        }
    }
}