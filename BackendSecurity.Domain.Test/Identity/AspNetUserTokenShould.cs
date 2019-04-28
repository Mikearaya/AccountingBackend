/*
 * @CreateTime: Apr 28, 2019 5:43 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Apr 28, 2019 5:47 PM
 * @Description: Modify Here, Please 
 */
using BackendSecurity.Domain.Identity;
using Microsoft.AspNetCore.Identity;
using Xunit;

namespace BackendSecurity.Domain.Test.Identity {
    public class AspNetUserTokenShould {

        [Fact]
        public void BeInstantiated () {
            // Arrange
            AspNetUserTokens userTokens = new AspNetUserTokens ();

            // Act

            // Assert
            Assert.NotNull (userTokens);
        }

        [Fact]
        public void BeDerivedFromIdentityUserTokenType () {
            // Arrange
            AspNetUserTokens userToken = new AspNetUserTokens ();
            // Act

            // Assert
            Assert.IsAssignableFrom<IdentityUserToken<string>> (userToken);
        }

        [Fact]
        public void HaveNullApplicationUser () {
            //Given
            AspNetUserTokens userTokens = new AspNetUserTokens ();

            //When

            //Then
            Assert.Null (userTokens.User);
        }

    }
}