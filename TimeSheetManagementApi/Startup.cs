using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeSheetManagement.BAL.Services;
using TimeSheetManagement.DAL.Data;
using TimeSheetManagement.DAL.Repository.AdminRepo;
using TimeSheetManagement.DAL.Repository.EmployeeRepo;
using TimeSheetManagement.DAL.Repository.ManagerRepo;

namespace TimeSheetManagementApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var connectionStr = Configuration.GetConnectionString("sqlConnection");
            services.AddDbContext<TimeSheetDbContext>(options => options.UseSqlServer(connectionStr));
            services.AddControllers();
            services.AddTransient<IAdminRepository, AdminRepository>();
            services.AddTransient<AdminServices, AdminServices>();

            services.AddTransient<IManagerRepository, ManagerRepository>();
            services.AddTransient<ManagerServices, ManagerServices>();

            services.AddTransient<IEmployeeRepository, EmployeeRepository>();
            services.AddTransient<EmployeeServices, EmployeeServices>();

        }
    

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

