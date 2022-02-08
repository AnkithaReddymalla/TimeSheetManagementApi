using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TimeSheetManagement.Entity.Models;

namespace TimeSheetManagement.UI.Controllers
{
    public class AdminController : Controller
    {
        private IConfiguration _configuration;
        public AdminController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        #region Employee

        public IActionResult AddEmployee()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddEmployee(Employee employee)
        {
            ViewBag.status = "";
            using (HttpClient client = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(employee), Encoding.UTF8, "application/json");
                string endPoint = _configuration["WebApiBaseUrl"] + "Admin/AddEmployee";
                using (var response = await client.PostAsync(endPoint, content))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        ViewBag.status = "Ok";
                        ViewBag.message = "Employee details saved successfully!";
                    }
                    else
                    {
                        ViewBag.status = "Error";
                        ViewBag.message = "Wrong entries!";
                    }
                }
            }
            return View();
        }

        public async Task<IActionResult> GetEmployees()
        {
            IEnumerable<Employee> employeeResult = null;
            using (HttpClient client = new HttpClient())
            {
                string endPoint = _configuration["WebApiBaseUrl"] + "Admin/GetEmployees";
                using (var response = await client.GetAsync(endPoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        employeeResult = JsonConvert.DeserializeObject<IEnumerable<Employee>>(result);
                    }
                }
            }
            return View(employeeResult);
        }

        public async Task<IActionResult> UpdateEmployee(int EmpID)
        {
            Employee employeeResult = null;
            using (HttpClient client = new HttpClient())
            {
                string endPoint = _configuration["WebApiBaseUrl"] + "Admin/UpdateEmployee?EmpID="+EmpID;
                using (var response = await client.GetAsync(endPoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        employeeResult = JsonConvert.DeserializeObject<Employee>(result);
                    }
                }
            }
            return View(employeeResult);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateEmployee(Employee employee)
        {
            ViewBag.status = "";
            using (HttpClient client = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(employee), Encoding.UTF8, "application/json");
                string endPoint = _configuration["WebApiBaseUrl"] + "Admin/UpdateEmployee";
                using (var response = await client.PutAsync(endPoint, content))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        ViewBag.status = "Ok";
                        ViewBag.message = "Employee details Updated successfully!";
                    }
                    else
                    {
                        ViewBag.status = "Error";
                        ViewBag.message = "Wrong entries!";
                    }
                }
            }
            return View();

        }

        public async Task<IActionResult> AssignManager(int EmpID)
        {
            Employee employeeResult = null;
            using (HttpClient client = new HttpClient())
            {
                string endPoint = _configuration["WebApiBaseUrl"] + "Admin/AssignManager?EmpID=" + EmpID;
                using (var response = await client.GetAsync(endPoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        employeeResult = JsonConvert.DeserializeObject<Employee>(result);
                    }
                }
            }
            return View(employeeResult);
        }

        [HttpPost]
        public async Task<IActionResult> AssignManager(Employee employee)
        {
            ViewBag.status = "";
            using (HttpClient client = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(employee), Encoding.UTF8, "application/json");
                string endPoint = _configuration["WebApiBaseUrl"] + "Admin/AssignManager";
                using (var response = await client.PutAsync(endPoint, content))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        ViewBag.status = "Ok";
                        ViewBag.message = "Manager Assigned successfully!";
                    }
                    else
                    {
                        ViewBag.status = "Error";
                        ViewBag.message = "Wrong entries!";
                    }
                }
            }
            return View();

        }

        public async Task<IActionResult> DeleteEmployee(int EmpID)
        {
            ViewBag.status = "";
            using (HttpClient client = new HttpClient())
            {
               
                string endPoint = _configuration["WebApiBaseUrl"] + "Admin/DeleteEmployee?EmpID="+EmpID;
                using (var response = await client.DeleteAsync(endPoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        ViewBag.status = "Ok";
                        ViewBag.message = "Employee details Deleted successfully!";
                    }
                    else
                    {
                        ViewBag.status = "Error";
                        ViewBag.message = "Wrong entries!";
                    }
                }
            }
            return View();

        }
        #endregion

        #region Project

        public IActionResult AddProject()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddProject(Project project)
        {
            ViewBag.status = "";
            using (HttpClient client = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(project), Encoding.UTF8, "application/json");
                string endPoint = _configuration["WebApiBaseUrl"] + "Admin/AddProject";
                using (var response = await client.PostAsync(endPoint, content))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        ViewBag.status = "Ok";
                        ViewBag.message = "Project details saved successfully!";
                    }
                    else
                    {
                        ViewBag.status = "Error";
                        ViewBag.message = "Wrong entries!";
                    }
                }
            }
            return View();
        }

        public async Task<IActionResult> GetProjects()
        {
            IEnumerable<Project> projectResult = null;
            using (HttpClient client = new HttpClient())
            {
                string endPoint = _configuration["WebApiBaseUrl"] + "Admin/GetProjects";
                using (var response = await client.GetAsync(endPoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        projectResult = JsonConvert.DeserializeObject<IEnumerable<Project>>(result);
                    }
                }
            }
            return View(projectResult);
        }

        public async Task<IActionResult> UpdateProject(int ProjectID)
        {
            Project projectResult = null;
            using (HttpClient client = new HttpClient())
            {
                string endPoint = _configuration["WebApiBaseUrl"] + "Admin/UpdateProject?ProjectID=" + ProjectID;
                using (var response = await client.GetAsync(endPoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        projectResult = JsonConvert.DeserializeObject<Project>(result);
                    }
                }
            }
            return View(projectResult);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateProject(Project project)
        {
            ViewBag.status = "";
            using (HttpClient client = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(project), Encoding.UTF8, "application/json");
                string endPoint = _configuration["WebApiBaseUrl"] + "Admin/UpdateProject";
                using (var response = await client.PutAsync(endPoint, content))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        ViewBag.status = "Ok";
                        ViewBag.message = "Project details Updated successfully!";
                    }
                    else
                    {
                        ViewBag.status = "Error";
                        ViewBag.message = "Wrong entries!";
                    }
                }
            }
            return View();

        }

        public async Task<IActionResult> DeleteProject(int ProjectID)
        {
            ViewBag.status = "";
            using (HttpClient client = new HttpClient())
            {

                string endPoint = _configuration["WebApiBaseUrl"] + "Admin/DeleteProject?ProjectID=" + ProjectID;
                using (var response = await client.DeleteAsync(endPoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        ViewBag.status = "Ok";
                        ViewBag.message = "Project details Deleted successfully!";
                    }
                    else
                    {
                        ViewBag.status = "Error";
                        ViewBag.message = "Wrong entries!";
                    }
                }
            }
            return View();

        }

      #endregion

    }
}
