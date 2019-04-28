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

        private readonly AspNetUserTokens _userTokens;

        public AspNetUserTokenShould () {
            _userTokens = new AspNetUserTokens ();
        }

        [Fact]
        public void BeInstantiated () {
            // Arrange

            // Act

            // Assert
            Assert.NotNull (_userTokens);
        }

        [Fact]
        public void BeDerivedFromIdentityUserTokenType () {
            // Arrange

            // Act

            // Assert
            Assert.IsAssignableFrom<IdentityUserToken<string>> (_userTokens);
        }

        [Fact]
        public void HaveNullApplicationUser () {
            //Given

            //When

            //Then
            Assert.Null (_userTokens.User);
        }

    }
}