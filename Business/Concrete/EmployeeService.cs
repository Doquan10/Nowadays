using Nowadays.BLL.Abstract;
using Nowadays.DAL.UnitOfWork.Abstract;
using Nowadays.DTO.Employee;
using Nowadays.Entity.Concrete;

namespace Nowadays.BLL.Concrete
{
    public class EmployeeService : IEmployeeService
    {
        public IUnitOfWork _unitOfWork;

        public EmployeeService(IUnitOfWork unitOfWork)
        {
              _unitOfWork = unitOfWork;
        }

        public async Task<bool> EmployeeAdd(AddEmployeeViewModel project)
        {
            var checkCompany = _unitOfWork.CompanyRepository.GetByIdAsync(project.CompanyId);

            if(checkCompany == null) 
                throw new NotImplementedException("Şirket Bulunamadı");

            var addEmployee = new Employee
            {
                CompanyId = project.CompanyId,
                Name = project.Name,
                Surname = project.Surname,
                TcNo = project.TcNo,
                BirthYear = project.BirthYear
            };

             await _unitOfWork.EmployeeRepository.InsertAsync(addEmployee);
             await _unitOfWork.CompleteAsync();

            return true;
        }

        public async Task<bool> EmployeeRemove(int entityId)
        {
            var item = await _unitOfWork.EmployeeRepository.GetByIdAsync(entityId);
            if(item == null)
                throw new Exception("Kullanıcı bulunamadı");
            await _unitOfWork.EmployeeRepository.Delete(item);
            await _unitOfWork.CompleteAsync();
            return true;
        }

        public async Task<bool> EmployeeUpdate(EmployeeEditViewModel employee)
        {
            var editEmployee = await _unitOfWork.EmployeeRepository.GetByIdAsync(employee.Id);

            var checkCompany = _unitOfWork.CompanyRepository.GetByIdAsync(employee.CompanyId);

            if (checkCompany is null)
            {
                throw new Exception("Şirket Bulunamadı"); //Hata gelmiyor tekrar bak
            }
                

            if (editEmployee is null)
            {
                throw new Exception("Kullanıcı bulunamadı");
            }

            editEmployee.CompanyId = employee.CompanyId;

            await _unitOfWork.EmployeeRepository.UpdateAsync(editEmployee);
            await _unitOfWork.CompleteAsync();

            return true;
        }
        
    }
}
