namespace simulyasiya3.Models
{
    public class Project : BaseEntity
    {
        public int DepartmentId { get; set; }
        public string ImageUrl { get; set; }
        public Department Department { get; set; }
    }
}
