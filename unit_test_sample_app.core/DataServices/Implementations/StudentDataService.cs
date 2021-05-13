using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using unit_test_sample_app.core.DataServices.Interfaces;
using unit_test_sample_app.core.Models;

namespace unit_test_sample_app.core.DataServices.Implementations
{
    public class StudentDataService : IStudentDataService
    {
        private readonly StudentDbContext _context;
        public StudentDataService(StudentDbContext context)
        {
            _context = context;
        }

        public async Task<Student> Save(Student student)
        {
            _context.Students.Add(student);
            await _context.SaveChangesAsync();
            _context.Entry(student).GetDatabaseValues();
            return student;
        }
    }
}
