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
//using InterDatosByD;
using PreparaXMLs;
using PreparaPagosXMLs;

namespace Wcf_PJ
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Serv_PJ" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Serv-PJ.svc or Serv-PJ.svc.cs at the Solution Explorer and start debugging.
    public class Serv_PJ : IServ_PJ

    {
        FuncionesLogicas Funciones = new FuncionesLogicas();
        PreparaXMLs.PreparaXMLs oPreparaXMLs = new PreparaXMLs.PreparaXMLs();
        PreparaPagosXMLS oPreparaPagosXMLs = new PreparaPagosXMLS();
        //ImportInvoice importInvoice = new ImportInvoice();

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

        public List<Customer>ListarCustomer([Optional] string Rif)
        {                       
            List<Customer> ListaClientes = Funciones.ListarCustomers(Rif);
  
            return ListaClientes;
        }

        public Customer ValidarCliente(string Rif)
        {

            Customer DevCustomer = Funciones.ListarCustomers(Rif).FirstOrDefault();

            return DevCustomer;

        }

        public int Sumas(int A, int B)
        {
            int resultado = A +B ;

            return resultado;
        }

        public ListCustomers ListarAllCustomer()
        {
            ListCustomers ListaClientes = Funciones.ListAllCustomers();

            return ListaClientes;
        }

        public string myInvoices(string ID, string usuario, string pass, string docNum)
        {
                     
            DataTable DtDIB = new DataTable("ByD");
            DataTable DtDID = new DataTable("ByD");
            DataTable DtRel = new DataTable("ByD");

            bool[] protocolo = new bool[3] { true, true, true  };

            pass = "Orn.2020";
            usuario = "_ORN_SCENARI";
            ID = "my349444.sapbydesign.com";
            //docNum = "65";
            string Resultado = Convert.ToString(oPreparaXMLs.ProcTimbrado(Convert.ToInt32(docNum)));


            //importInvoice.syncPass = pass;
            //importInvoice.SystemId = ID;
            //importInvoice.syncUser = usuario;
            //importInvoice.strLastID = seg;
            //importInvoice.strDocNum = docNum;

            //bool response = importInvoice.QueryCustomrInv(out DtDIB, out DtDID, out DtRel, protocolo);


            return Resultado;

        }

        public PreparaXMLs.TimbradoResult TimbrarFactura(string NumDoc)
        {
            PreparaXMLs.TimbradoResult Otimbrado = new PreparaXMLs.TimbradoResult();
            DataTable DtDIB = new DataTable("ByD");
            DataTable DtDID = new DataTable("ByD");
            DataTable DtRel = new DataTable("ByD");

            bool[] protocolo = new bool[3] { true, true, true };


            Otimbrado  = oPreparaXMLs.ProcTimbrado(Convert.ToInt32(NumDoc));

            return Otimbrado;
        }

        public PreparaPagosXMLs.TimbradoResult TimbrarPago(string NumDoc)
        {
            PreparaPagosXMLs.TimbradoResult Otimbrado = new PreparaPagosXMLs.TimbradoResult();
            DataTable DtDIB = new DataTable("ByD");
            DataTable DtDID = new DataTable("ByD");
            DataTable DtRel = new DataTable("ByD");

            bool[] protocolo = new bool[3] { true, true, true };


            Otimbrado  = oPreparaPagosXMLs.ProcTimbrado(Convert.ToInt32(NumDoc));

            return Otimbrado;
        }
    }
}
