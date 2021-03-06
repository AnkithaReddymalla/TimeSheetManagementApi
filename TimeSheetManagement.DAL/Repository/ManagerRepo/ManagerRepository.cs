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
        public Employee AllocateProject(int EmpID)
        {
            return _timeSheetDbContext.employee.Find(EmpID);
        }

        public void AllocateProject(Employee employee)
        {
            _timeSheetDbContext.Entry(employee).State = EntityState.Modified;
            _timeSheetDbContext.SaveChanges();
        }
        public Employee ChangeEmpPsw(int EmpID)
        {
            return _timeSheetDbContext.employee.Find(EmpID);
        }

       public void ChangeEmpPsw(Employee employee)
        {
            _timeSheetDbContext.Entry(employee).State = EntityState.Modified;
            _timeSheetDbContext.SaveChanges();
        }

        public IEnumerable<Employee> GetEmployees(int EmpID)
        {
            return _timeSheetDbContext.employee.Where(obj => obj.MgrID == EmpID).ToList();
        }

        public TimeSheet GetTimeSheetByID(int EmpID)
        {
            return _timeSheetDbContext.timeSheet.Where(obj => obj.EmpID == EmpID).SingleOrDefault();
        }
        public TimeSheet TimeSheetRelease(int TimeSheetID)
        {
            return _timeSheetDbContext.timeSheet.Find(TimeSheetID);
        }

        public void TimeSheetRelease(TimeSheet timeSheet)
        {
            _timeSheetDbContext.Entry(timeSheet).State = EntityState.Modified;
            _timeSheetDbContext.SaveChanges();
        }
        public Employee ManagerLogin(Employee employee)
        {
            Employee employeeResult = null;
            var result = _timeSheetDbContext.employee.Where(obj => obj.EmpEmailID == employee.EmpEmailID && obj.EmpPsw == employee.EmpPsw).ToList();
            if (result.Count > 0)
            {
                employeeResult = result[0];
            }
            return employeeResult;
        }
       
        IEnumerable<Employee> IManagerRepository.GetManagers()
        {
            
             var result = (from a in  _timeSheetDbContext.employee
             where a.EmpDesignation == "Manager"
             select new Employee { EmpID = a.EmpID, EmpName = a.EmpName }).ToList();
             return result;
        }
    }
}
