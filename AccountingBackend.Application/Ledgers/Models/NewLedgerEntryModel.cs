/*
 * @CreateTime: May 8, 2019 8:36 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: May 8, 2019 8:37 AM
 * @Description: Modify Here, Please 
 */
namespace AccountingBackend.Application.Ledgers.Models {
    public class NewLedgerEntryModel {
        public int AccountId { get; set; }
        public float? Debit { get; set; }
        public float? Credit { get; set; }
    }
}