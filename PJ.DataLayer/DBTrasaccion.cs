using PJ.BusinessEntity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
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

        public bool ValidaConexionSQL()
        {
            bool Exitosa = false;
            var ConClass = new DaConnectSQL();

            ConClass.Open();

            if (ConClass.Con.State == ConnectionState.Open)
                Exitosa = true;

            return Exitosa;
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

                ConClass.Open();

                existe = ValidarRif(ObjCustomer.Rif, cmd);

                cmd.CommandText = "Insert into Customers (CustomerName, Contact, Email, Rif) " +
                    "Values  ('" + ObjCustomer.CustomerName + "','" + ObjCustomer.Contact + "', '" + ObjCustomer.Email + "', '" + ObjCustomer.Rif + "')";
                                          
                cmd.Transaction = ConClass.Con.BeginTransaction();

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

                if (ExisCustomer.CustomerName != null)
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

        public List<Customer>ListarCustomers([Optional] string Rif)
        {
            List<Customer> ListaCliente = new List<Customer>();
            bool Result = false;
            var ConClass = new DaConnectSQL();
            bool Errores = false;

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = ConClass.DASQLConnection();

            cmd.CommandType = CommandType.Text;

            ConClass.Open();

            cmd.CommandType = CommandType.Text;
            cmd.Connection = cmd.Connection;

            if (Rif == null)
            {
                cmd.CommandText = "SELECT * FROM Customers ";
            }

            else
            {
                cmd.CommandText = "SELECT * FROM Customers where RIF =  '" + Rif + "' ";
            }
           
            SqlDataReader dr = cmd.ExecuteReader();

            try
            {
                while (dr.Read())
                {
                    {
                        Customer CLiente = new Customer();
                        CLiente.CustomerId = dr.GetInt32(0);
                        CLiente.CustomerName = dr.GetString(1);
                        CLiente.Contact = dr.GetString(2);
                        CLiente.Email = dr.GetString(3);
                        CLiente.Rif = dr.GetString(4);

                        ListaCliente.Add(CLiente);
                    }
                }
                dr.Close();
            }


            catch (Exception ex)
            {

                Console.WriteLine("Error en la transaccion " + ex.Message);
            }
            return ListaCliente;
        }
    }



}
