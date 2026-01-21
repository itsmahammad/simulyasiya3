using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace simulyasiya3.Models
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }
        [Required, MaxLength(32)]
        public string Name { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
        public bool IsDeleted { get; set; } = false;
    }
}
