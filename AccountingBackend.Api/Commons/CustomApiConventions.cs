/*
 * @CreateTime: Apr 28, 2019 2:29 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: May 19, 2019 10:11 AM
 * @Description: Modify Here, Please 
 */
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;

namespace AccountingBackend.Api.Commons {

    /// <summary>
    /// custom api convention that is used to apply common return code to every
    /// controllers taged with controller
    /// </summary>
    public static class CustomApiConventions {

        /// <summary>
        /// sets the default expected response type for every http requests handles by a method 
        /// name that start with create
        /// </summary>

        [ApiConventionNameMatch (ApiConventionNameMatchBehavior.Prefix)]
        [ProducesDefaultResponseType]
        [ProducesResponseType (201)]
        [ProducesResponseType (400)]
        [ProducesResponseType (401)]
        [ProducesResponseType (403)]
        [ProducesResponseType (422)]
        [ProducesResponseType (500)]
        public static void Create ([ApiConventionNameMatch (ApiConventionNameMatchBehavior.Any)][ApiConventionTypeMatch (ApiConventionTypeMatchBehavior.Any)] object model) { }

        /// <summary>
        /// sets the default expected response type for every http requests handles by a method 
        /// name that start with Delete
        /// </summary>

        [ApiConventionNameMatch (ApiConventionNameMatchBehavior.Prefix)]
        [ProducesDefaultResponseType]
        [ProducesResponseType (204)]
        [ProducesResponseType (400)]
        [ProducesResponseType (401)]
        [ProducesResponseType (403)]
        [ProducesResponseType (404)]
        [ProducesResponseType (422)]
        [ProducesResponseType (500)]
        public static void Delete ([ApiConventionNameMatch (ApiConventionNameMatchBehavior.Suffix)][ApiConventionTypeMatch (ApiConventionTypeMatchBehavior.Any)] object id) { }

        /// <summary>
        /// sets the default expected response type for every http requests handles by a method 
        /// name that start with Find
        /// </summary>

        [ApiConventionNameMatch (ApiConventionNameMatchBehavior.Prefix)]
        [ProducesDefaultResponseType]
        [ProducesResponseType (200)]
        [ProducesResponseType (400)]
        [ProducesResponseType (401)]
        [ProducesResponseType (403)]
        [ProducesResponseType (404)]
        [ProducesResponseType (500)]
        public static void Find ([ApiConventionNameMatch (ApiConventionNameMatchBehavior.Suffix)][ApiConventionTypeMatch (ApiConventionTypeMatchBehavior.Any)] object id) { }

        /// <summary>
        /// sets the default expected response type for every http requests handles by a method 
        /// name that start with Get
        /// </summary>
        [ApiConventionNameMatch (ApiConventionNameMatchBehavior.Prefix)]
        [ProducesDefaultResponseType]
        [ProducesResponseType (200)]
        [ProducesResponseType (401)]
        [ProducesResponseType (403)]
        [ProducesResponseType (500)]
        public static void Get ([ApiConventionNameMatch (ApiConventionNameMatchBehavior.Suffix)][ApiConventionTypeMatch (ApiConventionTypeMatchBehavior.Any)] object id) { }

        /// <summary>
        /// sets the default expected response type for every http requests handles by a method 
        /// name that start with Get
        /// </summary>

        [ApiConventionNameMatch (ApiConventionNameMatchBehavior.Prefix)]
        [ProducesDefaultResponseType]
        [ProducesResponseType (200)]
        [ProducesResponseType (400)]
        [ProducesResponseType (401)]
        [ProducesResponseType (403)]
        [ProducesResponseType (500)]
        public static void Get () { }

        /// <summary>
        /// sets the default expected response type for every http requests handles by a method 
        /// name that start with Update
        /// </summary>

        [ApiConventionNameMatch (ApiConventionNameMatchBehavior.Prefix)]
        [ProducesDefaultResponseType]
        [ProducesResponseType (204)]
        [ProducesResponseType (400)]
        [ProducesResponseType (401)]
        [ProducesResponseType (403)]
        [ProducesResponseType (404)]
        [ProducesResponseType (422)]
        [ProducesResponseType (500)]
        public static void Update ([ApiConventionNameMatch (ApiConventionNameMatchBehavior.Suffix)][ApiConventionTypeMatch (ApiConventionTypeMatchBehavior.Any)] object id, [ApiConventionNameMatch (ApiConventionNameMatchBehavior.Any)][ApiConventionTypeMatch (ApiConventionTypeMatchBehavior.Any)] object model) { }

        /// <summary>
        /// sets the default expected response type for every http requests handles by a method 
        /// name that start with Update
        /// </summary>

        [ApiConventionNameMatch (ApiConventionNameMatchBehavior.Prefix)]
        [ProducesDefaultResponseType]
        [ProducesResponseType (204)]
        [ProducesResponseType (400)]
        [ProducesResponseType (401)]
        [ProducesResponseType (403)]
        [ProducesResponseType (404)]
        [ProducesResponseType (422)]
        [ProducesResponseType (500)]
        public static void Update ([ApiConventionNameMatch (ApiConventionNameMatchBehavior.Any)][ApiConventionTypeMatch (ApiConventionTypeMatchBehavior.Any)] object model) { }
    }

}