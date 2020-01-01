using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRM.Data
{
    public class Customer
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string CellPhone { get; set; }
        public string Email { get; set; }
        public DateTime CreatedTime { get; set; }
        public Guid CreatedUserId { get; set; }
        public bool IsEnable { get; set; }

    }
}
