/*
 * @CreateTime: Jun 17, 2019 10:21 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jun 17, 2019 10:21 AM
 * @Description: Modify Here, Please 
 */
namespace AccountingBackend.Application.Ledgers.Models {
    public class LedgerEntryNavigationModel : LedgerEntryViewModel {
        public bool HasPrev { get; set; }

        public bool HasNext { get; set; }
    }
}