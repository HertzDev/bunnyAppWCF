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
    public class UserController
    {
        private readonly static UserController instance;

        public static UserController Instance
        {
            get { return instance; }
        }

        private DataSet result;
        private UserServiceEntity users = new UserServiceEntity();
        private List<UserEntity> listUser = new List<UserEntity>();
        private UserEntity user;
        private MessageHelper message;
        public UserServiceEntity OnGetUsers()
        {
            listUser.Clear();
            try
            {
                string[,] parameters = { { "@p_id_user", "1", "0" }, { "@p_username", "2", string.Empty }, { "@p_password", "2", string.Empty }, { "@p_id_type_user", "1", "1" }, { "@p_id_state", "1", "1" }, { "@p_option", "1", "2" }, { "@p_word_search", "2", string.Empty } };
                result = BDConnection.Instance.RunStoreProcedure("sp_maintenance_user", parameters);
                if (result != null && result.Tables != null && result.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in result.Tables[0].Rows)
                    {
                        user = new UserEntity();
                        user.IdUser = int.Parse(row.ItemArray[0].ToString());
                        user.UserName = row.ItemArray[1].ToString();
                        user.Password = row.ItemArray[2].ToString();
                        user.IdTypeUser = int.Parse(row.ItemArray[3].ToString());
                        user.IdState = int.Parse(row.ItemArray[4].ToString());
                        user.TypeUser = row.ItemArray[5].ToString();
                        user.State = row.ItemArray[6].ToString();
                        listUser.Add(user);
                    }
                    users.ListUser = listUser;
                    users.Message = GlobalMessage.Instance.OK;
                }
            }
            catch (Exception ex)
            {
                users.ListUser = listUser;
                users.Message = GlobalMessage.Instance.ERROR;
                users.Message.Message = users.Message.Message + " al obtener el listado de usuarios";
            }

            return users;
        }
        public UserServiceEntity OnGetUsersByWord(string WordSearch)
        {
            listUser.Clear();
            try
            {
                string[,] parameters = { { "@p_id_user", "1", "0" }, { "@p_username", "2", string.Empty }, { "@p_password", "2", string.Empty }, { "@p_id_type_user", "1", "1" }, { "@p_id_state", "1", "1" }, { "@p_option", "1", "5" }, { "@p_word_search", "2", WordSearch } };
                result = BDConnection.Instance.RunStoreProcedure("sp_maintenance_user", parameters);
                if (result != null && result.Tables != null && result.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in result.Tables[0].Rows)
                    {
                        user = new UserEntity();
                        user.IdUser = int.Parse(row.ItemArray[0].ToString());
                        user.UserName = row.ItemArray[1].ToString();
                        user.Password = row.ItemArray[2].ToString();
                        user.IdTypeUser = int.Parse(row.ItemArray[3].ToString());
                        user.IdState = int.Parse(row.ItemArray[4].ToString());
                        user.TypeUser = row.ItemArray[5].ToString();
                        user.State = row.ItemArray[6].ToString();
                        listUser.Add(user);
                    }
                    users.ListUser = listUser;
                    users.Message = GlobalMessage.Instance.OK;
                }
            }
            catch (Exception ex)
            {
                users.ListUser = listUser;
                users.Message = GlobalMessage.Instance.ERROR;
                users.Message.Message = users.Message.Message + " al obtener el listado de usuarios";
            }

            return users;
        }

        public UserServiceEntity OnGetUsersActives()
        {
            listUser.Clear();
            try
            {
                string[,] parameters = { { "@p_id_user", "1", "0" }, { "@p_username", "2", string.Empty }, { "@p_password", "2", string.Empty }, { "@p_id_type_user", "1", "1" }, { "@p_id_state", "1", "1" }, { "@p_option", "1", "6" }, { "@p_word_search", "2", string.Empty } };
                result = BDConnection.Instance.RunStoreProcedure("sp_maintenance_user", parameters);
                if (result != null && result.Tables != null && result.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in result.Tables[0].Rows)
                    {
                        user = new UserEntity();
                        user.IdUser = int.Parse(row.ItemArray[0].ToString());
                        user.UserName = row.ItemArray[1].ToString();
                        user.Password = row.ItemArray[2].ToString();
                        user.IdTypeUser = int.Parse(row.ItemArray[3].ToString());
                        user.IdState = int.Parse(row.ItemArray[4].ToString());
                        user.TypeUser = row.ItemArray[5].ToString();
                        user.State = row.ItemArray[6].ToString();
                        listUser.Add(user);
                    }
                    users.ListUser = listUser;
                    users.Message = GlobalMessage.Instance.OK;
                }
            }
            catch (Exception ex)
            {
                users.ListUser = listUser;
                users.Message = GlobalMessage.Instance.ERROR;
                users.Message.Message = users.Message.Message + " al obtener el listado de usuarios";
            }

            return users;
        }



        public MessageHelper OnSetUser(UserEntity User)
        {
            string msg = string.Empty;
            bool isUpdate = (User.IdUser != 0);
            try
            {
                string[,] parameters = { { "@p_id_user", "1", (isUpdate)?User.IdUser.ToString():"0" }, { "@p_username", "2", User.UserName }, { "@p_password", "2", User.Password }, { "@p_id_type_user", "1", User.IdTypeUser.ToString() }, { "@p_id_state", "1", (isUpdate)?User.IdState.ToString():"1" }, { "@p_option", "1", (isUpdate)?"3":"1" }, { "@p_word_search", "2", string.Empty } };
                result = BDConnection.Instance.RunStoreProcedure("sp_maintenance_user", parameters);
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
                                    msg = (isUpdate) ? "del usuario que se desea actualizar" : " del usuario que desea ingresar";
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
                msg = (isUpdate) ? " de actualizar el usuario" : " de ingresar un nuevo usuario";
                message.Message = message.Message + msg;
            }
            return message;
        }
        public MessageHelper OnDeleteUser(int Id)
        {
            try
            {
                string[,] parameters = { { "@p_id_user", "1", Id.ToString()}, { "@p_username", "2", string.Empty }, { "@p_password", "2", string.Empty }, { "@p_id_type_user", "1", "0" }, { "@p_id_state", "1", "1" }, { "@p_option", "1", "4" }, { "@p_word_search", "2", string.Empty } };
                result = BDConnection.Instance.RunStoreProcedure("sp_maintenance_user", parameters);
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
                message.Message = message.Message+ " al eliminar un usuario";
            }
            return message;
        }

    }
}