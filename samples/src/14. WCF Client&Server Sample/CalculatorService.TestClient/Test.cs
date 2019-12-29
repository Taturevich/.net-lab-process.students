using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Security;
using System.ServiceModel.Security.Tokens;
using CalculatorService.TestClient.ServiceReference;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CalculatorService.TestClient
{
    [TestClass]
    public class Test
    {
        [TestMethod]
        public void AuthenticatedUserWithUserRole_ShouldSuccess()
        {
            // Arrange
            using (var client = new CalculatorServiceClient())
            {
                var factory = client.ChannelFactory;
                factory.Endpoint.Behaviors.Remove<ClientCredentials>();
                var loginCredentials = new ClientCredentials();
                loginCredentials.UserName.UserName = "user";
                loginCredentials.UserName.Password = "password";
                factory.Endpoint.Behaviors.Add(loginCredentials);

                // Act
                var value = client.Add(1, 2);

                // Assert
                Assert.AreEqual(value, 3);

            }
        }

        [TestMethod]
        public void AuthenticatedUserWithUserRole_Factorial_ShouldSuccess()
        {
            // Arrange
            var service = new CalculatorServiceClient();
            service.ClientCredentials.UserName.UserName = "user";
            service.ClientCredentials.UserName.Password = "password";

            // Act
            var value = service.Factorial(10);

            // Assert
            Assert.AreEqual((ulong)3628800, value);
        }

        [TestMethod]
        public void AuthenticatedUserWithAdminAndManagerRole_ShouldSuccess()
        {
            // Arrange
            var service = new CalculatorServiceClient();
            service.ClientCredentials.UserName.UserName = "user2";
            service.ClientCredentials.UserName.Password = "password";

            // Act
            var value = service.Multiple(1, 2);

            // Assert
            Assert.AreEqual(value, 2);
        }

        [TestMethod]
        public void AuthenticatedUserWithUserRole_ShouldFail()
        {
            // Arrange
            var service = new CalculatorServiceClient();
            service.ClientCredentials.UserName.UserName = "user";
            service.ClientCredentials.UserName.Password = "password";

            // Act
            // Assert
            Assert.ThrowsException<SecurityAccessDeniedException>(() => service.Multiple(1, 2));
        }


        [TestMethod]
        public void AuthenticatedUserWithManagerRole_ShouldSucess()
        {
            // Arrange
            var service = new CalculatorServiceClient();
            service.ClientCredentials.UserName.UserName = "user3";
            service.ClientCredentials.UserName.Password = "password";

            // Act
            var value = service.Multiple(1, 2);

            // Assert
            Assert.AreEqual(value, 2);
        }
    }
}
