using System;
using System.Collections.Generic;
using System.Text;
using TimeSheetManagement.DAL.Repository.ManagerRepo;
using TimeSheetManagement.Entity.Models;

namespace TimeSheetManagement.BAL.Services
{
    public class ManagerServices
    {
        IManagerRepository _managerRepository;
        public ManagerServices(IManagerRepository managerRepository)
        {
            _managerRepository = managerRepository;
        }
        public Employee AllocateProject(int EmpID)
        {
            return _managerRepository.AllocateProject(EmpID);
        }

        public void AllocateProject(Employee employee)
        {
            _managerRepository.AllocateProject(employee);
        }
        public Employee ChangeEmpPsw(int EmpID)
        {
            return _managerRepository.ChangeEmpPsw(EmpID);
        }

        public void ChangeEmpPsw(Employee employee)
        {
            _managerRepository.ChangeEmpPsw(employee);
        }

        public IEnumerable<Employee> GetEmployees(int MgrID)
        {
            return _managerRepository.GetEmployees(MgrID);
        }

        public TimeSheet GetTimeSheetByID(int EmpID)
        {
            return _managerRepository.GetTimeSheetByID(EmpID);
        }
        public TimeSheet TimeSheetRelease(int TimeSheetID)
        {
            return _managerRepository.TimeSheetRelease(TimeSheetID);
        }
        public void TimeSheetRelease(TimeSheet timeSheet)
        {
            _managerRepository.TimeSheetRelease(timeSheet);
        }
    }
}
