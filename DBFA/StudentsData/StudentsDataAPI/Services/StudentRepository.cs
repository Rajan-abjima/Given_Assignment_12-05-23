using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using StudentsDataAPI.DbContexts;
using StudentsDataAPI.Entities;
using StudentsDataAPI.Models;

namespace StudentsDataAPI.Services
{
    public class StudentRepository : IStudentRepository
    {
        private readonly StudentsDataContext _context;

        public StudentRepository(StudentsDataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<StudentData>> GetStudentsAsync()
        {
            return await _context.StudentsDataTable.ToListAsync();
        }

        public Task<StudentData> AddStudentAsync(StudentData studentData)
        {
            throw new NotImplementedException();
        }

        public Task<StudentData> DeleteStudentAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<StudentData> GetStudentByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
                
        public Task<StudentData> UpdateStudentAsync(int id, StudentData studentData)
        {
            throw new NotImplementedException();
        }

        public Task<StudentData> UpdateStudentPatchAysnc(int id, JsonPatchDocument studentPatch)
        {
            throw new NotImplementedException();
        }
    }
}
