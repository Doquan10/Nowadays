using Microsoft.AspNetCore.Mvc;
using Nowadays.BLL.Abstract;

namespace Nowadays.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly IReportService _reportService;

        public ReportController(IReportService reportService)
        {
            _reportService = reportService;
        }

        [HttpGet("GetReport")]
        public IActionResult Get()
        {
            var reports = _reportService.GetAll();

            return Ok(reports);
        }
    }
}
