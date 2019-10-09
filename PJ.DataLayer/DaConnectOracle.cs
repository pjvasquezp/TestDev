using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;


namespace PJ.DataLayer
{
    public class DaConnectOracle
    {
        public OracleConnection Con; //= new OracleConnection();
        public OracleTransaction Tran;

        public void New(string SERVICE_NAME)
        {
            DAORAConnection(SERVICE_NAME);
        }

        public OracleConnection DAORAConnection(string SERVICE_NAME)
        {
            bool Local = false;
            string HOST = Properties.Settings.Default.HOST;                     //HOST=172.20.5.62
            string PORT = Properties.Settings.Default.PORT;                      //PORT=1521 
                                                                                 //Dim SERVICE_NAME As String = PRO.DataAcces.My.MySettings.Default.SERVICE_NAME   //SERVICE_NAME = EAMCURS
            string UserId = Properties.Settings.Default.UserId;                     //User Id=EAM
            string PasswordSRV = Properties.Settings.Default.PasswordSRV;        //Password Service_Name=EAM
            string PasswordProd = Properties.Settings.Default.PasswordPRD;                                //Password=EAM 


            //Dim UserId As String = ConfigurationManager.AppSettings.Keys("UserID")                  //User Id = EAM
            //Dim HOST As String = ConfigurationManager.AppSettings.Keys("HOST")                      //PRO.DataAcces.My.Settings.HOST                     'HOST=172.20.5.62
            //Dim PORT As String = ConfigurationManager.AppSettings.Keys("PORT")                      //PRO.DataAcces.My.Settings.PORT                     'PORT=1521 
            //Dim PasswordSRV As String = ConfigurationManager.AppSettings.Keys("PasswordSRV")        //PRO.DataAcces.My.Settings.PasswordSRV              'Password Service_Name=EAM
            //Dim PasswordProd As String = ConfigurationManager.AppSettings.Keys("PasswordPRD")       //PRO.DataAcces.My.Settings.PasswordPRD              'Password=EAM

            string ConnectionString;
            string ConneLocal = Properties.Settings.Default.ConnStringORA;        //Conexion strig Local Disoftnet



                if (Local == true)

                {
                    ConnectionString = ConneLocal;
                }

                    else
                    {
                            if (SERVICE_NAME == "EAMPROD")
                            {
                                // EAM = "Data Source=:" + UserId + "/" + PasswordProd + " (DESCRIPTION = (ADDRESS = (PROTOCOL = TCP)(HOST = cluoracle.proagro.com)(PORT = 1521))(CONNECT_DATA = (SERVER = DEDICATED)(SERVICE_NAME = EAM)))"

                                //ConnectionString = "Data Source=:" + UserId + "/" + PasswordProd + "cluoracle.proagro.com:1521/EAM" '"Data Source=" + UserId + "/" + Password + "@cluoracle.proagro.com:1521/EAM" '("jdbc:oracle:thin:@cluoracle.proagro.com:1521/EAM")
                                ConnectionString = "Data Source=(DESCRIPTION =(ADDRESS = (PROTOCOL = TCP)(HOST = cluoracle.proagro.com)(PORT = 1521))(CONNECT_DATA = (SERVER = DEDICATED)(SERVICE_NAME = EAM)));User Id=" + UserId + ";Password=" + PasswordProd + ";";
                            }

                            else
                            {
                                    ConnectionString = "Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=" + HOST + ")(PORT=" + PORT + ")))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=" + SERVICE_NAME + ")));User Id=" + UserId + ";Password=" + PasswordSRV + ";";
                            }
                    }
        

                try
                {
                        //Con = New OracleConnection(PRO.DataAcces.My.MySettings.Default.ConnStringORA)
                        //"Data 'Source = (DESCRIPTION = (ADDRESS_LIST = (ADDRESS = (PROTOCOL = TCP)(HOST = 172.20.5.62)(PORT = 1521)))(CONNECT_DATA = (SERVER = DEDICATED)(SERVICE_NAME = EAMCURS))); User Id = EAM; Password = EAM;
                        Con = new OracleConnection(ConnectionString);
                
                }

                catch (Exception)
                {
                       throw;
                }

                    return Con;
        }
         public void Open()
         {
                try
                {
                    Con.Open();
                }

                catch (Exception ex)
                {
                    Console.WriteLine("Error en la Conexion al Servidor de ORACLE " + ex.Message);
                }
          }

        public void Close()
        {
            try
            {
                Con.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error en la Conexion al Servidor de ORACLE " + ex.Message);
            }
        }

        public OracleTransaction BeginTransaction()
        {
            Tran = Con.BeginTransaction();
            return Tran;
        }

        public OracleTransaction Trans()
        {
            Tran = Con.BeginTransaction(System.Data.IsolationLevel.ReadCommitted);
            return Tran;
        }

        public void CommitTransaction()
        {            
            if (Tran != null)
            {
                Tran.Commit();
            }
        }

        
        public void RollBackTransaction()
        {
            if (Tran != null)
            {
                Tran.Rollback();
            }
        
        }
    }

}
