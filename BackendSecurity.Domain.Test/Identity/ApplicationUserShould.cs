/*
 * @CreateTime: Apr 28, 2019 3:59 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Apr 28, 2019 5:05 PM
 * @Description: Modify Here, Please 
 */
using BackendSecurity.Domain.Identity;
using Microsoft.AspNetCore.Identity;
using Xunit;

namespace BackendSecurity.Domain.Test.Identity {
    public class ApplicationUserShould {

        private readonly ApplicationUser _appUser;

        public ApplicationUserShould () {
            _appUser = new ApplicationUser ();
        }

        [Fact]
        public void BeInstantiated () {
            // Arrange

            // Act

            // Assert
            Assert.NotNull (_appUser);
        }

        [Fact]
        public void NotHaveNullUserName () {
            // Arrange

            // Act
            _appUser.UserName = "Mikael Araya";

            // Assert
            _appUser.UserName.Equals ("Mikael Araya");

        }

        [Fact]
        public void IsDerivedFromIdentityUserType () {
            // Arrange

            // Act

            // Assert
            Assert.IsAssignableFrom<IdentityUser<string>> (_appUser);

        }

        [Fact]
        public void NotHaveNullEmail () {
            // Arrange

            // Act
            _appUser.Email = "mikaelaraya12@gmail.com";
            // Assert
            Assert.NotNull (_appUser);
        }

        [Fact]
        public void HaveUserClaimsInitialized () {
            // Arrange
            ApplicationUser appUser = new ApplicationUser ();
            // Act

            // Assert
            Assert.NotNull (appUser.AspNetUserClaims);
        }

        [Fact]
        public void HaveUserLoginsInitialized () {
            // Arrange

            // Act

            // Assert
            Assert.NotNull (_appUser.AspNetUserLogins);
        }

        [Fact]
        public void HaveUserTokenInitialized () {
            // Arrange

            // Act

            // Assert
            Assert.NotNull (_appUser.AspNetUserTokens);
        }

    }
}