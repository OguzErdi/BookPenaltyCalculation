using Business.Managers.Interfaces;
using Business.Managers.Models;
using DataAccess.EntityFramework.Repositories.Interfaces;
using DataAccess.EntityFramework.UnityOfWork.Interfaces;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Business.Managers
{
    public class PenaltyCalculateManager : IPenaltyCalculateService
    {
        private readonly IUnitOfWork _unitOfWork;
        private PenaltyInformation _penaltyInformation;
        private List<Weekend> _weekends;
        private List<Holiday> _holidays;

        public PenaltyCalculateManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public PenaltyCalculateModel CalculatePenalty(int countryId, DateTime checkedOutDate, DateTime returnedDate)
        {
            getPenaltyPrice(countryId);
            getWeekends(countryId);
            getHolidays(countryId);

            int bussinessDayCount = calculateBusinessDay(checkedOutDate, returnedDate);
            decimal penaltyPrice = calculatePenaltyPrice(bussinessDayCount);

            PenaltyCalculateModel penaltyCalculateModel = generateModel(bussinessDayCount, penaltyPrice);

            return penaltyCalculateModel;
        }

        private PenaltyCalculateModel generateModel(int bussinessDayCount, decimal penaltyPrice)
        {
            PenaltyCalculateModel penaltyCalculateModel = new PenaltyCalculateModel();
            penaltyCalculateModel.BusinessDayCount = bussinessDayCount;
            penaltyCalculateModel.PenaltyPrice = penaltyPrice;
            penaltyCalculateModel.PenaltyCurrencyCode = _penaltyInformation.CurrencyCode;
            return penaltyCalculateModel;
        }

        private void getHolidays(int countryId)
        {
            _holidays = _unitOfWork.HolidayRepository.GetList(x => x.CountryId == countryId).ToList();
        }

        private void getWeekends(int countryId)
        {
            _weekends = _unitOfWork.WeekendRepository.GetList(x => x.CountryId == countryId).ToList();
        }

        private void getPenaltyPrice(int countryId)
        {
            _penaltyInformation = _unitOfWork.PenaltyInformationRepository.Get(x => x.CountryId == countryId);
        }

        private decimal calculatePenaltyPrice(int bussinessDayCount)
        {
            var lateDayCount = 0;
            if (bussinessDayCount > _penaltyInformation.DayLimit)
            {
                lateDayCount = bussinessDayCount - _penaltyInformation.DayLimit;
            }

            var price = _penaltyInformation.AmountOfPerDay * lateDayCount;
            return price;
        }

        private int calculateBusinessDay(DateTime checkedOutDate, DateTime returnedDate)
        {
            var tempDate = checkedOutDate.Date;
            int bussinessDayCount = 0;

            while (tempDate <= returnedDate.Date)
            {
                var isHoliday = _holidays.Select(x => x.Time).ToList().Contains(tempDate);
                var isWeekend = _weekends.Select(x => x.Day).ToList().Contains(tempDate.DayOfWeek);

                if (!isHoliday && !isWeekend)
                {
                    bussinessDayCount++;
                }

                tempDate = tempDate.AddDays(1);
            }

            return bussinessDayCount;
        }
    }
}
