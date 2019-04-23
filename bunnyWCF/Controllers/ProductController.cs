using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using bunnyWCF.Connection;
using bunnyWCF.Entities.Admin;
using bunnyWCF.Utils.Helper;
using bunnyWCF.Utils;
namespace bunnyWCF.Controllers
{
    public class ProductController
    {
        private readonly static ProductController instance;

        public static ProductController Instace
        {
            get { return instance; }
        }

        private DataSet result;
        private ProductServiceEntity products = new ProductServiceEntity();
        private List<ProductEntity> listProduct = new List<ProductEntity>();
        private ProductEntity product;
        private MessageHelper message;

        public ProductServiceEntity OnGetProducts()
        {
            listProduct.Clear();
            try
            {
                string[,] parameters = { { "@p_id_product", "1", "0" }, { "@p_cod_product", "2", string.Empty }, { "@p_name_product", "2", string.Empty }, { "@p_description_product", "2", string.Empty }, { "@p_price_unit", "6", "0.00" }, { "@p_cost_unit", "6", "0.00" }, { "@p_id_type_product", "1", "1" }, { "@p_id_state", "1", "1" }, { "@p_image_product", "2", string.Empty }, { "@p_points_product", "1", "0" }, { "@p_id_material_product", "1", "0" }, { "@p_option", "1", "2" }, { "@p_word_search", "2", string.Empty } };
                result = BDConnection.Instance.RunStoreProcedure("sp_maintenance_product", parameters);
                if (result != null && result.Tables != null && result.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in result.Tables[0].Rows)
                    {
                        product = new ProductEntity();
                        product.Id = int.Parse(row.ItemArray[0].ToString());
                        product.Code = row.ItemArray[1].ToString();
                        product.Name = row.ItemArray[2].ToString();
                        product.Description = row.ItemArray[3].ToString();
                        product.PriceUnit =double.Parse(row.ItemArray[4].ToString());
                        product.CostUnit = double.Parse(row.ItemArray[5].ToString());
                        product.IdTypeProduct = int.Parse(row.ItemArray[6].ToString());
                        product.IdState = int.Parse(row.ItemArray[7].ToString());
                        product.Image = row.ItemArray[8].ToString();
                        product.Points = int.Parse(row.ItemArray[9].ToString());
                        product.IdMaterial = int.Parse(row.ItemArray[10].ToString());
                        product.TypeProduct = row.ItemArray[11].ToString();
                        product.State = row.ItemArray[12].ToString();
                        product.Material = row.ItemArray[13].ToString();
                        listProduct.Add(product);
                    }
                    products.ListProduct = listProduct;
                    products.Message = GlobalMessage.Instance.OK;
                }
            }
            catch (Exception ex)
            {
                products.ListProduct = listProduct;
                products.Message = GlobalMessage.Instance.ERROR;
                products.Message.Message = products.Message.Message + " al obtener el listado de productos";
            }
            return products;
        }

        public ProductServiceEntity OnGetProductsByWord(string WordSearch)
        {
            listProduct.Clear();
            try
            {
                string[,] parameters = { { "@p_id_product", "1", "0" }, { "@p_cod_product", "2", string.Empty }, { "@p_name_product", "2", string.Empty }, { "@p_description_product", "2", string.Empty }, { "@p_price_unit", "6", "0.00" }, { "@p_cost_unit", "6", "0.00" }, { "@p_id_type_product", "1", "1" }, { "@p_id_state", "1", "1" }, { "@p_image_product", "2", string.Empty }, { "@p_points_product", "1", "0" }, { "@p_id_material_product", "1", "0" }, { "@p_option", "1", "2" }, { "@p_word_search", "2", WordSearch } };
                result = BDConnection.Instance.RunStoreProcedure("sp_maintenance_product", parameters);
                if (result != null && result.Tables != null && result.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in result.Tables[0].Rows)
                    {
                        product = new ProductEntity();
                        product.Id = int.Parse(row.ItemArray[0].ToString());
                        product.Code = row.ItemArray[1].ToString();
                        product.Name = row.ItemArray[2].ToString();
                        product.Description = row.ItemArray[3].ToString();
                        product.PriceUnit = double.Parse(row.ItemArray[4].ToString());
                        product.CostUnit = double.Parse(row.ItemArray[5].ToString());
                        product.IdTypeProduct = int.Parse(row.ItemArray[6].ToString());
                        product.IdState = int.Parse(row.ItemArray[7].ToString());
                        product.Image = row.ItemArray[8].ToString();
                        product.Points = int.Parse(row.ItemArray[9].ToString());
                        product.IdMaterial = int.Parse(row.ItemArray[10].ToString());
                        product.TypeProduct = row.ItemArray[11].ToString();
                        product.State = row.ItemArray[12].ToString();
                        product.Material = row.ItemArray[13].ToString();
                        listProduct.Add(product);
                    }
                    products.ListProduct = listProduct;
                    products.Message = GlobalMessage.Instance.OK;
                }
            }
            catch (Exception ex)
            {
                products.ListProduct = listProduct;
                products.Message = GlobalMessage.Instance.ERROR;
                products.Message.Message = products.Message.Message + " al obtener el listado de productos";
            }

