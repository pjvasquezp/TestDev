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
        DBTrasaccion transaccion = new DBTrasaccion();

        public bool ValidaConexionSQL()
        {
            bool Exitosa = transaccion.ValidaConexionSQL();

            return Exitosa;
        }
        public Customer ValidarCliente(string Rif)
        {
            bool Existe = false;

            //transaccion.ListarCustomers();

            var queryCustomers = from cust in transaccion.ListarCustomers()
                                 where cust.Rif == Rif
                                 select cust;
                                                                      
            return queryCustomers.FirstOrDefault();
        }     

        public string CreateCustomer(Customer ObjeCustomer)
        {
            
            string Resultado = "Error";
            string Mensaje = "";
                       

            Resultado = transaccion.CreateCustomer(ObjeCustomer);

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

        public List<Customer> ListarCustomers([Optional] string Rif)
        {
            List<Customer> ListaClientes = transaccion.ListarCustomers(Rif);

            return ListaClientes;
        }
    }
}
