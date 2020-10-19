using Entities.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Models
{
    public class PenaltyInformation : IEntity
    {
        [Column(TypeName = "Money")]
        public decimal AmountOfPerDay { get; set; }
        public int DayLimit { get; set; }
        public string CurrencyCode { get; set; }
        public int CountryId { get; set; }
        public Country Country { get; set; }
    }
}
