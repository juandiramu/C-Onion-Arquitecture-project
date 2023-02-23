using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dealership_Domain
{
    public abstract class Entity<TId> where TId : IComparable, IComparable<TId>
    {
        public TId? Id { get; set; }
        public DateTime? CreationDate { get; set; }
        public bool IsDeleted { get; set; }
        
    }
}
