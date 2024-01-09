using Nowadays.BLL.Abstract;
using Nowadays.BLL.Concrete;
using Nowadays.DAL.UnitOfWork.Abstract;
using Nowadays.DAL.UnitOfWork.Concrete;

namespace Nowadays.Extension
{
    public static class StartUpDIExtension
    {
        public static void AddServicesDI(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ICompanyService, CompanyService>();
            services.AddScoped<IProjectService, ProjectService>();
            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<IIssueService, IssueService>();
            services.AddScoped<IReportService, ReportService>();


        }
    }
}
