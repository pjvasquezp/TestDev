using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Configuration;
using PJ.DataLayer;
using System.Data;
using PJ.BusinessEntity;

namespace Wcf_PJ
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Serv_PJ" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Serv-PJ.svc or Serv-PJ.svc.cs at the Solution Explorer and start debugging.
    public class Serv_PJ : IServ_PJ


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


        public int Sumatoria(int A, int B)
        {
            int Resultado = A + B;

            return Resultado;
            
        }

        public string CreateCustomer(string CustomerName, string Contact, string Email, string Rif)
        {
            DBTrasaccion ObTransSQL = new DBTrasaccion();
            string Resultado = "Error";
            string Mensaje = "";

            Customer ObjeCustomer = new Customer()
            { CustomerName = CustomerName,
                Contact = Contact,
                Email = Email,
                Rif = Rif
            };

            Resultado = ObTransSQL.CreateCustomer(ObjeCustomer);

            if (Resultado == "Exitoso")
            {
                Mensaje = "Registro creado correctamente";
            }

            else
            {
                Mensaje = "NO se pudo ingresar el Cliente " + Resultado.ToString();
            }

            return Mensaje;
           
        }

        public List<Customer> ListarCustomer()
        {

            DBTrasaccion ObTransSQL = new DBTrasaccion();
            List<Customer> ListaClientes = ObTransSQL.ListarCustomers();
  
            return ListaClientes;
        }
    }
}
