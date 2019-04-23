using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using bunnyWCF.Connection;
using bunnyWCF.Entities.Admin.Catalogs;
using bunnyWCF.Utils.Helper;
using bunnyWCF.Utils;
using System.Data;
namespace bunnyWCF.Controllers
{
    public class TypeEmployeeController
    {
        private readonly static TypeEmployeeController instance;
        public static TypeEmployeeController Instance
        {
            get { return instance; }
        }
        private DataSet result;
        private TypeEmployeeServiceEntity typesEmployee = new TypeEmployeeServiceEntity();
        private List<TypeEmployeeEntity> listTypeEmployee = new List<TypeEmployeeEntity>();
        private TypeEmployeeEntity typeEmployee;
        private MessageHelper message;

        public TypeEmployeeServiceEntity OnGetTypesEmployee()
        {
            listTypeEmployee.Clear();
            try
            {
                string[,] parameters = { { "@p_id_type_employee", "1", "0" }, { "@p_type_employee", "2", string.Empty }, { "@p_id_state", "1", "1" }, { "@p_option", "1", "2" }, { "@p_word_search", "2", string.Empty } };
                result = BDConnection.Instance.RunStoreProcedure("sp_maintenance_type_employee", parameters);
                if (result != null && result.Tables != null && result.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in result.Tables[0].Rows)
                    {
                        typeEmployee = new TypeEmployeeEntity();
                        typeEmployee.Id = int.Parse(row.ItemArray[0].ToString());
                        typeEmployee.Value = row.ItemArray[1].ToString();
                        typeEmployee.IdState = int.Parse(row.ItemArray[2].ToString());
                        typeEmployee.State = row.ItemArray[3].ToString();
                        listTypeEmployee.Add(typeEmployee);
                    }
                    typesEmployee.ListTypeEmployee = listTypeEmployee;
                    typesEmployee.Message = GlobalMessage.Instance.OK;
                }
            }
            catch (Exception ex)
            {
                typesEmployee.ListTypeEmployee = listTypeEmployee;
                typesEmployee.Message = GlobalMessage.Instance.ERROR;
                typesEmployee.Message.Message = typesEmployee.Message.Message + " al obtener el listado de los tipos de pedido";
            }

            return typesEmployee;
        }
        public TypeEmployeeServiceEntity OnGetTypesEmployeeByWord(string WordSearch)
        {
            listTypeEmployee.Clear();
            try
            {
                string[,] parameters = { { "@p_id_type_employee", "1", "0" }, { "@p_type_employee", "2", string.Empty }, { "@p_id_state", "1", "1" }, { "@p_option", "1", "5" }, { "@p_word_search", "2", WordSearch } };
                result = BDConnection.Instance.RunStoreProcedure("sp_maintenance_type_employee", parameters);
                if (result != null && result.Tables != null && result.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in result.Tables[0].Rows)
                    {
                        typeEmployee = new TypeEmployeeEntity();
                        typeEmployee.Id = int.Parse(row.ItemArray[0].ToString());
                        typeEmployee.Value = row.ItemArray[1].ToString();
                        typeEmployee.IdState = int.Parse(row.ItemArray[2].ToString());
                        typeEmployee.State = row.ItemArray[3].ToString();
                        listTypeEmployee.Add(typeEmployee);
                    }
                    typesEmployee.ListTypeEmployee = listTypeEmployee;
                    typesEmployee.Message = GlobalMessage.Instance.OK;
                }
            }
            catch (Exception ex)
            {
                typesEmployee.ListTypeEmployee = listTypeEmployee;
                typesEmployee.Message = GlobalMessage.Instance.ERROR;
                typesEmployee.Message.Message = typesEmployee.Message.Message + " al obtener el listado de los tipos de pedido";
            }

            return typesEmployee;
        }
        
        public TypeEmployeeServiceEntity OnGetTypesEmployeeActives()
        {
            listTypeEmployee.Clear();
            try
            {
                string[,] parameters = { { "@p_id_type_employee", "1", "0" }, { "@p_type_employee", "2", string.Empty }, { "@p_id_state", "1", "1" }, { "@p_option", "1", "6" }, { "@p_word_search", "2", string.Empty } };
                result = BDConnection.Instance.RunStoreProcedure("sp_maintenance_type_employee", parameters);
                if (result != null && result.Tables != null && result.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in result.Tables[0].Rows)
                    {
                        typeEmployee = new TypeEmployeeEntity();
                        typeEmployee.Id = int.Parse(row.ItemArray[0].ToString());
                        typeEmployee.Value = row.ItemArray[1].ToString();
                        typeEmployee.IdState = int.Parse(row.ItemArray[2].ToString());
                        typeEmployee.State = row.ItemArray[3].ToString();
                        listTypeEmployee.Add(typeEmployee);
                    }
                    typesEmployee.ListTypeEmployee = listTypeEmployee;
                    typesEmployee.Message = GlobalMessage.Instance.OK;
                }
            }
            catch (Exception ex)
            {
                typesEmployee.ListTypeEmployee = listTypeEmployee;
                typesEmployee.Message = GlobalMessage.Instance.ERROR;
                typesEmployee.Message.Message = typesEmployee.Message.Message + " al obtener el listado de los tipos de pedido";
            }
            return typesEmployee;
        }
       
        public MessageHelper OnSetTypeEmployee(TypeEmployeeEntity TypeEmployee)
        {
            string msg = string.Empty;
            bool isUpdate = (TypeEmployee.Id != 0);
            try
            {
                string[,] parameters = { { "@p_id_type_employee", "1",(isUpdate)?TypeEmployee.Id.ToString():"0" }, { "@p_type_employee", "2", TypeEmployee.Value }, { "@p_id_state", "1", (isUpdate)?TypeEmployee.IdState.ToString():"1" }, { "@p_option", "1", (isUpdate)?"3":"1" }, { "@p_word_search", "2", string.Empty } };
                result = BDConnection.Instance.RunStoreProcedure("sp_maintenance_type_employee", parameters);
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
                                    msg = (isUpdate) ? "del tipo de empleado que se desea actualizar" : " del tipo de empleado que desea ingresar";
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
                msg = (isUpdate) ? " de actualizar el tipo de empleado" : " de ingresar un nuevo tipo de empleado";
                message.Message = message.Message + msg;

            }

            return message;
        }
        public MessageHelper OnDeleteTypeEmployee(int Id)
        {
            try
            {
                string[,] parameters = { { "@p_id_type_employee", "1", Id.ToString() }, { "@p_type_employee", "2", string.Empty }, { "@p_id_state", "1", "1" }, { "@p_option", "1", "4" }, { "@p_word_search", "2",string.Empty } };
                result = BDConnection.Instance.RunStoreProcedure("sp_maintenance_type_employee", parameters);
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
                message.Message = message.Message + " al eliminar un tipo de empleado";

            }

            return message;
        }
    }
}