            return products;
        }

        public ProductServiceEntity OnGetProductsActive()
        {
            listProduct.Clear();
            try
            {
                string[,] parameters = { { "@p_id_product", "1", "0" }, { "@p_cod_product", "2", string.Empty }, { "@p_name_product", "2", string.Empty }, { "@p_description_product", "2", string.Empty }, { "@p_price_unit", "6", "0.00" }, { "@p_cost_unit", "6", "0.00" }, { "@p_id_type_product", "1", "1" }, { "@p_id_state", "1", "1" }, { "@p_image_product", "2", string.Empty }, { "@p_points_product", "1", "0" }, { "@p_id_material_product", "1", "0" }, { "@p_option", "1", "2" }, { "@p_word_search", "2", string.Empty } };
                result = BDConnection.Instance.RunStoreProcedure("sp_maintenance_product", parameters);
                if (result != null && result.Tables != null && result.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in result.Tables[0].Rows)
                    {
                        product = new ProductEntity();
                        product.Id = int.Parse(row.ItemArray[0].ToString());
                        product.Code = row.ItemArray[1].ToString();
                        product.Name = row.ItemArray[2].ToString();
                        product.Description = row.ItemArray[3].ToString();
                        product.PriceUnit = double.Parse(row.ItemArray[4].ToString());
                        product.CostUnit = double.Parse(row.ItemArray[5].ToString());
                        product.IdTypeProduct = int.Parse(row.ItemArray[6].ToString());
                        product.IdState = int.Parse(row.ItemArray[7].ToString());
                        product.Image = row.ItemArray[8].ToString();
                        product.Points = int.Parse(row.ItemArray[9].ToString());
                        product.IdMaterial = int.Parse(row.ItemArray[10].ToString());
                        product.TypeProduct = row.ItemArray[11].ToString();
                        product.State = row.ItemArray[12].ToString();
                        product.Material = row.ItemArray[13].ToString();
                        listProduct.Add(product);
                    }
                    products.ListProduct = listProduct;
                    products.Message = GlobalMessage.Instance.OK;
                }
            }
            catch (Exception ex)
            {
                products.ListProduct = listProduct;
                products.Message = GlobalMessage.Instance.ERROR;
                products.Message.Message = products.Message.Message + " al obtener el listado de productos";
            }
            return products;
        }

        public MessageHelper OnSetProduct(ProductEntity Product)
        {
            string msg = string.Empty;
            bool isUpdate = (Product.Id != 0);
            try
            {
                string[,] parameters = { { "@p_id_product", "1", Product.Id.ToString() }, { "@p_cod_product", "2", Product.Code }, { "@p_name_product", "2", Product.Name }, { "@p_description_product", "2", Product.Description }, { "@p_price_unit", "6", Product.PriceUnit.ToString()}, { "@p_cost_unit", "6", Product.CostUnit.ToString() }, { "@p_id_type_product", "1", Product.IdTypeProduct.ToString() }, { "@p_id_state", "1", Product.IdState.ToString() }, { "@p_image_product", "2", Product.Image }, { "@p_points_product", "1", Product.Points.ToString() }, { "@p_id_material_product", "1", Product.IdMaterial.ToString() }, { "@p_option", "1", "2" }, { "@p_word_search", "2", string.Empty } };
                result = BDConnection.Instance.RunStoreProcedure("sp_maintenance_product", parameters);
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
                                    msg = (isUpdate) ? "del producto que se desea actualizar" : " del producto que desea ingresar";
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
                msg = (isUpdate) ? " de actualizar el producto" : " de ingresar un nuevo producto";
                message.Message = message.Message + msg;
            }
            return message;
        }

        public MessageHelper OnDeleteProduct(int Id)
        {
            try
            {
                string[,] parameters = { { "@p_id_product", "1", Id.ToString() }, { "@p_cod_product", "2", string.Empty }, { "@p_name_product", "2", string.Empty }, { "@p_description_product", "2", string.Empty }, { "@p_price_unit", "6", "0.00" }, { "@p_cost_unit", "6", "0.00" }, { "@p_id_type_product", "1", "0" }, { "@p_id_state", "1", "1" }, { "@p_image_product", "2", string.Empty }, { "@p_points_product", "1", "0" }, { "@p_id_material_product", "1", "0" }, { "@p_option", "1", "2" }, { "@p_word_search", "2", string.Empty } };
                result = BDConnection.Instance.RunStoreProcedure("sp_maintenance_product", parameters);
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
                message.Message = message.Message + " al eliminar un producto";
            }
            return message;
        }

        
    }
}