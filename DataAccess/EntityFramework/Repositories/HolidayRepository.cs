using DataAccess.EntityFramework.Context;
using DataAccess.EntityFramework.Repositories.Interfaces;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.EntityFramework.Repositories
{
    public class HolidayRepository : GeneralRepository<Holiday>, IHolidayRepository
    {
        public HolidayRepository(DbContext context) : base(context)
        {
        }
    }
}
