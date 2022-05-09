using System;
using System.Collections.Generic;

#nullable disable

namespace DataAccessLayer21.Models
{
    public partial class Amazon
    {
        public Amazon()
        {
            Orders = new HashSet<Order>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
