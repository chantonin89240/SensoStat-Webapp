using Xunit;
using Moq;
using SensoStat.WebApplication.Controllers;
using SensoStat.WebApplication.Services.Contracts;
using Microsoft.AspNetCore.Http;
using System.Net;
using System.IO;
using System.Threading.Tasks;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using SensoStat.WebApplication.ViewModels;
using SensoStat.WebApplication.Services;

namespace SensoStat.WebApplication.Tests
{
    public class SessionTest
    {
        Mock<ISessionService> mock = new Mock<ISessionService>();
        Mock<ClientService> mockClientService = new Mock<ClientService>();

        /// <summary>
        /// Test unitaire de la méthode LoadFile()
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task UploadFileTest()
        {
            // Pattern AAA
            var fileMock = new Mock<IFormFile>();
            //Setup mock file using a memory stream
            var content = "code sujet";
            var fileName = "test.pdf";
            var ms = new MemoryStream();
            var writer = new StreamWriter(ms);
            writer.Write(content);
            writer.Flush();
            ms.Position = 0;
            fileMock.Setup(_ => _.OpenReadStream()).Returns(ms);
            fileMock.Setup(_ => _.FileName).Returns(fileName);
            fileMock.Setup(_ => _.Length).Returns(ms.Length);

            var idSession = 100;

            // Arrange

            SessionController controller = new SessionController(mock.Object);
            var file = fileMock.Object;

            // Act
            var result = await controller.LoadFile(idSession, file);

            // Assert
            Assert.IsType<RedirectToActionResult>(result);
            // or 
            // Assert.IsAssignableFrom<RedirectToActionResult>(result);
        }

        /// <summary>
        /// Test unitaire de la méthode LoadFile()
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task UploadEmptyFileTest()
        {
            // Pattern AAA
            var fileMock = new Mock<IFormFile>();

            var idSession = 100;

            // Arrange

            SessionController controller = new SessionController(mock.Object);
            var file = fileMock.Object;

            // Act
            var result = await controller.LoadFile(idSession, file);

            // Assert
            Assert.IsType<RedirectToActionResult>(result);
            // or 
            // Assert.IsAssignableFrom<RedirectToActionResult>(result);
        }

        /// <summary>
        /// Test unitaire de la méthode MessagesToInstructions
        /// </summary>
        [Fact]
        public void MessagesToInstructionsTest()
        {
            var session = new Mock<SessionViewModel>();

            // Arrange
            mock.Setup(_ => _.MessagesToInstructions(session.Object)).Returns(session.Object);
            ISessionService service = new SessionService(mockClientService.Object);

            // Act
            var result = service.MessagesToInstructions(session.Object).Instructions;

            // Assert
            Assert.True(session.Object.Instructions.Equals(result));
        }


        /// <summary>
        /// Méthode générant des Mock de type IFormFile
        /// </summary>
        /// <param name="contentType"></param>
        /// <param name="content"></param>
        /// <returns></returns>
        private IFormFile GetFileMock(string contentType, string content)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(content);

            var file = new FormFile(
                baseStream: new MemoryStream(bytes),
                baseStreamOffset: 0,
                length: bytes.Length,
                name: "Data",
                fileName: "test.csv"
            )
            {
                Headers = new HeaderDictionary(),
                ContentType = contentType
            };

            return file;
        }
    }
}