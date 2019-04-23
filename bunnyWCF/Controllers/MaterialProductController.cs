using bunnyWCF.Connection;
using bunnyWCF.Entities.Admin.Catalogs;
using bunnyWCF.Entities.General;
using bunnyWCF.Utils;
using bunnyWCF.Utils.Helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace bunnyWCF.Controllers
{
    public class MaterialProductController
    {
        private readonly static MaterialProductController instance=new MaterialProductController();
        public static MaterialProductController Instance{
            get{return instance;}
        }
        
        DataSet result;
        
        public MaterialProductServiceEntity OnGetMaterialsProduct()
        {
            MaterialProductServiceEntity material = new MaterialProductServiceEntity();
            List<MaterialProductEntity> items = new List<MaterialProductEntity>();
            try
            {
                string[,] parameters = { { "@p_id_material_product", "1", "0" }, { "@p_material_product", "2", string.Empty }, { "@p_id_state", "1", "1" }, { "@p_option", "1", "2" }, { "@p_word_search", "2", string.Empty }};
                result = BDConnection.Instance.RunStoreProcedure("sp_maintenance_material_product", parameters);
                MaterialProductEntity item;

                if (result.Tables!=null && result.Tables[0].Rows.Count > 0) 
                {
                    foreach (DataRow row in result.Tables[0].Rows) 
                    {
                        item = new MaterialProductEntity();
                        item.Id = int.Parse(row.ItemArray[0].ToString());
                        item.Value = row.ItemArray[1].ToString();
                        item.IdState = int.Parse(row.ItemArray[2].ToString());
                        item.State = row.ItemArray[3].ToString();
                        items.Add(item);
                    }
                }
                material.MaterialProductList = items;
                material.Message = GlobalMessage.Instance.OK;
            }
            catch (Exception ex)
            {

                material.Message = GlobalMessage.Instance.ERROR;
                material.Message.Message = material.Message.Message + " para obtener los materiales";
            }
            return material;
        }
        public MaterialProductServiceEntity OnGetMaterialsProductByWord(string WordSearch)
        {
            MaterialProductServiceEntity material = new MaterialProductServiceEntity();
            List<MaterialProductEntity> items = new List<MaterialProductEntity>();
            try
            {
                 
                string[,] parameters = { { "@p_id_material_product", "1", "0" }, { "@p_material_product", "2", string.Empty }, { "@p_id_state", "1", "1" }, { "@p_option", "1", (WordSearch.Equals("0"))?"6":"5"}, { "@p_word_search", "2", WordSearch.Equals("0")?string.Empty:WordSearch} };
                
                result = BDConnection.Instance.RunStoreProcedure("sp_maintenance_material_product", parameters);
                MaterialProductEntity item;

                if (result.Tables != null && result.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in result.Tables[0].Rows)
                    {
                        item = new MaterialProductEntity();
                        item.Id = int.Parse(row.ItemArray[0].ToString());
                        item.Value = row.ItemArray[1].ToString();
                        item.IdState = int.Parse(row.ItemArray[2].ToString());
                        item.State = row.ItemArray[3].ToString();
                        items.Add(item);
                    }
                }
                material.MaterialProductList = items;
                material.Message = GlobalMessage.Instance.OK;
            }
            catch (Exception ex)
            {

                material.Message = GlobalMessage.Instance.ERROR;
                material.Message.Message = material.Message.Message + " para obtener los materiales";
            }
            return material;
        }
        public MessageHelper OnSetMaterialProduct(MaterialProductEntity material) 
        {
            MessageHelper message=new MessageHelper();
            bool isUpdate = (material.Id != 0);
            string msg = string.Empty;
               
            try
            {
               string[,] parameters = { { "@p_id_material_product", "1", material.Id.ToString() }, { "@p_material_product", "2", material.Value }, { "@p_id_state", "1", isUpdate?material.IdState.ToString():"1"}, { "@p_option", "1", isUpdate?"3":"1"}, { "@p_word_search", "2", string.Empty }};
                 result = BDConnection.Instance.RunStoreProcedure("sp_maintenance_material_product", parameters);

                if (result.Tables[0].Rows.Count > 0) 
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
                                    msg = (isUpdate) ? "del material que se desea actualizar" : " del material que desea ingresar";
                                    message.Message = message.Message +" "+msg;
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
        public MessageHelper OnDeleteMaterialProduct(int Id)
        {
            MessageHelper message = new MessageHelper();
            try
            {
                string[,] parameters = { { "@p_id_material_product", "1", Id.ToString() }, { "@p_material_product", "2", string.Empty }, { "@p_id_state", "1", "2" }, { "@p_option", "1", "4" }, { "@p_word_search", "2", string.Empty } };
                result = BDConnection.Instance.RunStoreProcedure("sp_maintenance_material_product", parameters);

                if (result.Tables[0].Rows.Count > 0)
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
                message.Message = message.Message + " de eliminar el material";
            }

            return message;
        }

    }
}