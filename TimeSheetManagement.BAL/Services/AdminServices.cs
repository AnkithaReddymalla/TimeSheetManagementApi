using System;
using System.Collections.Generic;
using System.Text;
using TimeSheetManagement.DAL.Repository.AdminRepo;
using TimeSheetManagement.Entity.Models;

namespace TimeSheetManagement.BAL.Services
{
    public class AdminServices
    {
        IAdminRepository _adminRepository;
        public AdminServices(IAdminRepository adminRepository)
        {
            _adminRepository = adminRepository;
        }

        #region Employee

        public void AddEmployee(Employee employee)
        {
            _adminRepository.AddEmployee(employee);
        }
        public Employee UpdateEmployee(int EmpID)
        {
            return _adminRepository.UpdateEmployee(EmpID);
        }
        public void UpdateEmployee(Employee employee)
        {
            _adminRepository.UpdateEmployee(employee);
        }
        public void DeleteEmployee(int EmpID)
        {
            _adminRepository.DeleteEmployee(EmpID);
        }
        public Employee GetEmployeeByID(int EmpID)
        {
            return _adminRepository.GetEmployeeByID(EmpID);

        }
        public IEnumerable<Employee> GetEmployees()
        {
            return _adminRepository.GetEmployees();
        }

        public Employee AssignManager(int EmpID)
        {
            return _adminRepository.AssignManager(EmpID);
        }

        public void AssignManager(Employee employee)
        {
            _adminRepository.AssignManager(employee);
        }


        #endregion

        #region Project
        public void AddProject(Project project)
        {
            _adminRepository.AddProject(project);
        }
        public Project UpdateProject(int ProjectID)
        {
            return _adminRepository.UpdateProject(ProjectID);
        }
        public void UpdateProject(Project project)
        {
            _adminRepository.UpdateProject(project);
        }
        public void DeleteProject(int ProjectID)
        {
            _adminRepository.DeleteProject(ProjectID);
        }
        public Project GetProjectByID(int ProjectID)
        {
            return _adminRepository.GetProjectByID(ProjectID);

        }
        public IEnumerable<Project> GetProjects()
        {
            return _adminRepository.GetProjects();
        }
        #endregion
    }
}
