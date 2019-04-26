/*
 * @CreateTime: Apr 26, 2019 9:29 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Apr 26, 2019 9:30 PM
 * @Description: Modify Here, Please 
 */
using System.Threading.Tasks;

namespace AccountingBackend.Application.Interfaces {
    public interface IAccountingDatabaseService {

        void Save ();
        Task SaveAsync ();

    }
}