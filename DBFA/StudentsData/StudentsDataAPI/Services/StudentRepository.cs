using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using StudentsDataAPI.DbContexts;
using StudentsDataAPI.Entities;
using StudentsDataAPI.Models;
using System.Diagnostics.CodeAnalysis;

namespace StudentsDataAPI.Services
{
    public class StudentRepository : IStudentRepository
    {
        private readonly StudentsDataContext _context;
        private readonly IMapper _mapper;

        public StudentRepository(StudentsDataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
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
            
            _context.StudentsDataTable.Remove(student);
            await _context.SaveChangesAsync();

            return student;
        }
                        
        public async Task<StudentData> UpdateStudentAsync(int id, StudentsDataTable studentsDataTable)
        {
            //var students = _mapper.Map<StudentData>(studentsDataTable);
            //_context.Entry(students).State = EntityState.Modified;

            var studentQuery = await GetStudentByIdAsync(id);
            
            _context.Entry(studentQuery).CurrentValues.SetValues(studentsDataTable);
            await _context.SaveChangesAsync();

            return studentQuery;
        }

        public async Task<StudentData> UpdateStudentPatchAysnc(int id, JsonPatchDocument studentPatch)
        {
            var studentQuery = await GetStudentByIdAsync(id);
            
            studentPatch.ApplyTo(studentQuery);
            await _context.SaveChangesAsync();

            return studentQuery;
        }
    }
}
