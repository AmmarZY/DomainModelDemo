using System;
using System.Collections.Generic;
using System.Text;

namespace DomainWithEF.Data
{
    public abstract class BaseEntity
    {
        public Guid Id { get; set; }
    }
}
