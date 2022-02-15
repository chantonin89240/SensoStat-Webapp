using Xunit;
using Moq;
using SensoStat.WebApplication.Controllers;
using SensoStat.WebApplication.Services.Contracts;
using Microsoft.AspNetCore.Http;
using System.Net;
using System.IO;

namespace SensoStat.WebApplication.Tests
{
    public class SessionTest
    {
        //Mock<ISessionService> mock = new Mock<ISessionService>();
       

        [Fact]
        public void UploadFileTest()
        {
            // Pattern AAA
            var reader = new StreamReader(File.OpenRead(@"Assets/test.csv"));
            bool status;

            // Arrange
            //mock.Setup(e => e.LoadFile(reader).Returns(status));
            //SessionController controller = new SessionController(mock.Object);

            // Act
            //var result = controller.LoadFile(file);

            // Assert
            //Assert.True(status.Equals(result));

        }
    }
}