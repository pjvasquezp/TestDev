using PJ.BusinessEntity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PJ.DataLayer
{

    public class DBTrasaccion
    {
        public void DACliente()
        {
            DaConnectSQL DASQLConnection = new DaConnectSQL();
        }

        public string CreateCustomer(Customer ObjCustomer)
        {
          
            string Result = "Error";
            var ConClass = new DaConnectSQL();
            bool existe = false;

            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = ConClass.DASQLConnection();

                cmd.CommandType = CommandType.Text;

                cmd.Transaction = ConClass.Tran;

                cmd.CommandText = "Insert into Customers (CustomerName, Contact, Email, Rif) " +
                    "Values  ('" + ObjCustomer.CustomerName + "','" + ObjCustomer.Contact + "', '" + ObjCustomer.Email + "', '" + ObjCustomer.Rif + "')";

                ConClass.Open();                

                cmd.Transaction = ConClass.Con.BeginTransaction();

                existe = ValidarRif(ObjCustomer.Rif, cmd);

                if (existe)
                {
                    Result = "Error " + "Rif Existente"; 
                }

                else
                {
                    cmd.ExecuteNonQuery();

                    cmd.Transaction.Commit();

                    Result = "Exitoso";
                }

                
            }
            catch (Exception ex)
            {
                ConClass.RollBackTransaction();

                Result = ex.Message;
            }

            finally
            {
                ConClass.Close();
            }

            return Result;
        }

        public bool ValidarRif(string Rif, SqlCommand CMD)
        {
            Customer ExisCustomer = new Customer();
            bool Result = false;
            bool Errores = false;

            CMD.CommandType = CommandType.Text;
            CMD.Connection = CMD.Connection; 
            CMD.CommandText = "SELECT * FROM Customers where RIF =  '" + Rif + "' ";

            SqlDataReader dr = CMD.ExecuteReader();

            try
            {
                while (dr.Read())
                {
                    {
                        ExisCustomer.CustomerId = dr.GetInt32(0);
                        ExisCustomer.CustomerName = dr.GetString(1);
                        ExisCustomer.Contact = dr.GetString(2);
                        ExisCustomer.Email = dr.GetString(3);
                        ExisCustomer.Rif = dr.GetString(4);
                    }
                }
                dr.Close();

                if (ExisCustomer.CustomerId.ToString() == "")
                {
                    Result = true;
                }
                       
            }

       
            catch (Exception ex)
            {
                
                Console.WriteLine("Error en la transaccion " + ex.Message);
            }
            return Result;
        }


    }



}
