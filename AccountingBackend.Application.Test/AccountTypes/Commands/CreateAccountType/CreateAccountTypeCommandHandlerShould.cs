using System.Threading;
using System.Threading.Tasks;
/*
 * @CreateTime: May 14, 2019 2:51 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: May 14, 2019 2:59 PM
 * @Description: Modify Here, Please 
 */
using AccountingBackend.Application.AccountTypes.Commands.CreateAccountType;
using Xunit;

namespace AccountingBackend.Application.Test.AccountTypes.Commands.CreateAccountType {
    public class CreateAccountTypeCommandHandlerShould : DatabaseTestBase {

        /// <summary>
        /// tests the successful creation of account type when all values are passed as required
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task CreateAccountTypeSuccessfuly () {
            // Arrange
            CreateAccountTypeCommand command = new CreateAccountTypeCommand () {
                IsTypeOf = 2,
                Type = "Account Recievable",
                SummerizeReport = 1

            };
            CreateAccountTypeCommandHandler handler = new CreateAccountTypeCommandHandler (_Database);
            // Act
            var result = await handler.Handle (command, CancellationToken.None);
            // Assert
            Assert.NotEqual (0u, result);
        }

    }
}