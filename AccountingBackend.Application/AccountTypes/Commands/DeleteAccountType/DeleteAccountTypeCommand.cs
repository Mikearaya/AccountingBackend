/*
 * @CreateTime: May 14, 2019 11:00 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: May 14, 2019 11:04 AM
 * @Description: Modify Here, Please 
 */
using MediatR;

namespace AccountingBackend.Application.AccountTypes.Commands.DeleteAccountType {
    public class DeleteAccountTypeCommand : IRequest {
        public uint Id { get; set; }
    }
}