using DataAccess.EntityFramework.Context;
using DataAccess.EntityFramework.Repositories.Interfaces;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.EntityFramework.Repositories
{
    public class WeekendRepository : GeneralRepository<Weekend>, IWeekendRepository
    {
        public WeekendRepository(DbContext context) : base(context)
        {
        }
    }
}
