namespace Nowadays.Entity.Concrete
{
    public class IssueEmployee : Base
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }

        public int IssueId { get; set; }
        public Issue Issue { get; set; }
    }
}
