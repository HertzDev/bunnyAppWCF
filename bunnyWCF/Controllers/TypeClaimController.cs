using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using bunnyWCF.Utils;
using bunnyWCF.Utils.Helper;
using bunnyWCF.Connection;
using bunnyWCF.Entities.Admin.Catalogs;
using System.Data;

namespace bunnyWCF.Controllers
{
    public class TypeClaimController
    {
        private readonly static TypeClaimController instance=new TypeClaimController();

        public static TypeClaimController Instance
        {
            get { return instance; }
        }

        private DataSet result;
        private TypeClaimServiceEntity typesClaim = new TypeClaimServiceEntity();
        private List<TypeClaimEntity> listTypeClaim = new List<TypeClaimEntity>();
        private TypeClaimEntity typeClaim;
        private MessageHelper message;

        public TypeClaimServiceEntity OnGetTypesClaim()
        {
            listTypeClaim.Clear();
            try
            {
                string[,] parameters = { { "@p_id_type_claim", "1", "0" }, { "@p_type_claim", "2", string.Empty }, { "@p_id_state", "1", "1" }, { "@p_option", "1", "2" }, { "@p_word_search", "2", string.Empty } };
                result = BDConnection.Instance.RunStoreProcedure("sp_maintenance_type_claim", parameters);
                if (result != null && result.Tables != null && result.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in result.Tables[0].Rows)
                    {
                        typeClaim = new TypeClaimEntity();
                        typeClaim.Id = int.Parse(row.ItemArray[0].ToString());
                        typeClaim.Value = row.ItemArray[1].ToString();
                        typeClaim.IdState = int.Parse(row.ItemArray[2].ToString());
                        typeClaim.State = row.ItemArray[3].ToString();
                        listTypeClaim.Add(typeClaim);
                    }
                    typesClaim.ListTypeClaim = listTypeClaim;
                    typesClaim.Message = GlobalMessage.Instance.OK;
                }
            }
            catch (Exception ex)
            {
                typesClaim.ListTypeClaim = listTypeClaim;
                typesClaim.Message = GlobalMessage.Instance.ERROR;
                typesClaim.Message.Message = typesClaim.Message.Message + " al obtener el listado de los tipos de pedido";
            }

            return typesClaim;
        }
        public TypeClaimServiceEntity OnGetTypesClaimByWord(string WordSearch)
        {
            listTypeClaim.Clear();
            try
            {
                string[,] parameters = { { "@p_id_type_claim", "1", "0" }, { "@p_type_claim", "2", string.Empty }, { "@p_id_state", "1", "1" }, { "@p_option", "1", "5" }, { "@p_word_search", "2", WordSearch } };
                result = BDConnection.Instance.RunStoreProcedure("sp_maintenance_type_claim", parameters);
                if (result != null && result.Tables != null && result.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in result.Tables[0].Rows)
                    {
                        typeClaim = new TypeClaimEntity();
                        typeClaim.Id = int.Parse(row.ItemArray[0].ToString());
                        typeClaim.Value = row.ItemArray[1].ToString();
                        typeClaim.IdState = int.Parse(row.ItemArray[2].ToString());
                        typeClaim.State = row.ItemArray[3].ToString();
                        listTypeClaim.Add(typeClaim);
                    }
                    typesClaim.ListTypeClaim = listTypeClaim;
                    typesClaim.Message = GlobalMessage.Instance.OK;
                }
            }
            catch (Exception ex)
            {
                typesClaim.ListTypeClaim = listTypeClaim;
                typesClaim.Message = GlobalMessage.Instance.ERROR;
                typesClaim.Message.Message = typesClaim.Message.Message + " al obtener el listado de los tipos de pedido";
            }

            return typesClaim;
        }

        public TypeClaimServiceEntity OnGetTypesClaimActives()
        {
            listTypeClaim.Clear();
            try
            {
                string[,] parameters = { { "@p_id_type_claim", "1", "0" }, { "@p_type_claim", "2", string.Empty }, { "@p_id_state", "1", "1" }, { "@p_option", "1", "6" }, { "@p_word_search", "2", string.Empty } };
                result = BDConnection.Instance.RunStoreProcedure("sp_maintenance_type_claim", parameters);
                if (result != null && result.Tables != null && result.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in result.Tables[0].Rows)
                    {
                        typeClaim = new TypeClaimEntity();
                        typeClaim.Id = int.Parse(row.ItemArray[0].ToString());
                        typeClaim.Value = row.ItemArray[1].ToString();
                        typeClaim.IdState = int.Parse(row.ItemArray[2].ToString());
                        typeClaim.State = row.ItemArray[3].ToString();
                        listTypeClaim.Add(typeClaim);
                    }
                    typesClaim.ListTypeClaim = listTypeClaim;
                    typesClaim.Message = GlobalMessage.Instance.OK;
                }
            }
            catch (Exception ex)
            {
                typesClaim.ListTypeClaim = listTypeClaim;
                typesClaim.Message = GlobalMessage.Instance.ERROR;
                typesClaim.Message.Message = typesClaim.Message.Message + " al obtener el listado de los tipos de pedido";
            }

            return typesClaim;
        }

        public MessageHelper OnSetTypeClaim(TypeClaimEntity TypeClaim)
        {
            string msg = string.Empty;
            bool isUpdate = (TypeClaim.Id != 0);
            try
            {
                string[,] parameters = { { "@p_id_type_claim", "1", (isUpdate) ? TypeClaim.Id.ToString() : "0" }, { "@p_type_claim", "2", TypeClaim.Value }, { "@p_id_state", "1", (isUpdate) ? TypeClaim.IdState.ToString() : "1" }, { "@p_option", "1", (isUpdate) ? "3" : "1" }, { "@p_word_search", "2", string.Empty } };
                result = BDConnection.Instance.RunStoreProcedure("sp_maintenance_type_claim", parameters);
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
                                    msg = (isUpdate) ? "del tipo de reclamo que se desea actualizar" : " del tipo de reclamo que desea ingresar";
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
                msg = (isUpdate) ? " de actualizar el tipo de reclamo" : " de ingresar un nuevo tipo de reclamo";
                message.Message = message.Message + msg;

            }

            return message;
        }
        public MessageHelper OnDeleteTypeClaim(int Id)
        {
            try
            {
                string[,] parameters = { { "@p_id_type_claim", "1", Id.ToString() }, { "@p_type_claim", "2", string.Empty }, { "@p_id_state", "1", "1" }, { "@p_option", "1", "4" }, { "@p_word_search", "2", string.Empty } };
                result = BDConnection.Instance.RunStoreProcedure("sp_maintenance_type_claim", parameters);
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
                message.Message = message.Message + " al eliminar un tipo de reclamo";

            }

            return message;
        }



    }
}