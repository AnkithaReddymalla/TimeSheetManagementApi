using System;
using System.Collections.Generic;
using System.Text;
using TimeSheetManagement.Entity.Models;

namespace TimeSheetManagement.DAL.Repository.ManagerRepo
{
   public interface IManagerRepository
    {
        TimeSheet GetTimeSheetByID(int EpmID);
        void TimeSheetRelease(TimeSheet timeSheet);
        IEnumerable<Employee> GetEmployees(int MgrID);
        void ChangeEmpPsw(Employee employee);
        void AllocateProject(Employee employee);
    }
}
