using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using bunnyWCF.Connection;
using bunnyWCF.Entities.Admin.Catalogs;
using bunnyWCF.Entities.General;
using bunnyWCF.Utils;
using bunnyWCF.Utils.Helper;
using System.Data;
namespace bunnyWCF.Controllers
{
    public class MeetingPointController
    {
        private MeetingPointController instance=new MeetingPointController();
        public MeetingPointController Instance
        {
            get { return instance; }
        }
        private DataSet result;
        private MeetingPointServiceEntity MeetingPoints = new MeetingPointServiceEntity();
        private List<MeetingPointEntity> listMeetingPoint = new List<MeetingPointEntity>();
        private MeetingPointEntity meetingPoint;
        private PointEntity point;
        private MessageHelper Message = new MessageHelper();

        public MeetingPointServiceEntity OnGetMeetingPoints()
        {
            listMeetingPoint.Clear();
            try
            {
                string[,] parameters = { { "@p_id_meeting_point", "1", "0" }, { "@p_direction_meeting", "2", string.Empty }, { "@p_latitude_meeting", "2", string.Empty }, { "@p_longitude_meeting", "2", string.Empty }, { "@p_id_state", "1", "0" }, { "@p_id_user", "1", "0"}, { "@p_option", "1", "2" } };
                result = BDConnection.Instance.RunStoreProcedure("sp_maintenance_meeting_point", parameters);
                if (result != null && result.Tables != null && result.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in result.Tables[0].Rows)
                    {

                        meetingPoint = new MeetingPointEntity();
                        meetingPoint.IdMeetingPoint= int.Parse(row.ItemArray[0].ToString());
                        meetingPoint.Direction = row.ItemArray[1].ToString();
                        meetingPoint.Point = new PointEntity() { Latitude=double.Parse(row.ItemArray[2].ToString()), Longitude=double.Parse(row.ItemArray[3].ToString()) };
                        meetingPoint.IdState = int.Parse(row.ItemArray[3].ToString());
                        meetingPoint.IdUser = int.Parse(row.ItemArray[4].ToString());
                        meetingPoint.State = row.ItemArray[5].ToString();
                        listMeetingPoint.Add(meetingPoint);
                    }
                    MeetingPoints.ListMeetingPoints= listMeetingPoint;
                    MeetingPoints.Message = GlobalMessage.Instance.OK;
                }
            }
            catch (Exception ex)
            {
                MeetingPoints.ListMeetingPoints = listMeetingPoint;
                MeetingPoints.Message = GlobalMessage.Instance.ERROR;
                MeetingPoints.Message.Message = MeetingPoints.Message.Message + " al obtener el listado de departamentos";
            }

            return MeetingPoints;
        }

        public MessageHelper OnSetMeetingPoint(MeetingPointEntity Meeting)
        {
            string msg = string.Empty;
            bool isUpdate = (Meeting.IdMeetingPoint != 0);
            
            try
            {
                string[,] parameters = { { "@p_id_meeting_point", "1", (isUpdate)?Meeting.IdMeetingPoint.ToString():"0" }, { "@p_direction_meeting", "2", Meeting.Direction }, { "@p_latitude_meeting", "2", Meeting.Point.Latitude.ToString() }, { "@p_longitude_meeting", "2", Meeting.Point.Longitude.ToString() }, { "@p_id_state", "1", (isUpdate)?Meeting.IdState.ToString():"1" }, { "@p_id_user", "1", Meeting.IdUser.ToString() }, { "@p_option", "1", (isUpdate)?"3":"1" } };
                result = BDConnection.Instance.RunStoreProcedure("sp_maintenance_meeting_point", parameters);
                if (result != null && result.Tables != null && result.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in result.Tables[0].Rows)
                    {
                        switch (row.ItemArray[0].ToString())
                        {
                            case "200":
                                {
                                    Message = GlobalMessage.Instance.OK;
                                    break;
                                }
                            case "201":
                                {
                                    Message = GlobalMessage.Instance.EXIST;
                                    msg = (isUpdate) ? "del punto frecuente que se desea actualizar" : " del punto frecuente que desea ingresar";
                                    Message.Message = Message.Message + " " + msg;
                                    break;
                                }
                            default:
                                {
                                    Message = GlobalMessage.Instance.ERROR;
                                    Message.Message = row.ItemArray[1].ToString();
                                    break;

                                }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Message = GlobalMessage.Instance.ERROR;
                msg = (isUpdate) ? " de actualizar el lugar frecuente" : " de ingresar un nuevo lugar frecuente";
                Message.Message = Message.Message + msg;
            }
            return Message;
        }

        public MessageHelper OnDeleteMeetingPoint(int Id)
        {
            try
            {
                string[,] parameters = { { "@p_id_meeting_point", "1", Id.ToString()}, { "@p_direction_meeting", "2", string.Empty }, { "@p_latitude_meeting", "2", string.Empty }, { "@p_longitude_meeting", "2", string.Empty }, { "@p_id_state", "1", "1" }, { "@p_id_user", "1", string.Empty }, { "@p_option", "1", "4" } };
                result = BDConnection.Instance.RunStoreProcedure("sp_maintenance_meeting_point", parameters);
                if (result != null && result.Tables != null && result.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in result.Tables[0].Rows)
                    {
                        switch (row.ItemArray[0].ToString())
                        {
                            case "200":
                                {
                                    Message = GlobalMessage.Instance.OK;
                                    break;
                                }
                            default:
                                {
                                    Message = GlobalMessage.Instance.ERROR;
                                    Message.Message = row.ItemArray[1].ToString();
                                    break;
                                }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Message = GlobalMessage.Instance.ERROR;
                Message.Message = Message.Message;
            }
            return Message;
        }
       
    }
}