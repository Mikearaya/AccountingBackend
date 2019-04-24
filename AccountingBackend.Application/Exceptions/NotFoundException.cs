/*
 * @CreateTime: Apr 24, 2019 5:31 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Apr 24, 2019 5:31 PM
 * @Description: Modify Here, Please 
 */
using System;

namespace Northwind.Application.Exceptions {
    public class NotFoundException : Exception {
        public NotFoundException (string name, object key) : base ($"Entity \"{name}\" ({key}) was not found.") { }
    }
}