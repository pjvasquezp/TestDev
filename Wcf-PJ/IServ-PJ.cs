using PJ.BusinessEntity;
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
    [ServiceContract]
    public interface IServ_PJ
    {
        [OperationContract]
        bool ValidaConexionSQL();

        [OperationContract]
        string CreateCustomer(String CustomerName, String Contact, String Email, string Rif);

        [OperationContract]
        List<Customer>ListarCustomer([Optional] string Rif);

        [OperationContract]
        Customer ValidarCliente(string Rif);

        [OperationContract]
        int Sumas(int A,int B);
    }
}
