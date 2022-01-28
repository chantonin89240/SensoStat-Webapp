using Xunit;
using Moq;
using SensoStat.WebApplication.Controllers;
using SensoStat.WebApplication.Services.Contracts;
using Microsoft.AspNetCore.Http;

namespace SensoStat.WebApplication.Tests
{
    public class SessionTest
    {
        Mock<ISessionService> mock = new Mock<ISessionService>();
       

        [Fact]
        public void UploadFileTest()
        {
            // Pattern AAA
            // IFormFile file;

            // Arrange
            mock.Setup(e => e.LoadFile(file).Returns(statut));
            SessionController controller = new SessionController(mock.Object);

            // Act
            var result = controller.LoadFile(file);

            // Assert
            Assert.True(statut.Equals(result));

        }
    }
}