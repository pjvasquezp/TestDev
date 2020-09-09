using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Oracle.ManagedDataAccess.Client;

namespace PJ.DataLayer
{
    public class DaConnectSQL
    {
        public SqlConnection Conex;
        public SqlTransaction Transac;

        public DaConnectSQL()
        {
            myConexionSQL();
        }


        public SqlConnection myConexionSQL()
        {
            try
            {
                Conex = new SqlConnection(Properties.Settings.Default.ConnStringSQL);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return Conex;
        }
        public void Open()
        {
            try
            {
                Conex.Open();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error en la Conexion al Servidor de SQL " + ex.Message);
            }
        }
        public void Close()
        {
            try
            {
                Conex.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error en la Conexion al Servidor de SQL " + ex.Message);
            }
        }

        public SqlTransaction BeginTransaction()
        {
            Transac = Conex.BeginTransaction();
            return Transac;
        }
        public void CommitTransaction()
        {
            if (Transac != null)
                Transac.Commit();
        }
        public void RollBackTransaction()
        {
            if (Transac != null)
                Transac.Rollback();
        }

    }
}
