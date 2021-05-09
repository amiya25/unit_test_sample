using Moq;
using unit_test_sample_app.core.BusinessServices.Implementations;
using unit_test_sample_app.core.DataServices.Interfaces;
using unit_test_sample_app.core.Models;
using Xunit;

namespace unit_test_sample_app.test.BusinessServicesTest
{
    public class StudentBusinessServiceTest
    {

        [Fact]
        public void ShouldReturnStudentResponse()
        {
            var _request = new Student
            {
                SudentId = 1,
                FirstName = "Amesh",
                LastName = "Jayamanne",
                MobileNo = "88720324",
                Address = "5 Lorong Melayu"
            };

            var _studentdataserviceMoq = new Mock<IStudentDataService>();
            var _studentBs = new StudentBusinessService(_studentdataserviceMoq.Object);

            var _response = _studentBs.Create(_request);

            Assert.NotNull(_response);
            Assert.Equal(_request.FirstName, _response.FirstName);
            Assert.Equal(_request.LastName, _response.LastName);
            Assert.Equal(_request.MobileNo, _response.MobileNo);
            Assert.Equal(_request.Address, _response.Address);
        }

        [Fact]
        public void ShouldSaveStudent()
        {
            var _request = new Student
            {
                SudentId = 1,
                FirstName = "Amesh",
                LastName = "Jayamanne",
                MobileNo = "88720324",
                Address = "5 Lorong Melayu"
            };

            Student _student = null;
            var _studentdataserviceMoq = new Mock<IStudentDataService>();
            var _studentBs = new StudentBusinessService(_studentdataserviceMoq.Object);
            _studentdataserviceMoq.Setup(x => x.Save(It.IsAny<Student>()))
                .Callback<Student>(student =>
                {
                    _student = student;
                });
            _studentBs.Create(_request);
            _studentdataserviceMoq.Verify(x => x.Save(It.IsAny<Student>()), Times.Once);

            Assert.NotNull(_student);
            Assert.Equal(_request.FirstName, _student.FirstName);
            Assert.Equal(_request.LastName, _student.LastName);
            Assert.Equal(_request.MobileNo, _student.MobileNo);
            Assert.Equal(_request.Address, _student.Address);
        }
    }
}
