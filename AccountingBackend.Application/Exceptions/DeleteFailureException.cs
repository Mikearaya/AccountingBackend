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
    public class DeleteFailureException : Exception {
        public DeleteFailureException (string name, object key, string message) : base ($"Deletion of entity \"{name}\" ({key}) failed. {message}") { }
    }
}