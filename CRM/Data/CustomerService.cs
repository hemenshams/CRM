using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRM.Data.ViewModels;

namespace CRM.Data
{
    public class CustomerService
    {
        private CustomerViewModel Summaries = new CustomerViewModel
        {
            CellPhone = "+989123644125",
            Email = "",
            FullName = "هیمن شمس الدین",
            IsEnable = true,
            CreatedTime = DateTime.Now,
            IsSelected = false
        };



        public Task<CustomerViewModel[]> GetCustomersAsync()
        {
            return Task.FromResult(new[] { Summaries });
        }
    }
}
