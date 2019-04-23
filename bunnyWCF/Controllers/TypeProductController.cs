using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using bunnyWCF.Entities.Admin.Catalogs;
using bunnyWCF.Connection;
using bunnyWCF.Utils;
using bunnyWCF.Utils.Helper;
using bunnyWCF.Connection;
namespace bunnyWCF.Controllers
{
    public class TypeProductController
    {
        private readonly static TypeProductController instance=new TypeProductController();

        public static TypeProductController Instance
        {
            get { return instance; }
        }

        private DataSet result;
        TypeProductServiceEntity typesProduct = new TypeProductServiceEntity();
        List<TypeProductEntity> listTypesProduct = new List<TypeProductEntity>();
        TypeProductEntity typeProduct;
        MessageHelper message = new MessageHelper();
        public TypeProductServiceEntity OnGetTypesProduct() 
        {
            listTypesProduct.Clear();
            try
            {
                string[,] parameters = { { "@p_id_type_product", "1", "0" }, { "@p_type_product", "2", string.Empty }, { "@p_description_type_product", "2", string.Empty }, { "@p_id_state", "1", "0" }, { "@p_option", "1", "2" }, { "@p_word_search", "2", string.Empty } };
                result = BDConnection.Instance.RunStoreProcedure("sp_maintenance_type_product", parameters);
                if(result!=null && result.Tables!=null && result.Tables[0].Rows.Count>0)
                {
                    foreach (DataRow row in result.Tables[0].Rows)
                    {
                        typeProduct = new TypeProductEntity();
                        typeProduct.Id = int.Parse(row.ItemArray[0].ToString());
                        typeProduct.Value = row.ItemArray[1].ToString();
                        typeProduct.Description = row.ItemArray[2].ToString();
                        typeProduct.IdState = int.Parse(row.ItemArray[3].ToString());
                        typeProduct.State = row.ItemArray[4].ToString();
                        listTypesProduct.Add(typeProduct);
                    }
                    typesProduct.ListProduct = listTypesProduct;
                    typesProduct.Message = GlobalMessage.Instance.OK;
                }
            }
            catch (Exception ex)
            {
                typesProduct.ListProduct = listTypesProduct;
                typesProduct.Message = GlobalMessage.Instance.ERROR;
                typesProduct.Message.Message = typesProduct.Message.Message + " al obtener el listado de los tipos de producto";
            }
            return typesProduct;
        }
        public TypeProductServiceEntity OnGetTypesProductByWord(string WordSearch)
        {
            listTypesProduct.Clear();
            try
            {
                string[,] parameters = { { "@p_id_type_product", "1", "0" }, { "@p_type_product", "2", string.Empty }, { "@p_description_type_product", "2", string.Empty }, { "@p_id_state", "1", "0" }, { "@p_option", "1", "5" }, { "@p_word_search", "2", WordSearch } };
                result = BDConnection.Instance.RunStoreProcedure("sp_maintenance_type_product", parameters);
                if (result != null && result.Tables != null && result.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in result.Tables[0].Rows)
                    {
                        typeProduct = new TypeProductEntity();
                        typeProduct.Id = int.Parse(row.ItemArray[0].ToString());
                        typeProduct.Value = row.ItemArray[1].ToString();
                        typeProduct.Description = row.ItemArray[2].ToString();
                        typeProduct.IdState = int.Parse(row.ItemArray[3].ToString());
                        typeProduct.State = row.ItemArray[4].ToString();
                        listTypesProduct.Add(typeProduct);
                    }
                    typesProduct.ListProduct = listTypesProduct;
                    typesProduct.Message = GlobalMessage.Instance.OK;
                }
            }
            catch (Exception ex)
            {
                typesProduct.ListProduct = listTypesProduct;
                typesProduct.Message = GlobalMessage.Instance.ERROR;
                typesProduct.Message.Message = typesProduct.Message.Message + " al obtener el listado de los tipos de producto";
            }
            return typesProduct;
        }
        public TypeProductServiceEntity OnGetTypesProductActives()
        {
            listTypesProduct.Clear();
            try
            {
                string[,] parameters = { { "@p_id_type_product", "1", "0" }, { "@p_type_product", "2", string.Empty }, { "@p_description_type_product", "2", string.Empty }, { "@p_id_state", "1", "0" }, { "@p_option", "1", "6" }, { "@p_word_search", "2", string.Empty } };
                result = BDConnection.Instance.RunStoreProcedure("sp_maintenance_type_product", parameters);
                if (result != null && result.Tables != null && result.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in result.Tables[0].Rows)
                    {
                        typeProduct = new TypeProductEntity();
                        typeProduct.Id = int.Parse(row.ItemArray[0].ToString());
                        typeProduct.Value = row.ItemArray[1].ToString();
                        typeProduct.Description = row.ItemArray[2].ToString();
                        typeProduct.IdState = int.Parse(row.ItemArray[3].ToString());
                        typeProduct.State = row.ItemArray[4].ToString();
                        listTypesProduct.Add(typeProduct);
                    }
                    typesProduct.ListProduct = listTypesProduct;
                    typesProduct.Message = GlobalMessage.Instance.OK;
                }
            }
            catch (Exception ex)
            {
                typesProduct.ListProduct = listTypesProduct;
                typesProduct.Message = GlobalMessage.Instance.ERROR;
                typesProduct.Message.Message = typesProduct.Message.Message + " al obtener el listado de los tipos de producto";
            }
            return typesProduct;
        }
        public MessageHelper OnSetTypeProduct(TypeProductEntity TypeProduct) 
        {
            string msg = string.Empty;
            bool isUpdate = (TypeProduct.Id != 0);
            try
            {
                string[,] parameters = { { "@p_id_type_product", "1", TypeProduct.Id.ToString() }, { "@p_type_product", "2", TypeProduct.Value }, { "@p_description_type_product", "2", TypeProduct.Description }, { "@p_id_state", "1", (isUpdate)?TypeProduct.IdState.ToString():"1"}, { "@p_option", "1", (isUpdate)?"3":"1"}, { "@p_word_search", "2", string.Empty } };
                result=BDConnection.Instance.RunStoreProcedure("sp_maintenance_type_product",parameters);
                if (result != null && result.Tables != null && result.Tables[0].Rows.Count > 0) 
                {
                    foreach (DataRow row in result.Tables[0].Rows)
                    {
                        switch(row.ItemArray[0].ToString())
                        {
                            case "200":
                                {
                                    message = GlobalMessage.Instance.OK;
                                    break;
                                }
                            case "201": 
                                {
                                    message = GlobalMessage.Instance.EXIST;
                                    msg = (isUpdate) ? " del tipo de producto que se desea actualizar" : " del tipo de producto que desea ingresar";
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
                msg = (isUpdate) ? " al actualizar el tipo de producto" : " al agregar el nuevo tipo de producto";
                message.Message = message.Message + msg;
            }


            return message;
        }

        public MessageHelper OnDeleteTypeProduct(int Id)
        {
            try
            {
                string[,] parameters = { { "@p_id_type_product", "1", Id.ToString() }, { "@p_type_product", "2", string.Empty }, { "@p_description_type_product", "2", string.Empty }, { "@p_id_state", "1", "2" }, { "@p_option", "1", "4" }, { "@p_word_search", "2", string.Empty } };
                result = BDConnection.Instance.RunStoreProcedure("sp_maintenance_type_product", parameters);
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
                message.Message = message.Message + " al eliminar el tipo de producto";
            }
            return message;
        }

    }
}