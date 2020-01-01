using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRM.Data.ViewModels
{
    public class CustomerViewModel
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string CellPhone { get; set; }
        public string Email { get; set; }
        public DateTime CreatedTime { get; set; }
        public Guid CreatedUserId { get; set; }
        public bool IsEnable { get; set; }
        public bool IsSelected { get; set; }
    }
}
