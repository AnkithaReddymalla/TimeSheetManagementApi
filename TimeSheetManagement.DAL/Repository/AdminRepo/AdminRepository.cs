using System;
using System.Collections.Generic;
using System.Text;
using TimeSheetManagement.DAL.Data;
using TimeSheetManagement.Entity.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace TimeSheetManagement.DAL.Repository.AdminRepo
{
    public class AdminRepository : IAdminRepository
    {
        
         TimeSheetDbContext _timeSheetDbContext;
         public AdminRepository(TimeSheetDbContext timeSheetDbContext)
         {
             _timeSheetDbContext = timeSheetDbContext;
         }

        #region Employee

        public void AddEmployee(Employee employee)
         {
             _timeSheetDbContext.employee.Add(employee);
             _timeSheetDbContext.SaveChanges();
         }

         public void DeleteEmployee(int EmpID)
         {
             var employee = _timeSheetDbContext.employee.Find(EmpID);
             _timeSheetDbContext.employee.Remove(employee);
             _timeSheetDbContext.SaveChanges();

         }

         public Employee GetEmployeeByID(int EmpID)
         {
             return _timeSheetDbContext.employee.Find(EmpID);
         }

         public IEnumerable<Employee> GetEmployees()
         {
             return _timeSheetDbContext.employee.ToList();
         }

         public void UpdateEmployee(Employee employee)
         {
             _timeSheetDbContext.Entry(employee).State = EntityState.Modified;
             _timeSheetDbContext.SaveChanges();
         }

        #endregion

       
        #region Project

        public void AddProject(Project project)
        {
            _timeSheetDbContext.project.Add(project);
            _timeSheetDbContext.SaveChanges();
        }

        public void DeleteProject(int ProjectID)
        {
            var project = _timeSheetDbContext.project.Find(ProjectID);
            _timeSheetDbContext.project.Remove(project);
            _timeSheetDbContext.SaveChanges();

        }

        public Project GetProjectByID(int ProjectID)
        {
            return _timeSheetDbContext.project.Find(ProjectID);
        }

        public IEnumerable<Project> GetProjects()
        {
            return _timeSheetDbContext.project.ToList();
        }

        public void UpdateProject(Project project)
        {
            _timeSheetDbContext.Entry(project).State = EntityState.Modified;
            _timeSheetDbContext.SaveChanges();
        }
        #endregion

    }
}
