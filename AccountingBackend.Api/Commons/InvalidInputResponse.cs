/*
 * @CreateTime: Apr 26, 2019 10:40 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Apr 26, 2019 10:40 AM
 * @Description: Modify Here, Please 
 */
using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace AccountingBackend.API.Commons {
    public class InvalidInputResponse : ObjectResult {
        public InvalidInputResponse (ModelStateDictionary value) : base (new SerializableError (value)) {

            if (value == null) {
                throw new ArgumentNullException (nameof (value));
            }

            StatusCode = 422;
        }
    }
}