namespace Nowadays.Entity.Concrete
{
    public class Project : Base
    {
        public int Id { get; set; }
        public string ProjectName { get; set; }
        public string ProjectDescription { get; set; }

        public int CompanyId { get; set; }
        public Company Company { get; set; }

        public List<Issue> Issues { get; set; }
        public List<EmployeeProject> EmployeeProjects { get; set; }
    }
}
