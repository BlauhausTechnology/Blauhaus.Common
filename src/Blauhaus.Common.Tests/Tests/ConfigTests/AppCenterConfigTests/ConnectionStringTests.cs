using System.Collections.Generic;
using Blauhaus.Common.Config.AppCenter;
using Blauhaus.Common.Config.AppCenter.Client;
using Blauhaus.Common.ValueObjects.RuntimePlatforms;
using NUnit.Framework;

namespace Blauhaus.Common.Tests.Tests.ConfigTests.AppCenterConfigTests
{
    [TestFixture]
    public class ConnectionStringTests
    {

        private class TestConfig : BaseAppCenterClientConfig{}

        [Test]
        public void IF_all_3_platforms_are_supplied_SHOULD_add_all_platforms_to_connection_string()
        {
            //Arrange
            var sut = new TestConfig();
            sut.AppSecrets[RuntimePlatform.Android] = "androidSecret";
            sut.AppSecrets[RuntimePlatform.iOS] = "iOSSecret";
            sut.AppSecrets[RuntimePlatform.UWP] = "UWPSecret";

            //Assert
            Assert.That(sut.ConnectionString, Is.EqualTo("android=androidSecret;ios=iOSSecret;uwp=UWPSecret"));
        }

        
        [Test]
        public void IF_2_platforms_are_supplied_SHOULD_add_only_those_platforms_to_connection_string()
        {
            //Arrange
            var sut = new TestConfig();
            sut.AppSecrets[RuntimePlatform.Android] = "androidSecret";
            sut.AppSecrets[RuntimePlatform.iOS] = "iOSSecret";

            //Assert
            Assert.That(sut.ConnectionString, Is.EqualTo("android=androidSecret;ios=iOSSecret"));
        }
        [Test]
        public void IF_one_platform_is_supplied_SHOULD_add_only_that_platform_to_connection_string()
        {
            //Arrange
            var sut = new TestConfig();
            sut.AppSecrets[RuntimePlatform.iOS] = "iOSSecret";

            //Assert
            Assert.That(sut.ConnectionString, Is.EqualTo("ios=iOSSecret"));
        }

    }
}