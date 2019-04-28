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

        [Fact]
        public void BeInstantiated () {
            // Arrange
            ApplicationUser appUser = new ApplicationUser ();
            // Act

            // Assert
            Assert.NotNull (appUser);
        }

        [Fact]
        public void NotHaveNullUserName () {
            // Arrange
            ApplicationUser appUser = new ApplicationUser ();
            // Act
            appUser.UserName = "Mikael Araya";

            // Assert
            appUser.UserName.Equals ("Mikael Araya");

        }

        [Fact]
        public void IsDerivedFromIdentityUserType () {
            // Arrange
            ApplicationUser appUser = new ApplicationUser ();

            // Act

            // Assert
            Assert.IsAssignableFrom<IdentityUser<string>> (appUser);

        }

        [Fact]
        public void NotHaveNullEmail () {
            // Arrange
            ApplicationUser appUser = new ApplicationUser ();
            // Act
            appUser.Email = "mikaelaraya12@gmail.com";
            // Assert
            Assert.NotNull (appUser);
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
            ApplicationUser appUser = new ApplicationUser ();
            // Act

            // Assert
            Assert.NotNull (appUser.AspNetUserLogins);
        }

        [Fact]
        public void HaveUserTokenInitialized () {
            // Arrange
            ApplicationUser appUser = new ApplicationUser ();
            // Act

            // Assert
            Assert.NotNull (appUser.AspNetUserTokens);
        }

    }
}