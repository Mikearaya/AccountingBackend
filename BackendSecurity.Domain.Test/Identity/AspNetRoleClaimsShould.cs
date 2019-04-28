/*
 * @CreateTime: Apr 28, 2019 4:34 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Apr 28, 2019 5:03 PM
 * @Description: Modify Here, Please 
 */
using BackendSecurity.Domain.Identity;
using Microsoft.AspNetCore.Identity;
using Xunit;

namespace BackendSecurity.Domain.Test.Identity {
    public class AspNetRoleClaimsShould {

        [Fact]
        public void BeInstantiated () {
            // Arrange
            AspNetRoleClaims roleClaim = new AspNetRoleClaims ();
            // Act

            // Assert
            Assert.NotNull (roleClaim);
        }

        [Fact]
        public void IsDerivedFromIdentityRoleClaimType () {
            // Arrange
            AspNetRoleClaims roleClaim = new AspNetRoleClaims ();
            // Act

            // Assert
            Assert.IsAssignableFrom<IdentityRoleClaim<string>> (roleClaim);
        }

        [Fact]
        public void HaveNullRole () {
            // Arrange
            AspNetRoleClaims roleClaim = new AspNetRoleClaims ();
            // Act

            // Assert
            Assert.Null (roleClaim.Role);
        }

    }
}