using BLCLicenseManagement.Domain;
using BLCLicenseManagement.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using Shouldly;
namespace BLCLicenseManagement.Persistence.IntegrationTests
{
    public class HrDatabaseContextTests
    {
        private BLCDatabaseContext _blcDatabaseContext;
        private readonly string _userId;
        //private readonly Mock<IUserService> _userServiceMock;
        public HrDatabaseContextTests()
        {
            var dbOptions = new DbContextOptionsBuilder<BLCDatabaseContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;
            //_userId = "00000000-0000-0000-0000-000000000000";
            //_userServiceMock = new Mock<IUserService>();
            //_userServiceMock.Setup(m => m.UserId).Returns(_userId);

            _blcDatabaseContext = new BLCDatabaseContext(dbOptions);
        }

        [Fact]
        public async void Save_SetDateCreatedValue()
        {
            // Arrange
            var licenseType = new LicenseType
            {
                Id = 1,
                Name = "Test Vacation"
            };

            // Act
            await _blcDatabaseContext.LicenseTypes.AddAsync(licenseType);
            await _blcDatabaseContext.SaveChangesAsync();

            // Assert
            licenseType.DateCreated.ShouldNotBeNull();
        }

        [Fact]
        public async void Save_SetDateModifiedValue()
        {
            // Arrange
            var licenseType = new LicenseType
            {
                Id = 1,
                Name = "Test Vacation"
            };

            // Act
            await _blcDatabaseContext.LicenseTypes.AddAsync(licenseType);
            await _blcDatabaseContext.SaveChangesAsync();

            // Assert
            licenseType.DateModified.ShouldNotBeNull();
        }
    }
}
