using BLCLicenseManagement.Application.Contracts.Persistence;
using BLCLicenseManagement.Domain;
using Moq;

namespace BLCLicense_Management.Application.UnitTests.Mocks
{
    public class MockLicenseTypeRepository
    {
        public static Mock<ILicenseTypeRepository> GetMockLicenseTypeRepository()
        {
            var licenseTypes = new List<LicenseType>
            {
                new LicenseType
                {
                    Id = 1,
                    Name = "Test Vacation"
                },
                new LicenseType
                {
                    Id = 2,
                    Name = "Test Sick"
                },
                new LicenseType
                {
                    Id = 3,
                    Name = "Test Maternity"
                }
            };

            var mockRepo = new Mock<ILicenseTypeRepository>();

            mockRepo.Setup(r => r.GetAllAsync()).ReturnsAsync(licenseTypes);

            mockRepo.Setup(r => r.CreateAsync(It.IsAny<LicenseType>()))
                .Returns((LicenseType leaveType) =>
                {
                    licenseTypes.Add(leaveType);
                    return Task.CompletedTask;
                });

            mockRepo.Setup(r => r.IsUniqueName(It.IsAny<string>()))
                .ReturnsAsync((string name) =>
                {
                    return !licenseTypes.Any(q => q.Name == name);
                });

            return mockRepo;
        }
    }
}
