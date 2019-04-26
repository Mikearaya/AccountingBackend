/*
 * @CreateTime: Apr 24, 2019 5:31 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Apr 26, 2019 10:49 AM
 * @Description: Modify Here, Please 
 */
using System;

namespace AccountingBackend.Application.Exceptions {
    public class NotFoundException : Exception {
        public NotFoundException (string message) : base (message) { }

        public NotFoundException (string name, object key) : base ($"Entity \"{name}\" ({key}) was not found.") { }

    }
}