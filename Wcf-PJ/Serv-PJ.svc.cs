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
using System.Runtime.InteropServices;
using PJ.BusinessLogic;

namespace Wcf_PJ
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Serv_PJ" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Serv-PJ.svc or Serv-PJ.svc.cs at the Solution Explorer and start debugging.
    public class Serv_PJ : IServ_PJ
    {
        FuncionesLogicas Funciones = new FuncionesLogicas();
       
        public bool ValidaConexionSQL()
        {
            bool Exitosa = Funciones.ValidaConexionSQL();                       

            return Exitosa;
        }

        public string CreateCustomer(string CustomerName, string Contact, string Email, string Rif)
        {
            
            string Resultado = "Error";
            string Mensaje = "";

            Customer ObjeCustomer = new Customer()
            { CustomerName = CustomerName,
                Contact = Contact,
                Email = Email,
                Rif = Rif
            };

            Resultado = Funciones.CreateCustomer(ObjeCustomer);

            return Mensaje;
           
        }

        public List<Customer> ListarCustomer([Optional] string Rif)
        {                       
            List<Customer> ListaClientes = Funciones.ListarCustomers(Rif);
  
            return ListaClientes;
        }
    }
}
