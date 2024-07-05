using Moq;
using Xunit;
using FluentAssertions;
using System.Threading.Tasks;
using domain.Application;
using domain.Infrastructure;
using application.GetStatusCodeService;

namespace test
{
    public class GetStatusCodeServiceTest
    {
        private readonly Mock<ILocalExternalService> _localExternalServiceMock;
        private readonly GetStatusCodeService _getStatusCodeService;

        public GetStatusCodeServiceTest()
        {
            _localExternalServiceMock = new Mock<ILocalExternalService>();
            _getStatusCodeService = new GetStatusCodeService(_localExternalServiceMock.Object);
        }

        [Fact]
        public async Task GetStatusCodeService_ShouldGetStatusCode_WhenCalled()
        {
            // Arrange
            var expectedStatusCode = true;
            _localExternalServiceMock.Setup(service => service.GetStatusCodeAsync()).ReturnsAsync(expectedStatusCode);

            // Act
            var result = await _getStatusCodeService.GetStatusCodeAsync();

            // Assert
            result.Should().Be(expectedStatusCode);
        }
    }
}
