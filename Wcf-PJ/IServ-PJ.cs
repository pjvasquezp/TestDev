
using PJ.BusinessEntity;
using PreparaPagosXMLs;
using PreparaXMLs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Wcf_PJ
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IServ_PJ" in both code and config file together.
    [ServiceContract(Namespace = "http://oriondev.ddns.net/Wcf_PJ")]
    public interface IServ_PJ
    {
        [OperationContract]
        bool ValidaConexionSQL();

        [OperationContract]
        string CreateCustomer(String CustomerName, String Contact, String Email, string Rif);

        [OperationContract]
        string myInvoices(string ID, string usuario, string pass, string docNum);
                
        [OperationContract(Name = "TimbrarFactura")]
        PreparaXMLs.TimbradoResult TimbrarFactura(String NumDoc);

        //[OperationContract(Name = "TimbrarFactura2")]
        //PreparaXMLs.TimbradoResult TimbrarFactura2(Object CabeceraFactura, List<Object> Detallefactura);

        [OperationContract(Name = "TimbrarPago")]
        PreparaPagosXMLs.TimbradoResult TimbrarPago(String NumDoc);

        [OperationContract]
        List<Customer>ListarCustomer([Optional] string Rif);

        [OperationContract]
        ListCustomers ListarAllCustomer();

        [OperationContract]
        Customer ValidarCliente(string Rif);

        [OperationContract (Name = "Sumas")]
        int Sumas(int A,int B);
    }
}
