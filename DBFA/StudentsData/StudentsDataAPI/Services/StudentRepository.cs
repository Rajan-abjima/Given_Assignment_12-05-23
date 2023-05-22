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
        public async Task<StudentData> GetStudentByIdAsync(int id)
        {
            return await _context.StudentsDataTable.FindAsync(id);
        }

        public async Task<StudentData> AddStudentAsync(StudentData studentData)
        {
            _context.StudentsDataTable.Add(studentData);
            await _context.SaveChangesAsync();

            return studentData;
        }

        public async Task<StudentData> DeleteStudentAsync(int id)
        {
            var student = await GetStudentByIdAsync(id);
            if (student == null)
            {
                return student;
            }

            _context.StudentsDataTable.Remove(student);
            await _context.SaveChangesAsync();

            return student;
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
