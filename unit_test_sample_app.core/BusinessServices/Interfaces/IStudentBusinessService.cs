using System;
using System.Collections.Generic;
using System.Text;
using unit_test_sample_app.core.Models;

namespace unit_test_sample_app.core.BusinessServices.Interfaces
{
    public interface IStudentBusinessService
    {
        Student Create(Student request);
    }
}
