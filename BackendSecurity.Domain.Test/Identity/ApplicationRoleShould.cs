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

        [Fact]
        public void BeInitialized () {
            // Arrange
            ApplicationRole roles = new ApplicationRole ();

            // Act

            // Assert
            Assert.NotNull (roles);
        }

        [Fact]
        public void IsIdentityRoleType () {
            // Arrange
            ApplicationRole role = new ApplicationRole ();
            // Act

            // Assert
            Assert.IsAssignableFrom<IdentityRole<string>> (role);
        }

        [Fact]
        public void HaveInitializedRoleClaims () {
            // Arrange
            ApplicationRole role = new ApplicationRole ();
            // Act

            // Assert
            Assert.NotNull (role.AspNetRoleClaims);
        }

        [Fact]
        public void HaveInitializedUserRoles () {
            // Arrange
            ApplicationRole role = new ApplicationRole ();
            // Act

            // Assert
            Assert.NotNull (role.AspNetUserRoles);
        }
    }
}