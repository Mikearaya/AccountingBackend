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

        [Fact]
        public void BeInstantiated () {
            // Arrange
            AspNetUserLogins userLogin = new AspNetUserLogins ();
            // Act

            // Assert
            Assert.NotNull (userLogin);
        }

        [Fact]
        public void BeDerivedFromIdentityUserLoginsType () {
            // Arrange
            AspNetUserLogins userLogin = new AspNetUserLogins ();

            // Act

            // Assert
            Assert.IsAssignableFrom<IdentityUserLogin<string>> (userLogin);
        }

        [Fact]
        public void HaveNullApplicationUser () {
            //Given
            AspNetUserLogins userLogin = new AspNetUserLogins ();

            //When

            //Then
            Assert.Null (userLogin.User);
        }
    }
}