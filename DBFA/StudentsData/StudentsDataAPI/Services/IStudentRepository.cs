using Microsoft.AspNetCore.JsonPatch;
using StudentsDataAPI.Entities;

namespace StudentsDataAPI.Services
{
    public interface IStudentRepository
    {
        Task<IEnumerable<StudentData>> GetStudentsAsync();
        Task<StudentData> GetStudentByIdAsync(int id);
        Task<StudentData> AddStudentAsync(StudentData studentData);
        Task<StudentData> DeleteStudentAsync(int id);
        Task<StudentData> UpdateStudentAsync(int id, StudentData studentData);
        Task<StudentData> UpdateStudentPatchAysnc(int id, JsonPatchDocument studentPatch);
    }
}
