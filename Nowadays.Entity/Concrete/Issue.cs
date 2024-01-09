namespace Nowadays.Entity.Concrete
{
    public class Issue : Base
    {
        public int Id { get; set; }
        public string IssueName { get; set; }
        public int ProjectId { get; set; }
        public Project Project { get; set; }

        public List<IssueEmployee> IssueEmployees { get; set; }
    }
}
