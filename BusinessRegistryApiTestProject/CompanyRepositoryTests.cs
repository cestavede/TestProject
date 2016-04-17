using Moq;
using Xunit;

using BusinessRegistryApi;

namespace BusinessRegistryApiTestProject
{
    public class CompanyRepositoryTests
    {
        [Fact]
        public void TestCompanyRepositoryConstructor()
        {
            var mock = new Mock<ITempDb>();
            mock.Setup(m => m.Init()).Returns(true); // Try returning false from mock here

            var repo = new CompanyRepository( mock.Object );

            // Called at least once
            mock.Verify(m => m.Init(), Times.Once());

            // If no exceptions then we are fine
            Assert.True(true);

            Assert.NotNull(repo);
        }

    }
}
