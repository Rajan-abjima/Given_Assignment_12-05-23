namespace StudentInfo.API.Models
{
    public class StudentDto
    {
        public int RollNo { get; set; }

        public string Name { get; set; } = string.Empty;

        public string? FamilyName { get; set; }

        public string? Address { get; set; }

        public int ContactNumber { get; set; }
    }
}