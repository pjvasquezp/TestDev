using PJ.BusinessEntity;
using PJ.DataLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PJ.BusinessLogic
{
    public class FuncionesLogicas
    {
        DBTrasaccion ObjTransaccion = new DBTrasaccion();

        public bool ValidaConexionSQL()
        {
            bool Exitosa = ObjTransaccion.ValidaConexionSQL();

            return Exitosa;
        }
        public Customer ValidarCliente(string Rif)
        {
            bool Existe = false;

            //transaccion.ListarCustomers();

            var queryCustomers = from cust in ObjTransaccion.ListarCustomers()
                                 where cust.Rif == Rif
                                 select cust;
                                                                      
            return queryCustomers.FirstOrDefault();
        }     

        public string CreateCustomer(Customer ObjCustomer)
        {
            
            string Resultado = "Error";

            Resultado = ObjTransaccion.CreateCustomer(ObjCustomer);            

            return Resultado;
        }

        public List<Customer> ListarCustomers([Optional] string Rif)
        {
            List<Customer> ListaClientes = ObjTransaccion.ListarCustomers(Rif);

            return ListaClientes;
        }

        public ListCustomers ListAllCustomers()
        {
            ListCustomers ListaClientes = ObjTransaccion.ListAllCustomers();

            return ListaClientes;
        }

        
    }
}
