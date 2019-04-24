/*
 * @CreateTime: Apr 24, 2019 5:48 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Apr 24, 2019 5:48 PM
 * @Description: Modify Here, Please 
 */
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace AccountingBackend.Application.Accounts.Commands.DeleteAccount {
    public class DeleteAccountCommandHandler : IRequestHandler<DeleteAccountCommand, Unit> {
        public Task<Unit> Handle (DeleteAccountCommand request, CancellationToken cancellationToken) {
            throw new System.NotImplementedException ();
        }
    }
}