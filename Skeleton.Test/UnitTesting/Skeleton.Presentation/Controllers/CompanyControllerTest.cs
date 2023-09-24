using Microsoft.AspNetCore.Mvc;
using Moq;
using Skeleton.Abstraction;
using Skeleton.Presentation.Controllers;
using Skeleton.Service.Abstraction;
using Skeleton.Shared.DTOs;
using Skeleton.Test.Attributes;

namespace Skeleton.Test.UnitTesting.Skeleton.Presentation.Controllers
{
    public class CompanyControllerTest
    {
        [Theory]
        [AutoMoqData]
        internal async Task GetReturnsCompanyObject_AndHttpOkStatusCode(
            Mock<IServiceManager> serviceManagerMock,
            Mock<ICompanyService> companyServiceMock,
            ILoggerManager logger,
            CompanyForGet companyForGet)
        {
            // Arrange
            serviceManagerMock.Setup(s => s.CompanyService).Returns(companyServiceMock.Object);
            companyServiceMock.Setup(x => x.GetByIdAsync(It.IsAny<Guid>(), false)).ReturnsAsync(companyForGet);
            var sut = new CompanyController(serviceManagerMock.Object, logger);

            // Act
            var result = await sut.GetCompany(companyForGet.Id);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var model = Assert.IsType<CompanyForGet>(okResult.Value);
            Assert.Equal(companyForGet.Id, model.Id);
        }

        [Theory]
        [AutoMoqData]
        internal async Task GetCompaniesReturnCompaniesCollection_AndHttpOkStatusCode(
            Mock<IServiceManager> serviceManagerMock,
            Mock<ICompanyService> companyServiceMock,
            ILoggerManager logger,
            IEnumerable<CompanyForGet> companiesForGet)
        {
            // Arrange
            serviceManagerMock.Setup(s => s.CompanyService).Returns(companyServiceMock.Object);
            companyServiceMock.Setup(x => x.GetAllAsync(false)).ReturnsAsync(companiesForGet);
            var sut = new CompanyController(serviceManagerMock.Object, logger);

            // Act
            var result = await sut.GetCompanies();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<CompanyForGet>>(okResult.Value);
            Assert.Equal(companiesForGet.Count(), model.Count());
        }

        [Theory]
        [AutoMoqData]
        internal async Task GetCompaniesByIdReturnCompaniesCollection_AndHttpOkStatusCode(
            Mock<IServiceManager> serviceManagerMock,
            Mock<ICompanyService> companyServiceMock,
            ILoggerManager logger,
            IEnumerable<CompanyForGet> companiesForGet)
        {
            // Arrange
            serviceManagerMock.Setup(s => s.CompanyService).Returns(companyServiceMock.Object);
            companyServiceMock.Setup(x => x.GetAllByIdAsync(It.IsAny<IEnumerable<Guid>>(), false)).ReturnsAsync(companiesForGet);
            var sut = new CompanyController(serviceManagerMock.Object, logger);

            // Act
            var result = await sut.GetCompaniesById(
                    new List<Guid> { Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid() }
                );

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<CompanyForGet>>(okResult.Value);
            Assert.Equal(companiesForGet.Count(), model.Count());
        }

        [Theory]
        [AutoMoqData]
        internal async Task AddReturnsCompanyObject_AndHttpCreatedStatusCode(
            Mock<IServiceManager> serviceManagerMock,
            Mock<ICompanyService> companyServiceMock,
            ILoggerManager logger,
            CompanyForAdd companyForAdd,
            CompanyForGet companyForGet)
        {
            // Arrange
            serviceManagerMock.Setup(s => s.CompanyService).Returns(companyServiceMock.Object);
            companyServiceMock.Setup(x => x.AddAsync(It.IsAny<CompanyForAdd>())).ReturnsAsync(companyForGet);
            var sut = new CompanyController(serviceManagerMock.Object, logger);

            // Act
            var result = await sut.AddAsync(companyForAdd);

            // Assert
            var okResult = Assert.IsType<CreatedAtRouteResult>(result);
            Assert.IsType<CompanyForGet>(okResult.Value);
        }

        [Theory]
        [AutoMoqData]
        internal async Task Delete_AndHttpNoContentStatusCode(
            Mock<IServiceManager> serviceManagerMock,
            Mock<ICompanyService> companyServiceMock,
            ILoggerManager logger,
            CompanyForGet companyForGet)
        {
            // Arrange
            serviceManagerMock.Setup(s => s.CompanyService).Returns(companyServiceMock.Object);
            companyServiceMock.Setup(x => x.DeleteAsync(It.IsAny<Guid>(), false)).Returns(Task.CompletedTask);
            var sut = new CompanyController(serviceManagerMock.Object, logger);

            // Act
            var result = await sut.DeleteAsync(companyForGet.Id);

            // Assert
            Assert.IsType<NoContentResult>(result);
        }

        [Theory]
        [AutoMoqData]
        internal async Task Update_AndHttpNoContentStatusCode(
            Mock<IServiceManager> serviceManagerMock,
            Mock<ICompanyService> companyServiceMock,
            ILoggerManager logger,
            CompanyForUpdate companyForUpdate)
        {
            // Arrange
            serviceManagerMock.Setup(s => s.CompanyService).Returns(companyServiceMock.Object);
            companyServiceMock.Setup(x => x.UpdateAsync(It.IsAny<Guid>(), It.IsAny<CompanyForUpdate>(), false)).Returns(Task.CompletedTask);
            var sut = new CompanyController(serviceManagerMock.Object, logger);

            // Act
            var result = await sut.UpdateAsync(Guid.NewGuid(), companyForUpdate);

            // Assert
            Assert.IsType<NoContentResult>(result);
        }
    }
}
