/*
 * @CreateTime: Apr 24, 2019 9:51 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Apr 24, 2019 9:51 PM
 * @Description: Modify Here, Please 
 */
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace AccountingBackend.Api {
    /// <summary>
    /// app entry class
    /// </summary>
    public class Program {

        /// <summary>
        /// app entry point
        /// </summary>
        /// <param name="args"></param>
        public static void Main (string[] args) {
            CreateWebHostBuilder (args).Build ().Run ();
        }

        /// <summary>
        /// initialize app for running
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public static IWebHostBuilder CreateWebHostBuilder (string[] args) =>
            WebHost.CreateDefaultBuilder (args)
            .UseStartup<Startup> ();
    }
}