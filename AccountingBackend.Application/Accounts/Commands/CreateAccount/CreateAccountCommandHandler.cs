/*
 * @CreateTime: Apr 24, 2019 4:50 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Apr 24, 2019 4:50 PM
 * @Description: Modify Here, Please 
 */
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace AccountingBackend.Application.Accounts.Commands.CreateAccount {
    public class CreateAccountCommandHandler : IRequestHandler<CreateAccountCommand, int> {
        public Task<int> Handle (CreateAccountCommand request, CancellationToken cancellationToken) {
            throw new System.NotImplementedException ();
        }
    }
}