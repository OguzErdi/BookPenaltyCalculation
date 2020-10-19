using Business.Managers.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Business.Managers.Interfaces
{
    public interface IPenaltyCalculateService
    {
        PenaltyCalculateModel CalculatePenalty(int countryId, DateTime checkedOutDate, DateTime returnedDate);
    }
}
