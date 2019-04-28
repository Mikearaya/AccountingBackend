/*
 * @CreateTime: Apr 28, 2019 5:37 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Apr 28, 2019 5:42 PM
 * @Description: Modify Here, Please 
 */
using BackendSecurity.Domain.Identity;
using Microsoft.AspNetCore.Identity;
using Xunit;

namespace BackendSecurity.Domain.Test.Identity {
    public class AspNetUserRoleShould {

        [Fact]
        public void BeInstantiated () {
            // Arrange
            AspNetUserRoles userRole = new AspNetUserRoles ();
            // Act

            // Assert
            Assert.NotNull (userRole);
        }

        [Fact]
        public void BeDerivedFromIdentityUserRoleType () {
            // Arrange
            AspNetUserRoles userRoles = new AspNetUserRoles ();
            // Act

            // Assert
            Assert.IsAssignableFrom<IdentityUserRole<string>> (userRoles);
        }

        [Fact]
        public void HaveNullApplicationUser () {
            // Arrange
            AspNetUserRoles userRole = new AspNetUserRoles ();
            // Act

            // Assert
            Assert.Null (userRole.User);
        }

        [Fact]
        public void HaveNullApplicationRole () {
            //Given
            AspNetUserRoles userRole = new AspNetUserRoles ();
            //When

            //Then
            Assert.Null (userRole.Role);
        }

    }
}