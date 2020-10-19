using Entities.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Models
{
    public class Weekend : IEntity
    {
        public DayOfWeek Day { get; set; }
        public int CountryId { get; set; }
        public Country Country { get; set; }
    }

}
