using System;
using System.Collections.Generic;
using System.Text;
using TimeSheetManagement.Entity.Models;

namespace TimeSheetManagement.DAL.Repository.ManagerRepo
{
   public interface IManagerRepository
    {
        TimeSheet GetTimeSheetByID(int EpmID);
        TimeSheet TimeSheetRelease(int TimeSheetID);
        void TimeSheetRelease(TimeSheet timeSheet);
        IEnumerable<Employee> GetEmployees(int MgrID);
        Employee ChangeEmpPsw(int EmpID);
        void ChangeEmpPsw(Employee employee);
        Employee AllocateProject(int EmpID);
        void AllocateProject(Employee employee);
        Employee ManagerLogin(Employee employee);
    }
}
