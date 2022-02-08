using System;
using System.Collections.Generic;
using System.Text;
using TimeSheetManagement.Entity.Models;

namespace TimeSheetManagement.DAL.Repository.EmployeeRepo
{
   public interface IEmployeeRepository
    {
        void AddTimeSheet(TimeSheet timeSheet);
        TimeSheet UpdateTimeSheet(int TimeSheetID);
        void UpdateTimeSheet(TimeSheet timeSheet);
        void DeleteTimeSheet(int TimeSheedID);
       
    }
}
