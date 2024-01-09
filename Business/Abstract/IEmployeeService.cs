using Nowadays.DTO.Employee;

namespace Nowadays.BLL.Abstract
{
    public interface IEmployeeService
    {
        Task<bool> EmployeeAdd(AddEmployeeViewModel employee);

        Task<bool> EmployeeRemove(int entityId);

        Task<bool> EmployeeUpdate(EmployeeEditViewModel employee);

    }
}
