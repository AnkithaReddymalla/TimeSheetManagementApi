using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TimeSheetManagement.DAL.Data;
using TimeSheetManagement.Entity.Models;

namespace TimeSheetManagement.DAL.Repository.ManagerRepo
{
    public class ManagerRepository : IManagerRepository
    {
        TimeSheetDbContext _timeSheetDbContext;
        public ManagerRepository(TimeSheetDbContext timeSheetDbContext)
        {
            _timeSheetDbContext = timeSheetDbContext;
        }

        public void AllocateProject(Employee employee)
        {
            _timeSheetDbContext.Entry(employee).State = EntityState.Modified;
            _timeSheetDbContext.SaveChanges();
        }

        public void ChangeEmpPsw(Employee employee)
        {
            _timeSheetDbContext.Entry(employee).State = EntityState.Modified;
            _timeSheetDbContext.SaveChanges();
        }

        public IEnumerable<Employee> GetEmployees(int MgrID)
        {
            return _timeSheetDbContext.employee.Where(obj => obj.MgrID == MgrID).ToList();
        }

        public TimeSheet GetTimeSheetByID(int EmpID)
        {
            return _timeSheetDbContext.timeSheet.Find(EmpID);
        }

        public void TimeSheetRelease(TimeSheet timeSheet)
        {
            _timeSheetDbContext.Entry(timeSheet).State = EntityState.Modified;
            _timeSheetDbContext.SaveChanges();
        }
    }
}
