/*
 * @CreateTime: May 6, 2019 10:44 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: May 6, 2019 10:49 AM
 * @Description: Modify Here, Please 
 */
using Xunit;

namespace AccountingBackend.Domain.Test.SystemLookups {
    public class SystemLookupShould {
        private SystemLookup lookup;
        public SystemLookupShould () {
            lookup = new SystemLookup ();
        }

        [Fact]
        public void BeInitialized () {
            // Arrange

            // Assert
            Assert.NotNull (lookup);
        }

        [Fact]
        public void HaveTypeNotBeNull () {
            // Arrange

            // Act
            lookup.Type = "Cost Center";

            // Assert
            Assert.Equal ("Cost Center", lookup.Type);
        }

        [Fact]
        public void HaveTypeBeNull () {
            // Assert
            Assert.Null (lookup.Type);
        }

        [Fact]
        public void HaveAccountNotBeNull () {
            // Assert
            Assert.NotNull (lookup.Account);
        }

        [Fact]
        public void HaveValueNotBeNull () {
            // Arrange

            // Act
            lookup.Type = "Cost Center";

            // Assert
            Assert.Equal ("Cost Center", lookup.Type);
        }

        [Fact]
        public void HaveValuedBeNull () {
            // Assert
            Assert.Null (lookup.Type);
        }

    }
}