/*
 * @CreateTime: Apr 29, 2019 5:26 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Apr 29, 2019 5:26 PM
 * @Description: Modify Here, Please 
 */
using Xunit;

namespace AccountingBackend.Domain.Test.AccountCategories {
    public class AccountCategoriesShould {
        private readonly AccountCatagory _category;
        public AccountCategoriesShould () {
            _category = new AccountCatagory ();
        }

        [Fact]
        public void BeInitialized () {
            // Arrange

            // Act

            // Assert
            Assert.NotNull (_category);
        }

        [Fact]
        public void HaveAccountThatIsNotNotNull () {
            // Arrange

            // Act

            // Assert
            Assert.NotNull (_category.Account);
            _category.Account.Count.Equals (0);
        }

        [Fact]
        public void SetCategoryName () {
            // Arrange

            // Act
            _category.Name = "Fixed Asset";
            // Assert
            Assert.Equal ("Fixed Asset", _category.Name);
        }

        [Fact]
        public void SetCategoryValue () {
            // Arrange

            // Act
            _category.Catagory = "Asset";
            // Assert
            Assert.Equal ("Asset", _category.Catagory);
        }
    }
}