/*
 * @CreateTime: Apr 24, 2019 10:27 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Apr 24, 2019 10:27 PM
 * @Description: Modify Here, Please 
 */
namespace AccountingBackend.Api.Configurations {

    /// <summary>
    /// class that represents jwt setting found in configuration file
    /// </summary>
    public class JwtSettings {
        /// <summary>
        /// holds value for the symetric key to be used 
        /// </summary>
        /// <value>random string</value>
        public string Key { get; set; }
        /// <summary>
        /// holds value of the server issuing the key
        /// </summary>
        /// <value>uri</value>
        public string Issuer { get; set; }
        /// <summary>
        /// holds allowed audience to access the api
        /// </summary>
        /// <value>uri</value>
        public string Audience { get; set; }
        /// <summary>
        /// holds time the token will be valid
        /// </summary>
        /// <value>timestamp</value>
        public int MinutesToExpiration { get; set; }
    }
}