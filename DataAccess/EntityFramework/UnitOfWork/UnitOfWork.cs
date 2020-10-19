using DataAccess.EntityFramework.Context;
using DataAccess.EntityFramework.Repositories;
using DataAccess.EntityFramework.Repositories.Interfaces;
using DataAccess.EntityFramework.UnityOfWork.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.EntityFramework.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BookPenaltyCalculationContext _context;

        private CountryRepository countryRepository;
        private HolidayRepository holidayRepository;
        private PenaltyInformationRepository penaltyInformationRepository;
        private WeekendRepository weekendRepository;
        public UnitOfWork(BookPenaltyCalculationContext bookPenaltyCalculationContext)
        {
            _context = bookPenaltyCalculationContext;
        }

        public ICountryRepository CountryRepository => this.countryRepository ?? (this.countryRepository = new CountryRepository(_context));
        public IHolidayRepository HolidayRepository => this.holidayRepository ?? (this.holidayRepository = new HolidayRepository(_context));
        public IPenaltyInformationRepository PenaltyInformationRepository => this.penaltyInformationRepository ?? (this.penaltyInformationRepository = new PenaltyInformationRepository(_context));
        public IWeekendRepository WeekendRepository => this.weekendRepository ?? (this.weekendRepository = new WeekendRepository(_context));


        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }

}
