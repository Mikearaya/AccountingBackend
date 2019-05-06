/*
 * @CreateTime: May 6, 2019 11:22 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: May 6, 2019 11:23 AM
 * @Description: Modify Here, Please 
 */
using MediatR;

namespace AccountingBackend.Application.SystemLookups.Commands.DeleteSystemLookup {
    public class DeleteSystemLookupCommand : IRequest {
        public int Id { get; set; }
    }
}