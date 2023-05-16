using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace StudentsDataAPI.Entities
{
    public class StudentData
    {
        [Key]
        public int RollNo { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(50)]
        [Unicode (false)]
        public string? FamilyName { get; set; }
        [MaxLength(200)]
        [Unicode (false)]
        public string? Address { get; set; }
        [Required]
        [MinLength(10), MaxLength(10)]
        public long ContactNumber { get; set; }

        public StudentData(string name)
        {
            Name = name;
        }
    }
}
