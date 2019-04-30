/*
 * @CreateTime: Apr 30, 2019 6:24 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Apr 30, 2019 6:27 AM
 * @Description: Modify Here, Please 
 */
using Xunit;

namespace AccountingBackend.Domain.Test.AccountTypes {

    public class AccountTypeShould {

        private readonly AccountType _accountType;
        public AccountTypeShould () {
            _accountType = new AccountType ();
        }

        [Fact]
        public void BeInitialized () {
            // Arrange

            // Act

            // Assert
            Assert.NotNull (_accountType);
        }

        [Fact]
        public void HaveTypeSet () {
            // Arrange

            // Act
            _accountType.Type = "Asset";

            // Assert
            Assert.Equal ("Asset", _accountType.Type);
        }
    }
}