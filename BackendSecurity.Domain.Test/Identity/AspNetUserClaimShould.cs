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

        [Fact]
        public void BeInstantiated () {
            // Arrange
            AspNetUserClaims userClaim = new AspNetUserClaims ();
            // Act

            // Assert
            Assert.NotNull (userClaim);
        }

        [Fact]
        public void BeDerivedFromIdentityUserClaimsType () {
            // Arrange
            AspNetUserClaims userClaim = new AspNetUserClaims ();
            // Act

            // Assert
            Assert.IsAssignableFrom<IdentityUserClaim<string>> (userClaim);
        }

        [Fact]
        public void HaveNullApplicationUser () {
            //Given
            AspNetUserClaims userClaim = new AspNetUserClaims ();
            //When

            //Then
            Assert.Null (userClaim.User);
        }

    }
}