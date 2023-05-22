using System;
using System.Collections.Generic;

namespace StudentsDataAPI.Models
{
    public class StudentsDataTable
    {
        public int RollNo { get; set; }
        public string Name { get; set; } = null!;
        public string? FamilyName { get; set; }
        public string? Address { get; set; }
        public long ContactNumber { get; set; }
    }
}
