using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using bunnyWCF.Connection;
using bunnyWCF.Entities.Admin;
using bunnyWCF.Utils.Helper;
using bunnyWCF.Utils;
namespace bunnyWCF.Controllers
{
    public class ClaimOrderController
    {
        private readonly static ClaimOrderController instance=new ClaimOrderController();

        public static ClaimOrderController Instance
        {
            get { return instance; }
        }

        private DataSet result;
        private ClaimOrderServiceEntity claimOrders = new ClaimOrderServiceEntity();
        private List<ClaimOrderEntity> listClaimOrder = new List<ClaimOrderEntity>();
        private ClaimOrderEntity claimOrder;
        private MessageHelper message;

        public ClaimOrderServiceEntity OnGetClaimOrders()
        {
            listClaimOrder.Clear();
            try
            {
                string[,] parameters = { { "@p_cod_order", "2", string.Empty }, { "@p_date_claim", "6", string.Empty }, { "@p_cod_client", "2", string.Empty }, { "@p_reason", "2", string.Empty }, { "@p_id_type", "1", "0" }, { "@p_id_state", "1", "0" }, { "@p_option", "1", "2" }, { "@p_word_search", "2", string.Empty } };
                result = BDConnection.Instance.RunStoreProcedure("sp_maintenance_claim_order", parameters);
                if (result != null && result.Tables != null && result.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in result.Tables[0].Rows)
                    {
                        claimOrder = new ClaimOrderEntity();
                        claimOrder.CodeOrder = row.ItemArray[0].ToString();
                        claimOrder.DateClaim = row.ItemArray[1].ToString();
                        claimOrder.CodeClient = row.ItemArray[2].ToString();
                        claimOrder.Reason = row.ItemArray[3].ToString();
                        claimOrder.IdType = int.Parse(row.ItemArray[4].ToString());
                        claimOrder.IdState = int.Parse(row.ItemArray[5].ToString());
                        claimOrder.TypeClaim = row.ItemArray[6].ToString();
                        claimOrder.State = row.ItemArray[7].ToString();
                        listClaimOrder.Add(claimOrder);
                    }
                    claimOrders.ListClaimOrder = listClaimOrder;
                    claimOrders.Message = GlobalMessage.Instance.OK;
                }
            }
            catch (Exception ex)
            {
                claimOrders.ListClaimOrder = listClaimOrder;
                claimOrders.Message = GlobalMessage.Instance.ERROR;
                claimOrders.Message.Message = claimOrders.Message.Message + " al obtener el listado de reclamos de pedidos";
            }

            return claimOrders;
        }
        public ClaimOrderServiceEntity OnGetClaimOrdersByWord(string WordSearch)
        {
            listClaimOrder.Clear();
            try
            {
                string[,] parameters = { { "@p_cod_order", "2", string.Empty }, { "@p_date_claim", "6", string.Empty }, { "@p_cod_client", "2", string.Empty }, { "@p_reason", "2", string.Empty }, { "@p_id_type", "1", "0" }, { "@p_id_state", "1", "0" }, { "@p_option", "1", "5" }, { "@p_word_search", "2", WordSearch } };
                result = BDConnection.Instance.RunStoreProcedure("sp_maintenance_claim_order", parameters);
                if (result != null && result.Tables != null && result.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in result.Tables[0].Rows)
                    {
                        claimOrder = new ClaimOrderEntity();
                        claimOrder.CodeOrder = row.ItemArray[0].ToString();
                        claimOrder.DateClaim = row.ItemArray[1].ToString();
                        claimOrder.CodeClient = row.ItemArray[2].ToString();
                        claimOrder.Reason = row.ItemArray[3].ToString();
                        claimOrder.IdType = int.Parse(row.ItemArray[4].ToString());
                        claimOrder.IdState = int.Parse(row.ItemArray[5].ToString());
                        claimOrder.TypeClaim = row.ItemArray[6].ToString();
                        claimOrder.State = row.ItemArray[7].ToString();
                        listClaimOrder.Add(claimOrder);
                    }
                    claimOrders.ListClaimOrder = listClaimOrder;
                    claimOrders.Message = GlobalMessage.Instance.OK;
                }
            }
            catch (Exception ex)
            {
                claimOrders.ListClaimOrder = listClaimOrder;
                claimOrders.Message = GlobalMessage.Instance.ERROR;
                claimOrders.Message.Message = claimOrders.Message.Message + " al obtener el listado de reclamos de pedidos";
            }

