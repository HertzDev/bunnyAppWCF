using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
namespace bunnyWCF.Connection
{
    public class BDConnection
    {
        private readonly string DATABASE = "bunny";
        private readonly string DATASOURCE = "BENAZIR\\SQLEXPRESS";
        private readonly string USERID = "";
        private readonly string PASSWORD = "";
        private readonly static BDConnection instance = new BDConnection();

        public static BDConnection Instance 
        {
            get { return instance; }
        }


        private SqlConnection conn;

        public BDConnection() 
        {
            conn = new SqlConnection("Data Source="+DATASOURCE+"; Initial Catalog="+DATABASE+";Integrated Security=True");
        }

        public DataSet RunStoreProcedure(string nameStoreProcedure, string[,] parameters)
        {
            try
            {
                if (conn.State != ConnectionState.Open) 
                {
                    conn.Open();
                }
                SqlCommand command = new SqlCommand(nameStoreProcedure,conn);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                command.CommandType = CommandType.StoredProcedure;
                
                try
                {
                    // :::::::SqlDbType:::::::
                    // 1 - OleDbType.Integer
                    // 2 - OleDbType.VarChar
                    // 3 - OleDbType.Char
                    // 4 - OleDbType.Date
                    // {NOMBREPARAMETRO,  SQLTYPE   , VALUE}
                    // {"P_SN_ACTIVO"  ,    "1"     ,  "1" }
                    if (parameters != null)
                    {
                        for (int i = 0; i < parameters.GetLength(0); i++)
                        {
                            //Parameto
                            SqlParameter param = new SqlParameter();
                            //Tipo de parametro
                            //param.TypeName = "in";
                            //Nombre del parametro
                            param.ParameterName = parameters[i, 0];
                            //Tipo de Dato
                            switch (parameters[i, 1])
                            {
                                case "1":
                                    param.SqlDbType = SqlDbType.Int;
                                    param.SqlValue = parameters[i, 2];
                                    break;
                                case "2":
                                    param.SqlDbType = SqlDbType.NVarChar;
                                    param.SqlValue = parameters[i, 2];
                                    break;
                                case "3":
                                    param.SqlDbType = SqlDbType.Char;
                                    param.SqlValue = parameters[i, 2];
                                    break;
                                case "4":
                                    param.SqlDbType = SqlDbType.DateTime;
                                    param.SqlValue = parameters[i, 2];
                                    break;
                                case "5":
                                    param.SqlDbType = SqlDbType.Time;
                                    param.SqlValue = parameters[i, 2];
                                    break;
                                case "6":
                                    param.SqlDbType = SqlDbType.Decimal;
                                    param.SqlValue = parameters[i, 2];
                                    break;
                            }
                            command.Parameters.Add(param);
                        }
                    }
                    DataSet dataset=new DataSet();
                    adapter.Fill(dataset);
                    return dataset;
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al ejecutar el procedimiento almacenado: " + ex.Message);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error de conexión: " + ex.Message);
            }
            finally 
            {
                conn.Close();
            }
        }
    }
}