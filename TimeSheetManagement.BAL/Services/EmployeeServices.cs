using System;
using System.Collections.Generic;
using System.Text;
using TimeSheetManagement.DAL.Repository.EmployeeRepo;
using TimeSheetManagement.Entity.Models;

namespace TimeSheetManagement.BAL.Services
{
   public class EmployeeServices
    {
        IEmployeeRepository _employeeRepository;
        public EmployeeServices(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public void AddTimeSheeet(TimeSheet timeSheet)
        {
            _employeeRepository.AddTimeSheeet(timeSheet);
        }
        public void DeleteTimeSheet(int TimeSheetID)
        {
            _employeeRepository.DeleteTimeSheet(TimeSheetID);
        }
        public void UpdateTimeSheet(TimeSheet timeSheet)
        {
            _employeeRepository.UpdateTimeSheet(timeSheet);
        }
    }
}
