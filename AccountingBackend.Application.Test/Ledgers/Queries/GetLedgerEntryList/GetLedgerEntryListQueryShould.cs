using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AccountingBackend.Application.Ledgers.Models;
/*
 * @CreateTime: May 10, 2019 11:20 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: May 10, 2019 1:04 PM
 * @Description: Modify Here, Please 
 */
using AccountingBackend.Application.Ledgers.Queries.GetLedgerEntryList;
using Xunit;

namespace AccountingBackend.Application.Test.Ledgers.Queries.GetLedgerEntryList {
    public class GetLedgerEntryListViewQueryShould : DatabaseTestBase {
        private GetJornalEntryListViewQueryHandler handler;

        public GetLedgerEntryListViewQueryShould () : base () {
            handler = new GetJornalEntryListViewQueryHandler (_Database);
        }

        /// <summary>
        /// tests the return of jornal entry list view model array
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task ReturnListOfJornalEntryViewSuccessfuly () {
            GetJornalEntryListQuery query = new GetJornalEntryListQuery ();

            var result = await handler.Handle (query, CancellationToken.None);

            Assert.IsType<List<JornalEntryListView>> (result);

        }

    }
}