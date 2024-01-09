using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nowadays.DTO.Employee
{
    public class AddEmployeeViewModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public short BirthYear { get; set; }
        public long TcNo { get; set; }
        public int CompanyId { get; set; }
    }
}
