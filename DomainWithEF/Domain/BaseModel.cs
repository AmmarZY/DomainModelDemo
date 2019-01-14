using System;
using System.Collections.Generic;
using System.Text;

namespace DomainWithEF.Domain
{
    public abstract class BaseModel
    {
        public Guid Id { get; protected set; }
    }
}