            return claimOrders;
        }

        public ClaimOrderServiceEntity OnGetClaimOrdersActive()
        {
            listClaimOrder.Clear();
            try
            {
                string[,] parameters = { { "@p_cod_order", "2", string.Empty }, { "@p_date_claim", "6", string.Empty }, { "@p_cod_client", "2", string.Empty }, { "@p_reason", "2", string.Empty }, { "@p_id_type", "1", "0" }, { "@p_id_state", "1", "0" }, { "@p_option", "1", "6" }, { "@p_word_search", "2", string.Empty } };
                result = BDConnection.Instance.RunStoreProcedure("sp_maintenance_claim_order", parameters);
                if (result != null && result.Tables != null && result.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in result.Tables[0].Rows)
                    {
                        claimOrder = new ClaimOrderEntity();
                        claimOrder.CodeOrder = row.ItemArray[0].ToString();
                        claimOrder.DateClaim = row.ItemArray[1].ToString();
                        claimOrder.CodeClient = row.ItemArray[2].ToString();
                        claimOrder.Reason = row.ItemArray[3].ToString();
                        claimOrder.IdType = int.Parse(row.ItemArray[4].ToString());
                        claimOrder.IdState = int.Parse(row.ItemArray[5].ToString());
                        claimOrder.TypeClaim = row.ItemArray[6].ToString();
                        claimOrder.State = row.ItemArray[7].ToString();
                        listClaimOrder.Add(claimOrder);
                    }
                    claimOrders.ListClaimOrder = listClaimOrder;
                    claimOrders.Message = GlobalMessage.Instance.OK;
                }
            }
            catch (Exception ex)
            {
                claimOrders.ListClaimOrder = listClaimOrder;
                claimOrders.Message = GlobalMessage.Instance.ERROR;
                claimOrders.Message.Message = claimOrders.Message.Message + " al obtener el listado de reclamos de pedidos";
            }

            return claimOrders;
        }

        public MessageHelper OnSetClaimOrder(ClaimOrderEntity ClaimOrder)
        {
            string msg = string.Empty;
            bool isUpdate = (ClaimOrder.CodeOrder != "0");
            try
            {
                string[,] parameters = { { "@p_cod_order", "2", (isUpdate)?ClaimOrder.CodeOrder:string.Empty }, { "@p_date_claim", "6", ClaimOrder.DateClaim }, { "@p_cod_client", "2", ClaimOrder.CodeClient }, { "@p_reason", "2", ClaimOrder.Reason }, { "@p_id_type", "1", ClaimOrder.IdType.ToString() }, { "@p_id_state", "1", (isUpdate)?ClaimOrder.IdState.ToString():"1" }, { "@p_option", "1", (isUpdate)?"3":"1" }, { "@p_word_search", "2", string.Empty } };
                result = BDConnection.Instance.RunStoreProcedure("sp_maintenance_claim_order", parameters);
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
                                    msg = (isUpdate) ? "del reclamo que se desea actualizar" : " del reclamo que desea ingresar";
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
                msg = (isUpdate) ? " de actualizar el reclamo" : " de ingresar un nuevo reclamo";
                message.Message = message.Message + msg;

            }

            return message;
        }
        public MessageHelper OnDeleteTypeClaim(string CodeOrder)
        {
            try
            {
                string[,] parameters = { { "@p_cod_order", "2", CodeOrder}, { "@p_date_claim", "6", string.Empty}, { "@p_cod_client", "2", string.Empty }, { "@p_reason", "2", string.Empty }, { "@p_id_type", "1", "0" }, { "@p_id_state", "1", "0" }, { "@p_option", "1", "4" }, { "@p_word_search", "2", string.Empty } };
                result = BDConnection.Instance.RunStoreProcedure("sp_maintenance_claim_order", parameters);
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
                message.Message = message.Message + " al eliminar un reclamo";

            }

            return message;
        }


    }
}