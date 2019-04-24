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
        public string Key { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public int MinutesToExpiration { get; set; }
    }
}