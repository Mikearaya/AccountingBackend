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
        private readonly AspNetUserRoles _userRole;

        public AspNetUserRoleShould () {
            _userRole = new AspNetUserRoles ();
        }

        [Fact]
        public void BeInstantiated () {
            // Arrange

            // Act

            // Assert
            Assert.NotNull (_userRole);
        }

        [Fact]
        public void BeDerivedFromIdentityUserRoleType () {
            // Arrange

            // Act

            // Assert
            Assert.IsAssignableFrom<IdentityUserRole<string>> (_userRole);
        }

        [Fact]
        public void HaveNullApplicationUser () {
            // Arrange

            // Act

            // Assert
            Assert.Null (_userRole.User);
        }

        [Fact]
        public void HaveNullApplicationRole () {
            //Given

            //When

            //Then
            Assert.Null (_userRole.Role);
        }

    }
}