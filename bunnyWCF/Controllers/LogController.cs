using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using bunnyWCF.Connection;
using bunnyWCF.Entities.Admin.Catalogs;
using bunnyWCF.Utils;

namespace bunnyWCF.Controllers
{
    public class LogController
    {
        private readonly static LogController instance=new LogController();

        public static LogController Instance
        {
            get { return instance; }
        }

        private DataSet result;
        private LogServiceEntity logs = new LogServiceEntity();
        private List<LogEntity> listLog = new List<LogEntity>();
        private LogEntity log;

        public LogServiceEntity OnGetLogs() 
        {
            listLog.Clear();
            try
            {
                string[,] parameters = { { "@p_reason", "1", "0" }, { "@p_date_log", "2", string.Empty }, { "@p_id_user", "1", "0" }, { "@p_cod_message","2",string.Empty }, { "@p_option", "1", "2" }, { "@p_word_search", "2", string.Empty } };
                result = BDConnection.Instance.RunStoreProcedure("sp_maintenance_logs", parameters);
                if (result != null && result.Tables != null && result.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in result.Tables[0].Rows)
                    {
                        log = new LogEntity();
                        log.Reason = row.ItemArray[0].ToString();
                        log.DateLog = row.ItemArray[1].ToString();
                        log.IdUser = int.Parse(row.ItemArray[2].ToString());
                        log.CodeMessage = row.ItemArray[3].ToString();
                        log.UserName = row.ItemArray[4].ToString();
                        log.Message = row.ItemArray[5].ToString();
                        listLog.Add(log);
                    }
                    logs.ListLog = listLog;
                    logs.Message = GlobalMessage.Instance.OK;
                }
            }
            catch (Exception ex)
            {
                logs.ListLog = listLog;
                logs.Message = GlobalMessage.Instance.ERROR;
                logs.Message.Message = logs.Message.Message + " al obtener los logs";
            } return logs;
        }
        public LogServiceEntity OnGetLogsByWord(string WordSearch)
        {
            listLog.Clear();
            try
            {
                string[,] parameters = { { "@p_reason", "1", "0" }, { "@p_date_log", "2", string.Empty }, { "@p_id_user", "1", "0" }, { "@p_cod_message", "2", string.Empty }, { "@p_option", "1", "5" }, { "@p_word_search", "2", WordSearch } };
                result = BDConnection.Instance.RunStoreProcedure("sp_maintenance_logs", parameters);
                if (result != null && result.Tables != null && result.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in result.Tables[0].Rows)
                    {
                        log = new LogEntity();
                        log.Reason = row.ItemArray[0].ToString();
                        log.DateLog = row.ItemArray[1].ToString();
                        log.IdUser = int.Parse(row.ItemArray[2].ToString());
                        log.CodeMessage = row.ItemArray[3].ToString();
                        log.UserName = row.ItemArray[4].ToString();
                        log.Message = row.ItemArray[5].ToString();
                        listLog.Add(log);
                    }
                    logs.ListLog = listLog;
                    logs.Message = GlobalMessage.Instance.OK;
                }
            }
            catch (Exception ex)
            {
                logs.ListLog = listLog;
                logs.Message = GlobalMessage.Instance.ERROR;
                logs.Message.Message = logs.Message.Message + " al obtener los logs";
            } return logs;
        }

    }
}