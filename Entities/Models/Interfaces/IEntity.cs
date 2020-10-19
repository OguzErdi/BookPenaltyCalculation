using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Models.Interfaces
{
    public abstract class IEntity
    {
        public int Id { get; set; }
        public int IsDeleted { get; set; }
    }
}
