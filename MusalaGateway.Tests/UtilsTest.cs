using NUnit.Framework;
using MusalaGateway.Api.Helpers;

namespace MusalaGateway.Tests
{
    public class UtilsTest
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void IsIPv4()
        {
            bool result = Utils.ValidateIPv4("240.124.0.12");

            Assert.IsTrue(result);
        }

        [Test]
        public void IsNotIPv4()
        {
            bool result = Utils.ValidateIPv4("240.124.300.12");

            Assert.IsFalse(result);
        }
    }
}
