using Microsoft.AspNetCore.Mvc;
using Nowadays.BLL.Abstract;
using Nowadays.DTO.Employee;
using TcValid;

namespace Nowadays.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpPost("AddEmployee")]
        public async Task<IActionResult> AddEmployee(AddEmployeeViewModel employee)
        {
            var client = new TcValid.KPSPublicSoapClient(KPSPublicSoapClient.EndpointConfiguration.KPSPublicSoap);
            var response = await client.TCKimlikNoDogrulaAsync(Convert.ToInt64(employee.TcNo), employee.Name, employee.Surname, employee.BirthYear);
            var result =response.Body.TCKimlikNoDogrulaResult;

            if(result is false)
            {
                throw new Exception("Kullanıcı bilgileri hatalı");
            }

            await _employeeService.EmployeeAdd(employee);
            return Ok();
        }

        [HttpPut("EditEmployee")]
        public async Task<IActionResult> EditEmployee(EmployeeEditViewModel employee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            //Diğer bilgiler uniq olduğu için sadece kullanıcının şirketini güncelleme yaptım.
            await _employeeService.EmployeeUpdate(employee);


            return Ok();
        }

        [HttpDelete("DeleteEmployee")]
        public async Task<IActionResult> DeleteEmployee(int entityId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            await _employeeService.EmployeeRemove(entityId);
            return Ok();
        }
    }
}
