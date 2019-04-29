/*
 * @CreateTime: Apr 29, 2019 5:26 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Apr 29, 2019 5:34 PM
 * @Description: Modify Here, Please 
 */
using Xunit;

namespace AccountingBackend.Domain.Test.Accounts {
    public class AccountShould {
        private readonly Account account;
        public AccountShould () {
            account = new Account ();
        }

        [Fact]
        public void BeInitialized () {
            //Given

            //When

            //Then
            Assert.NotNull (account);
        }

        [Fact]
        public void HaveInitializedCategory () {
            // Arrange

            // Act
            account.Catagory = new AccountCatagory ();
            // Assert
            Assert.NotNull (account.Catagory);
        }

        [Fact]
        public void HaveInitializedId () {
            // Arrange

            // Act
            account.Id = "10";

            // Assert
            Assert.Equal ("10", account.Id);
        }

        [Fact]
        public void HaveInitializedName () {
            // Arrange

            // Act
            account.AccountName = "account name";

            // Assert
            Assert.Equal ("account name", account.AccountName);
        }

        [Fact]
        public void HaveInitializedParentAccount () {
            // Arrange

            // Act
            account.ParentAccount = "100";

            // Assert
            Assert.Equal ("100", account.ParentAccount);
        }

        [Fact]
        public void HaveInitializedCategoryId () {
            // Arrange

            // Act
            account.CatagoryId = 2;

            // Assert
            Assert.Equal (2, account.CatagoryId);
        }

    }
}