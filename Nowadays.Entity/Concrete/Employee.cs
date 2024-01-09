namespace Nowadays.Entity.Concrete
{
    public class Employee : Base
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public short BirthYear { get; set; }
        public long TcNo { get; set; }
        public int CompanyId { get; set; }

        public Company Company { get; set; }
        public List<IssueEmployee> IssueEmployees { get; set; }
        public List<EmployeeProject> EmployeeProjects { get; set; }
    }
}
