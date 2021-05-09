using System;
using System.Collections.Generic;
using System.Text;
using unit_test_sample_app.core.DataServices.Interfaces;
using unit_test_sample_app.core.Models;

namespace unit_test_sample_app.core.BusinessServices.Implementations
{
    public class StudentBusinessService
    {
        private readonly IStudentDataService _studentDataService;

        public StudentBusinessService(IStudentDataService studentDataService)
        {
            _studentDataService = studentDataService;
        }
        public Student Create(Student request)
        {

            _studentDataService.Save(new Student
            {
                SudentId = request.SudentId,
                FirstName = request.FirstName,
                LastName = request.LastName,
                MobileNo = request.MobileNo,
                Address = request.Address
            });

            var _response = new Student
            {
                SudentId = 1,
                FirstName = "Amesh",
                LastName = "Jayamanne",
                MobileNo = "88720324",
                Address = "5 Lorong Melayu"
            };

            return _response;
        }
    }
}
