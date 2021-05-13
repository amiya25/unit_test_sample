using System;
using System.Collections.Generic;
using System.Text;
using unit_test_sample_app.core.BusinessServices.Interfaces;
using unit_test_sample_app.core.DataServices.Interfaces;
using unit_test_sample_app.core.Models;

namespace unit_test_sample_app.core.BusinessServices.Implementations
{
    public class StudentBusinessService : IStudentBusinessService
    {
        private readonly IStudentDataService _studentDataService;

        public StudentBusinessService(IStudentDataService studentDataService)
        {
            _studentDataService = studentDataService;
        }
        public Student Create(Student request)
        {

           var _response = _studentDataService.Save(new Student
            {
                SudentId = request.SudentId,
                FirstName = request.FirstName,
                LastName = request.LastName,
                MobileNo = request.MobileNo,
                Address = request.Address
            }).GetAwaiter().GetResult();

            return _response;
        }
    }
}
