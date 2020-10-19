using Entities.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Models
{
    public class Country : IEntity
    {
        public string Name { get; set; }
    }
}
