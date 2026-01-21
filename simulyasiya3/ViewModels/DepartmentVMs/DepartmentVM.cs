using Microsoft.Build.Construction;

namespace simulyasiya3.ViewModels.DepartmentVMs
{
    public class DepartmentVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Created { get; set; }
        public int Projects { get; set; }
    }
}
