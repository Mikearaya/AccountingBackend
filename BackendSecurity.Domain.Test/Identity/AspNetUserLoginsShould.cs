/*
 * @CreateTime: Apr 28, 2019 5:32 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Apr 28, 2019 5:36 PM
 * @Description: Modify Here, Please 
 */
using BackendSecurity.Domain.Identity;
using Microsoft.AspNetCore.Identity;
using Xunit;

namespace BackendSecurity.Domain.Test.Identity {
    public class AspNetUserLoginsShould {

        private readonly AspNetUserLogins _userLogin;

        public AspNetUserLoginsShould () {
            _userLogin = new AspNetUserLogins ();

        }

        [Fact]
        public void BeInstantiated () {
            // Arrange

            // Act

            // Assert
            Assert.NotNull (_userLogin);
        }

        [Fact]
        public void BeDerivedFromIdentityUserLoginsType () {
            // Arrange

            // Act

            // Assert
            Assert.IsAssignableFrom<IdentityUserLogin<string>> (_userLogin);
        }

        [Fact]
        public void HaveNullApplicationUser () {
            //Given

            //When

            //Then
            Assert.Null (_userLogin.User);
        }
    }
}