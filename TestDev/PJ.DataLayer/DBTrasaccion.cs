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

            if (ConClass.Conex.State == ConnectionState.Open)
            {
                Exitosa = true;
            }

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

                cmd.Connection = ConClass.myConexionSQL();

                cmd.CommandType = CommandType.Text;

                cmd.Transaction = ConClass.Transac;

                ConClass.Open();
               
                existe = validarRif(ObjCustomer.Rif, cmd);

                cmd.Transaction = ConClass.Conex.BeginTransaction();

                if (existe)
                {
                    Result = "Error " + "Rif Existente"; 
                }

                else
                {
                    cmd.CommandText = "Insert into Customers " +
                    "Values ('" + ObjCustomer.CustomerName + "','" + ObjCustomer.Contact + "', '" + ObjCustomer.Email + "', '" + ObjCustomer.Rif + "')";
                    

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

        public bool validarRif(string Rif, SqlCommand CMD)
        {
            Customer ExisCustomer = new Customer();
            bool Result = false;
            bool Errores = false;

            //CMD.CommandType = CommandType.Text;
            //CMD.Connection = CMD.Connection; 
            CMD.CommandText = "SELECT * FROM Customers where RIF =  '" + Rif + "' ";

            if (CMD.Connection.State == ConnectionState.Open)
            {
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
            }

            else
            {
                Console.WriteLine("Error en la conexion a SQL");
            }

            return Result;
        }

        public ListCustomers ListarCustomers([Optional] string Rif)
        {
            ListCustomers ListaCliente = new ListCustomers();
            bool Result = false;
            var ConClass = new DaConnectSQL();
            bool Errores = false;

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = ConClass.myConexionSQL();

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

        public ListCustomers ListAllCustomers()
        {
            ListCustomers ListaCliente = new ListCustomers();
            bool Result = false;
            var ConClass = new DaConnectSQL();
            bool Errores = false;

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = ConClass.myConexionSQL();

            cmd.CommandType = CommandType.Text;

            ConClass.Open();

            cmd.CommandType = CommandType.Text;
            cmd.Connection = cmd.Connection;

            cmd.CommandText = "SELECT * FROM Customers ";
           
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
