using Microsoft.AspNetCore.JsonPatch;
using StudentsDataAPI.Entities;

namespace StudentsDataAPI.Services
{
    public interface IStudentRepository
    {
        Task<StudentData> UpdateStudentPatchAysnc(int id, JsonPatchDocument studentPatch);
    }
}
