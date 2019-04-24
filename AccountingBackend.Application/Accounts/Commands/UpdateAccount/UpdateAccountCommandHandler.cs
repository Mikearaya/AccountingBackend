/*
 * @CreateTime: Apr 24, 2019 5:49 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Apr 24, 2019 5:50 PM
 * @Description: Modify Here, Please 
 */
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace AccountingBackend.Application.Accounts.Commands.UpdateAccount {
    public class UpdateAccountCommandHandler : IRequestHandler<UpdateAccountCommand, Unit> {
        public Task<Unit> Handle (UpdateAccountCommand request, CancellationToken cancellationToken) {
            throw new System.NotImplementedException ();
        }
    }
}