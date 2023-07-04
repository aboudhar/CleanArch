using AutoMapper;
using BLCLicense_Management.Application.UnitTests.Mocks;
using BLCLicenseManagement.Application.Contracts.Logging;
using BLCLicenseManagement.Application.Contracts.Persistence;
using BLCLicenseManagement.Application.Features.LicenseType.Queries.GetAllLicenseTypes;
using BLCLicenseManagement.Application.Features.LicenseTypes.Queries;
using BLCLicenseManagement.Application.MappingProfiles;
using Moq;
using Shouldly;

namespace BLCLicense_Management.Application.UnitTests.Features.LicenseTypes.Queries
{
    public class GetLicenseTypeQueryHandlerTest
    {
        private readonly Mock<ILicenseTypeRepository> _licenseTypeRepositoryMock;
        private IMapper _mapper;
        private Mock<IAppLogger<GetLicenseTypeQueryHandler>> _applogger;

        public GetLicenseTypeQueryHandlerTest()
        {
            _licenseTypeRepositoryMock = MockLicenseTypeRepository.GetMockLicenseTypeRepository();
            var mapperConfig = new MapperConfiguration
                (c =>
                {
                    c.AddProfile<LicenseTypeProfile>();
                });
            _mapper = mapperConfig.CreateMapper();
            _applogger = new Mock<IAppLogger<GetLicenseTypeQueryHandler>>();
        }
        [Fact]
        public async Task GetLicenseTypeQueryHandler_Should_Return_LicenseTypes()
        {
            var handler = new GetLicenseTypeQueryHandler(_mapper, _licenseTypeRepositoryMock.Object, _applogger.Object);
            var res = await handler.Handle(new GetLicenseTypeQuery(), CancellationToken.None);
            res.ShouldBeOfType<List<LicenseTypeDto>>();
            res.Count.ShouldBe(3);
        }
    }
}
