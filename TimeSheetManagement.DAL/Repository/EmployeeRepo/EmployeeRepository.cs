using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TimeSheetManagement.DAL.Data;
using TimeSheetManagement.Entity.Models;

namespace TimeSheetManagement.DAL.Repository.EmployeeRepo
{
    public class EmployeeRepository : IEmployeeRepository
    {
        TimeSheetDbContext _timeSheetDbContext;
        public EmployeeRepository(TimeSheetDbContext timeSheetDbContext)
        {
            _timeSheetDbContext = timeSheetDbContext;
        }

        public void AddTimeSheet(TimeSheet timeSheet)
        {
            _timeSheetDbContext.timeSheet.Add(timeSheet);
            _timeSheetDbContext.SaveChanges();
        }

        public void DeleteTimeSheet(int TimeSheetID)
        {
            var timeSheet = _timeSheetDbContext.timeSheet.Find(TimeSheetID);
            _timeSheetDbContext.timeSheet.Remove(timeSheet);
            _timeSheetDbContext.SaveChanges();
        }

        public void UpdateTimeSheet(TimeSheet timeSheet)
        {
            _timeSheetDbContext.Entry(timeSheet).State = EntityState.Modified;
            _timeSheetDbContext.SaveChanges();
        }
    }
}
