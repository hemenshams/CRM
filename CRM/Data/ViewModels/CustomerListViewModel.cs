using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRM.Data.ViewModels
{
    public class CustomerListViewModel
    {
        public List<CustomerViewModel> Customers { get; set; }

        public int TotlaCount { get; set; }
    }
}