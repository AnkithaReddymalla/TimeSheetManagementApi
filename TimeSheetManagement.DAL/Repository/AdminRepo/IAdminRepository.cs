using System;
using System.Collections.Generic;
using System.Text;
using TimeSheetManagement.Entity.Models;

namespace TimeSheetManagement.DAL.Repository.AdminRepo
{
    public  interface IAdminRepository
    {
        
       #region Employee

        void AddEmployee(Employee employee);
        void UpdateEmployee(Employee employee);
        void DeleteEmployee(int EmpID);
        Employee GetEmployeeByID(int EmpID);
        IEnumerable<Employee> GetEmployees();

        #endregion

        #region Project

        void AddProject(Project project);
        void UpdateProject(Project project);
        void DeleteProject(int ProjectID);
        Project GetProjectByID(int ProjectID);
        IEnumerable<Project> GetProjects();

        #endregion

        


    }
}
