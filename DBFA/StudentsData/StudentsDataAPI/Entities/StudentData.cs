using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentsDataAPI.Entities
{
    public class StudentData
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RollNo { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(50)]
        public string? FamilyName { get; set; }
        [MaxLength(200)]
        public string? Address { get; set; }
        [Required]
        public long ContactNumber { get; set; }

        public StudentData(string name)
        {
            Name = name;
        }
    
    }
}
