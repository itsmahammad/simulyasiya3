namespace simulyasiya3.Models
{
    public class Department : BaseEntity
    {
        public ICollection<Project> Projects { get; set; } = new List<Project>();
    }
}
