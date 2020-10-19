using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.EntityFramework.Context
{
    public class BookPenaltyCalculationContext : DbContext
    {
        public BookPenaltyCalculationContext(DbContextOptions<BookPenaltyCalculationContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        public DbSet<Country> Countries { get; set; }
        public DbSet<Holiday> Holidays { get; set; }
        public DbSet<PenaltyInformation> PenaltyInformations { get; set; }
        public DbSet<Weekend> Weekends { get; set; }
    }
}
