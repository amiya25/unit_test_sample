using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using unit_test_sample_app.core.Models;

namespace unit_test_sample_app.core.DataServices.Interfaces
{
    public interface IStudentDataService
    {
        Task<Student> Save(Student student);
    }
}
