using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using bunnyWCF.Connection;
using bunnyWCF.Entities.Admin.Catalogs;
using bunnyWCF.Utils;
using bunnyWCF.Utils.Helper;
namespace bunnyWCF.Controllers
{
    public class DepartmentFactoryController
    {
        private readonly static DepartmentFactoryController instance=new DepartmentFactoryController();


        public static DepartmentFactoryController Instance
        {
            get { return instance; }
        }
        private DataSet result;
        private DepartmentFactoryServiceEntity departmentsFactory = new DepartmentFactoryServiceEntity();
        private List<DepartmentFactoryEntity> listDepartmentFactory = new List<DepartmentFactoryEntity>();
        private DepartmentFactoryEntity departmentFactory;
        private MessageHelper message;

        public DepartmentFactoryServiceEntity OnGetDepartmentsFactory()
        {
            listDepartmentFactory.Clear();
            try
            {
                string[,] parameters = { { "@p_id_department_factory", "1", "0" }, { "@p_department", "2", string.Empty }, { "@p_id_state", "1", "1" }, { "@p_option", "1", "2" }, { "@p_word_search", "2", string.Empty } };
                result = BDConnection.Instance.RunStoreProcedure("sp_maintenance_department_factory", parameters);
                if (result != null && result.Tables != null && result.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in result.Tables[0].Rows)
                    {
                        departmentFactory = new DepartmentFactoryEntity();
                        departmentFactory.Id = int.Parse(row.ItemArray[0].ToString());
                        departmentFactory.Value = row.ItemArray[1].ToString();
                        departmentFactory.IdState = int.Parse(row.ItemArray[2].ToString());
                        departmentFactory.State = row.ItemArray[3].ToString();
                        listDepartmentFactory.Add(departmentFactory);
                    }
                    departmentsFactory.ListDepartmentFactory = listDepartmentFactory;
                    departmentsFactory.Message = GlobalMessage.Instance.OK;
                }
            }
            catch (Exception ex)
            {
                departmentsFactory.ListDepartmentFactory = listDepartmentFactory;
                departmentsFactory.Message = GlobalMessage.Instance.ERROR;
                departmentsFactory.Message.Message = departmentsFactory.Message.Message + " al obtener el listado de departamentos";
            }

            return departmentsFactory;
        }
        public DepartmentFactoryServiceEntity OnGetDepartmentFactoryByWord(string WordSearch)
        {
            listDepartmentFactory.Clear();
            try
            {
                string[,] parameters = { { "@p_id_department_factory", "1", "0" }, { "@p_department", "2", string.Empty }, { "@p_id_state", "1", "1" }, { "@p_option", "1", "5" }, { "@p_word_search", "2", WordSearch } };
                result = BDConnection.Instance.RunStoreProcedure("sp_maintenance_department_factory", parameters);
                if (result != null && result.Tables != null && result.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in result.Tables[0].Rows)
                    {
                        departmentFactory = new DepartmentFactoryEntity();
                        departmentFactory.Id = int.Parse(row.ItemArray[0].ToString());
                        departmentFactory.Value = row.ItemArray[1].ToString();
                        departmentFactory.IdState = int.Parse(row.ItemArray[2].ToString());
                        departmentFactory.State = row.ItemArray[3].ToString();
                        listDepartmentFactory.Add(departmentFactory);
                    }
                    departmentsFactory.ListDepartmentFactory = listDepartmentFactory;
                    departmentsFactory.Message = GlobalMessage.Instance.OK;
                }
            }
            catch (Exception ex)
            {
                departmentsFactory.ListDepartmentFactory = listDepartmentFactory;
                departmentsFactory.Message = GlobalMessage.Instance.ERROR;
                departmentsFactory.Message.Message = departmentsFactory.Message.Message + " al obtener el listado de departamentos";
            }

            return departmentsFactory;
        }

        public DepartmentFactoryServiceEntity OnGetTypesClaimActives()
        {
            listDepartmentFactory.Clear();
            try
            {
                string[,] parameters = { { "@p_id_department_factory", "1", "0" }, { "@p_department", "2", string.Empty }, { "@p_id_state", "1", "1" }, { "@p_option", "1", "6" }, { "@p_word_search", "2", string.Empty} };
                result = BDConnection.Instance.RunStoreProcedure("sp_maintenance_department_factory", parameters);
                if (result != null && result.Tables != null && result.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in result.Tables[0].Rows)
                    {
                        departmentFactory = new DepartmentFactoryEntity();
                        departmentFactory.Id = int.Parse(row.ItemArray[0].ToString());
                        departmentFactory.Value = row.ItemArray[1].ToString();
                        departmentFactory.IdState = int.Parse(row.ItemArray[2].ToString());
                        departmentFactory.State = row.ItemArray[3].ToString();
                        listDepartmentFactory.Add(departmentFactory);
                    }
                    departmentsFactory.ListDepartmentFactory = listDepartmentFactory;
                    departmentsFactory.Message = GlobalMessage.Instance.OK;
                }
            }
            catch (Exception ex)
            {
                departmentsFactory.ListDepartmentFactory = listDepartmentFactory;
                departmentsFactory.Message = GlobalMessage.Instance.ERROR;
                departmentsFactory.Message.Message = departmentsFactory.Message.Message + " al obtener el listado de departamentos";
            }

            return departmentsFactory;
        }

        public MessageHelper OnSetDepartmentFactory(DepartmentFactoryEntity DepartmentFactory)
        {
            string msg = string.Empty;
            bool isUpdate = (DepartmentFactory.Id != 0);
            try
            {
                string[,] parameters = { { "@p_id_department_factory", "1", (isUpdate)?DepartmentFactory.Id.ToString():"0" }, { "@p_department", "2", DepartmentFactory.Value }, { "@p_id_state", "1", (isUpdate)?DepartmentFactory.IdState.ToString():"1" }, { "@p_option", "1", (isUpdate)?"3":"1" }, { "@p_word_search", "2", string.Empty } };
                result = BDConnection.Instance.RunStoreProcedure("sp_maintenance_department_factory", parameters);
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
                                    msg = (isUpdate) ? "del departamento que se desea actualizar" : " del departamento que desea ingresar";
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
                msg = (isUpdate) ? " de actualizar el departamento" : " de ingresar un nuevo departamento";
                message.Message = message.Message + msg;

            }

            return message;
        }
        public MessageHelper OnDeleteDepartmentFactory(int Id)
        {
            try
            {
                string[,] parameters = { { "@p_id_department_factory", "1", Id.ToString() }, { "@p_department", "2", string.Empty}, { "@p_id_state", "1", "1" }, { "@p_option", "1", "4" }, { "@p_word_search", "2", string.Empty } };
                result = BDConnection.Instance.RunStoreProcedure("sp_maintenance_department_factory", parameters);
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
                message.Message = message.Message + " al eliminar un departamento";

            }

            return message;
        }

    }
}