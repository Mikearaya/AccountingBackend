/*
 * @CreateTime: Apr 28, 2019 4:40 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Apr 28, 2019 5:23 PM
 * @Description: Modify Here, Please 
 */
using BackendSecurity.Domain.Identity;
using Microsoft.AspNetCore.Identity;
using Xunit;

namespace BackendSecurity.Domain.Test.Identity {
    public class ApplicationRoleShould {

        private readonly ApplicationRole _roles;

        public ApplicationRoleShould () {
            _roles = new ApplicationRole ();

        }

        [Fact]
        public void BeInitialized () {
            // Arrange

            // Act

            // Assert
            Assert.NotNull (_roles);
        }

        [Fact]
        public void IsIdentityRoleType () {
            // Arrange

            // Act

            // Assert
            Assert.IsAssignableFrom<IdentityRole<string>> (_roles);
        }

        [Fact]
        public void HaveInitializedRoleClaims () {
            // Arrange

            // Act

            // Assert
            Assert.NotNull (_roles.AspNetRoleClaims);
        }

        [Fact]
        public void HaveInitializedUserRoles () {
            // Arrange
            ApplicationRole role = new ApplicationRole ();
            // Act

            // Assert
            Assert.NotNull (_roles.AspNetUserRoles);
        }
    }
}