using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PJ.BusinessEntity
{
    
    public class Customer
    {
        //Public Delegate Sub DelegadoResumenLectura(ByVal ResumenLectura As EntidadResumenLectura)
       // public delegate void DelegadoCustomer(Customer customer);

        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string Contact { get; set; }
        public string Email { get; set; }
        public string Rif { get; set; }
    }

    public class ListCustomers : List<Customer>
    {
      
    }

}
