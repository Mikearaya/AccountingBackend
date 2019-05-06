/*
 * @CreateTime: May 6, 2019 11:01 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: May 6, 2019 11:05 AM
 * @Description: Modify Here, Please 
 */
using System.Collections.Generic;
using AccountingBackend.Application.SystemLookups.Models;
using MediatR;

namespace AccountingBackend.Application.SystemLookups.Commands.CreateSystemLookup {
    public class CreateSystemLookupCommand : IRequest {

        public IEnumerable<NewSystemLookupModel> Lookups { get; set; } = new List<NewSystemLookupModel> ();

    }

}