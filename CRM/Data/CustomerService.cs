using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRM.Data.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace CRM.Data
{
    public class CustomerService
    {
        private readonly ApplicationDbContext _context;

        public CustomerService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<CustomerViewModel>> GetCustomersAsync(int PageIndex, int PageSize)
        {
            #region Get All Customers

            if (PageIndex < 1)
            {
                return null;
            }

            var customers = _context.Customers
                .AsQueryable()
                .Skip((PageIndex - 1) * PageSize)
                .Take(PageSize)
                .Select(x => new CustomerViewModel
                {
                    Id = x.Id,
                    CellPhone = x.CellPhone,
                    Email = x.Email,
                    FullName = x.FullName,
                    IsEnable = x.IsEnable,
                    CreatedUserId = x.CreatedUserId,
                    CreatedTime = x.CreatedTime,
                    IsSelected = false
                });

            return await customers.ToListAsync();

            #endregion
        }

        public async Task<CustomerViewModel> CreateCustomerAsync(CustomerViewModel customerViewModel)
        {
            #region Create Customer

            var customer = new Customer()
            {
                CellPhone = customerViewModel.CellPhone,
                CreatedTime = DateTime.Now,
                Email = customerViewModel.Email,
                FullName = customerViewModel.FullName,
                IsEnable = true,
                //CreatedUserId = 
            };

            _context.Customers.Add(customer);
            _context.SaveChanges();
            return await Task.FromResult(customerViewModel);

            #endregion
        }

        public async Task<bool> UpdateCustomerAsync(CustomerViewModel customerViewModel)
        {
            #region Update Customer

            var existingCustomer = _context.Customers
                .Where(x => x.Id == customerViewModel.Id)
                .FirstOrDefault();

            if (existingCustomer != null)
            {
                existingCustomer.FullName = customerViewModel.FullName;
                existingCustomer.Email = customerViewModel.Email;
                existingCustomer.CellPhone = customerViewModel.CellPhone;
                existingCustomer.IsEnable = customerViewModel.IsEnable;
                _context.SaveChanges();
            }
            else
            {
                return await Task.FromResult(false);
            }

            return await Task.FromResult(true);

            #endregion
        }
    }
}
