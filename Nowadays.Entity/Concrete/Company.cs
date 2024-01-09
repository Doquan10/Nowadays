namespace Nowadays.Entity.Concrete
{
    public class Company : Base
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }

        public List<Project> Projects { get; set; }
        public List<Employee> Employees { get; set; }
    }
}
