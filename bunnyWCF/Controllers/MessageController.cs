using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using bunnyWCF.Utils.Helper;
using bunnyWCF.Utils;
using bunnyWCF.Entities.Admin.Catalogs;
using bunnyWCF.Connection;
namespace bunnyWCF.Controllers
{
    public class MessageController
    {
        private readonly static MessageController instance;

        public static MessageController Instance
        {
            get { return instance; }
        }

        private DataSet result;
        private MessageServiceEntity message = new MessageServiceEntity();
        private List<MessageEntity> listMessage = new List<MessageEntity>();
        private MessageEntity typeMessage;
        private MessageHelper messageH;

        public MessageServiceEntity OnGetMessage()
        {
            listMessage.Clear();
            try
            {
                string[,] parameters = { { "@p_cod_message", "2", "0" }, { "@p_message_description", "2", string.Empty },{ "@p_option", "1", "2" }};
                result = BDConnection.Instance.RunStoreProcedure("sp_maintenance_message", parameters);
                if (result != null && result.Tables != null && result.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in result.Tables[0].Rows)
                    {
                        typeMessage = new MessageEntity();
                        typeMessage.Code = row.ItemArray[0].ToString();
                        typeMessage.Message = row.ItemArray[1].ToString();
                        listMessage.Add(typeMessage);
                    }
                    message.ListMessage = listMessage;
                    message.Message = GlobalMessage.Instance.OK;
                }
            }
            catch (Exception ex)
            {
                message.ListMessage = listMessage;
                message.Message = GlobalMessage.Instance.ERROR;
                message.Message.Message = message.Message.Message + " al obtener el listado de los tipos de pedido";
            }

            return message;
        }
       
        public MessageHelper OnSetMessage(MessageEntity Message)
        {
            try
            {
                string[,] parameters = { { "@p_cod_message", "2", Message.Code }, { "@p_message_description", "2", Message.Message}, { "@p_option", "1", "1" } };
                result = BDConnection.Instance.RunStoreProcedure("sp_maintenance_message", parameters);
                if (result != null && result.Tables != null && result.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in result.Tables[0].Rows)
                    {
                        switch (row.ItemArray[0].ToString())
                        {
                            case "200":
                                {
                                    messageH = GlobalMessage.Instance.OK;
                                    break;
                                }
                            case "201":
                                {
                                    messageH = GlobalMessage.Instance.EXIST;
                                    messageH.Message = messageH.Message + " con el código de mensaje ingresado";
                                    break;
                                }
                            default:
                                {
                                    messageH = GlobalMessage.Instance.ERROR;
                                    messageH.Message = row.ItemArray[1].ToString();
                                    break;

                                }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                messageH = GlobalMessage.Instance.ERROR;
                messageH.Message = message.Message + " al ingresar el registro";

            }

            return messageH;
        }

        public MessageHelper OnUpdateMessage(MessageEntity Message)
        {
            try
            {
                string[,] parameters = { { "@p_cod_message", "2", Message.Code }, { "@p_message_description", "2", Message.Message }, { "@p_option", "1", "3" } };
                result = BDConnection.Instance.RunStoreProcedure("sp_maintenance_message", parameters);
                if (result != null && result.Tables != null && result.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in result.Tables[0].Rows)
                    {
                        switch (row.ItemArray[0].ToString())
                        {
                            case "200":
                                {
                                    messageH = GlobalMessage.Instance.OK;
                                    break;
                                }
                            case "201":
                                {
                                    messageH = GlobalMessage.Instance.EXIST;
                                    messageH.Message = messageH.Message + " con el código de mensaje a actualizar";
                                    break;
                                }
                            default:
                                {
                                    messageH = GlobalMessage.Instance.ERROR;
                                    messageH.Message = row.ItemArray[1].ToString();
                                    break;

                                }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                messageH = GlobalMessage.Instance.ERROR;
                messageH.Message = message.Message + " al actualizar el registro";

            }

            return messageH;
        }
       
     



    }
}