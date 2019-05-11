using System.Threading;
/*
 * @CreateTime: May 10, 2019 11:08 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: May 10, 2019 11:18 AM
 * @Description: Modify Here, Please 
 */
using System.Threading.Tasks;
using AccountingBackend.Application.Exceptions;
using AccountingBackend.Application.Ledgers.Models;
using AccountingBackend.Application.Ledgers.Queries.GetLedgerEntry;
using Xunit;

namespace AccountingBackend.Application.Test.Ledgers.Queries.GetLedgerEntry {
    public class GetLedgerEntryByIdQueryShould : DatabaseTestBase {

        private GetLedgerEntryByIdQueryHandler handler;
        public GetLedgerEntryByIdQueryShould () : base () {
            handler = new GetLedgerEntryByIdQueryHandler (_Database);
        }

        /// <summary>
        /// test the successful return of ledger entry view model
        /// when provided with valid id
        /// </summary>
        /// <returns></returns>

        [Fact]
        public async Task ReturnSingleLedgerEntry () {
            // Arrange
            GetLedgerEntryByIdQuery query = new GetLedgerEntryByIdQuery () {
                Id = 10
            };
            // Act
            var result = await handler.Handle (query, CancellationToken.None);
            // Assert
            Assert.IsType<LedgerEntryViewModel> (result);
            Assert.Equal (10, result.Id);
        }

        /// <summary>
        /// tests the return of not found exception when requested for none existing id
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task ThrowNotFoundExceptionForNonExistingEntry () {
            // Arrange
            GetLedgerEntryByIdQuery query = new GetLedgerEntryByIdQuery () {
                Id = 1
            };
            // Act

            // Assert
            await Assert.ThrowsAsync<NotFoundException> (() => handler.Handle (query, CancellationToken.None));
        }

    }
}