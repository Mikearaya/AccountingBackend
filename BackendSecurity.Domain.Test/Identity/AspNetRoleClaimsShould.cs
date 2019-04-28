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

        private readonly AspNetRoleClaims _roleClaim;
        public AspNetRoleClaimsShould () {
            _roleClaim = new AspNetRoleClaims ();
        }

        [Fact]
        public void BeInstantiated () {
            // Arrange

            // Act

            // Assert
            Assert.NotNull (_roleClaim);
        }

        [Fact]
        public void IsDerivedFromIdentityRoleClaimType () {
            // Arrange

            // Act

            // Assert
            Assert.IsAssignableFrom<IdentityRoleClaim<string>> (_roleClaim);
        }

        [Fact]
        public void HaveNullRole () {
            // Arrange

            // Act

            // Assert
            Assert.Null (_roleClaim.Role);
        }

    }
}