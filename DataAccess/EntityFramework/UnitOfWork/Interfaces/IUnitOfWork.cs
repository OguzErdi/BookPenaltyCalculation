using DataAccess.EntityFramework.Repositories;
using DataAccess.EntityFramework.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.EntityFramework.UnityOfWork.Interfaces
{
    public interface IUnitOfWork
    {
        ICountryRepository CountryRepository { get; }
        IHolidayRepository HolidayRepository { get; }
        IPenaltyInformationRepository PenaltyInformationRepository { get; }
        IWeekendRepository WeekendRepository { get; }
    }
}
