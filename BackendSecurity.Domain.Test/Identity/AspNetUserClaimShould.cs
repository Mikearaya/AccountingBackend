/*
 * @CreateTime: Apr 28, 2019 5:25 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Apr 28, 2019 5:32 PM
 * @Description: Modify Here, Please 
 */
using BackendSecurity.Domain.Identity;
using Microsoft.AspNetCore.Identity;
using Xunit;

namespace BackendSecurity.Domain.Test.Identity {
    public class AspNetUserClaimShould {

        private readonly AspNetUserClaims _userClaims;
        public AspNetUserClaimShould () {
            _userClaims = new AspNetUserClaims ();
        }

        [Fact]
        public void BeInstantiated () {
            // Arrange

            // Act

            // Assert
            Assert.NotNull (_userClaims);
        }

        [Fact]
        public void BeDerivedFromIdentityUserClaimsType () {
            // Arrange

            // Act

            // Assert
            Assert.IsAssignableFrom<IdentityUserClaim<string>> (_userClaims);
        }

        [Fact]
        public void HaveNullApplicationUser () {
            //Given

            //When

            //Then
            Assert.Null (_userClaims.User);
        }

    }
}