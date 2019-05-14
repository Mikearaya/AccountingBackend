/*
 * @CreateTime: May 14, 2019 10:43 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: May 14, 2019 10:44 AM
 * @Description: Modify Here, Please 
 */
using MediatR;

namespace AccountingBackend.Application.AccountTypes.Commands.UpdateAccountType {
    public class UpdateAccountTypeCommand : IRequest {
        public uint Id { get; set; }
        public uint IsTypeOf { get; set; }
        public string Type { get; set; }
        public sbyte SummerizeReport { get; set; }
    }
}