using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TimeSheetManagement.Entity.Models;

namespace TimeSheetManagement.DAL.Data
{
   public class TimeSheetDbContext : DbContext
    {
        public TimeSheetDbContext(DbContextOptions<TimeSheetDbContext> options) : base(options)
        {

        }
        public DbSet<Employee> employee { get; set; }
        public DbSet<Project> project { get; set; }
        public DbSet<TimeSheet> timeSheet { get; set; }


    }
}
