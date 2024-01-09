namespace Nowadays.Entity.Concrete
{
    public class EmployeeProject : Base
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }

        public int ProjectId { get; set; }
        public Project Project { get; set; }
    }
}
