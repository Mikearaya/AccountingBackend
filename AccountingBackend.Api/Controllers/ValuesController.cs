/*
 * @CreateTime: Apr 24, 2019 9:37 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Apr 24, 2019 9:37 PM
 * @Description: Modify Here, Please 
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace AccountingBackend.Api.Controllers {
    /// <summary>
    /// Test Controller created when creating new netcore web api
    /// </summary>
    [Route ("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase {
        /// <summary>
        /// returns value array
        /// </summary>
        /// <returns>IEnumerable</returns>

        [HttpGet]
        public ActionResult<IEnumerable<string>> Get () {
            return new string[] { "value1", "value2" };
        }

        /// <summary>
        /// returns single value
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet ("{id}")]
        public ActionResult<string> Get (int id) {
            return "value";
        }

        /// <summary>
        /// creates new value
        /// </summary>
        /// <param name="value"></param>
        [HttpPost]
        public void Post ([FromBody] string value) { }

        /// <summary>
        /// updates value
        /// </summary>
        /// <param name="id"></param>
        /// <param name="value"></param>
        [HttpPut ("{id}")]
        public void Put (int id, [FromBody] string value) { }

        /// <summary>
        /// Deletes value
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete ("{id}")]
        public void Delete (int id) { }
    }
}