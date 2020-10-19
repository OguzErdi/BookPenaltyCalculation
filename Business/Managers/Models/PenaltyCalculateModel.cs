using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Managers.Models
{
    public class PenaltyCalculateModel
    {
        public int BusinessDayCount { get; set; }
        public decimal PenaltyPrice { get; set; }
        public string PenaltyCurrencyCode { get; internal set; }
    }
}
