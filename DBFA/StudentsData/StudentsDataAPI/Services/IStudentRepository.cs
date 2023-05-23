using Microsoft.AspNetCore.JsonPatch;
using StudentsDataAPI.Entities;
using StudentsDataAPI.Models;

namespace StudentsDataAPI.Services
{
    public interface IStudentRepository
    {
        Task<IEnumerable<StudentData>> GetStudentsAsync();
        Task<StudentData> GetStudentByIdAsync(int id);
        Task<StudentData> AddStudentAsync(StudentData studentData);
        Task<StudentData> DeleteStudentAsync(int id);
        Task<StudentData> UpdateStudentAsync(int id, StudentsDataTable studentsDataTable);
        Task<StudentData> UpdateStudentPatchAysnc(int id, JsonPatchDocument studentPatch);
    }
}
