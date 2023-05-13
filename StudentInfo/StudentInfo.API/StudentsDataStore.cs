using StudentInfo.API.Controllers;
using StudentInfo.API.Models;

namespace StudentInfo.API
{
    public class StudentsDataStore
    {
        public List<StudentDto> Students { get; set; }
        public static StudentsDataStore Current { get; } = new StudentsDataStore();
        public StudentsDataStore()
        {
            Students = new List<StudentDto>()
            {
                new StudentDto()
                {
                    RollNo = 1,
                    Name = "Rahul",
                    FamilyName = "Kumar",
                    Address = "123, Villash Road, Jagatpura, 341256",
                    ContactNumber = 8948098326
                },
                new StudentDto()
                {
                    RollNo = 2,
                    Name = "Raju",
                    FamilyName = "Rastogi",
                    Address = "211, Rajmargh Road, Jagatpura, 341256",
                    ContactNumber = 8948098326
                },
                new StudentDto()
                {
                    RollNo = 3,
                    Name = "Rajan",
                    FamilyName = "Bakolia",
                    Address = "287, Aligarh University, Jagatpura, 341256",
                    ContactNumber = 8948098326
                },
                new StudentDto()
                {
                    RollNo = 4,
                    Name = "Preeti",
                    FamilyName = "Tanwar",
                    Address = "346, JLN Marg, Jagatpura, 341256",
                    ContactNumber = 8948098326
                },
                new StudentDto()
                {
                    RollNo = 5,
                    Name = "Gurmeet",
                    FamilyName = "Singh",
                    Address = "536, Alligarh University, Jagatpura, 341256",
                    ContactNumber = 8948098326
                },
                new StudentDto()
                {
                    RollNo = 5,
                    Name = "Asif",
                    FamilyName = "Khan",
                    Address = "536,  Narayanpuri, Jagatpura, 341256",
                    ContactNumber = 8948098326
                }
            };
        }
    }
}
