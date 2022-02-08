using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using TimeSheetManagement.DAL.Data;
using TimeSheetManagement.Entity.Models;

namespace TimeSheetManagementApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        public IConfiguration _configuration;
        private readonly TimeSheetDbContext _context;

        public TokenController(IConfiguration config, TimeSheetDbContext context)
        {
            _configuration = config;
            _context = context;
        }

        [HttpPost("AdminLogin")]
        public async Task<IActionResult> Post(Employee _employee)
        {

            if (_employee != null && _employee.EmpEmailID != null && _employee.EmpPsw != null)
            {
                var user = await GetEmployee(_employee.EmpEmailID, _employee.EmpPsw);

                if (user != null)
                {
                    //create claims details based on the employee information
                    var claims = new[] {
                    new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                    new Claim("EmpID", user.EmpID.ToString()),
                    new Claim("EmpName", user.EmpName),
                    new Claim("EmpDesignation", user.EmpDesignation),
                    new Claim("EmpEmailID", user.EmpEmailID),
                     new Claim("EmpPhone", user.EmpPhone),
                    new Claim("EmpUserName", user.EmpUserName),
                    new Claim("EmpPsw", user.EmpPsw),
                     new Claim("EmpDOJ", user.EmpDOJ),
                    new Claim("MgrID", user.MgrID.ToString()),
                    new Claim("CurrentProjectID", user.CurrentProjectID.ToString()),
                   };

                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));

                    var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                    var token = new JwtSecurityToken(_configuration["Jwt:Issuer"], _configuration["Jwt:Audience"], claims, expires: DateTime.UtcNow.AddDays(1), signingCredentials: signIn);

                    return Ok(new JwtSecurityTokenHandler().WriteToken(token));
                }
                else
                {
                    return BadRequest("Invalid credentials");
                }
            }
            else
            {
                return BadRequest();
            }
        }

        private async Task<Employee> GetEmployee(string email, string password)
        {
            Employee employee = null;
            var result =  _context.employee.Where(u => u.EmpEmailID == email && u.EmpPsw == password);
            foreach (var item in result)
            {
                employee = new Employee();
                employee.EmpID = item.EmpID;
                employee.EmpName = item.EmpName;
                employee.EmpDesignation = item.EmpDesignation;
                employee.EmpEmailID = item.EmpEmailID;
                employee.EmpPhone = item.EmpPhone;
                employee.EmpUserName = item.EmpUserName;
                employee.EmpPsw = item.EmpPsw;
                employee.EmpDOJ = item.EmpDOJ;
                employee.MgrID = item.MgrID;
                employee.CurrentProjectID = item.CurrentProjectID;

            }
            return employee;

        }
       
    }

}
    

