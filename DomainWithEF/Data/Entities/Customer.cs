using System;
using System.Collections.Generic;
using System.Text;

namespace DomainWithEF.Data.Entities
{
    public class Customer : BaseEntity
    {
        public string CustomerName { get; set; }
        public decimal Balance { get; set; }
        public decimal LastPayment { get; set; }
        public bool IsDeleted { get; set; }
    }
}