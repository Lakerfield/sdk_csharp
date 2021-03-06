using System.Collections.Generic;
using Bunq.Sdk.Context;
using Bunq.Sdk.Http;
using Newtonsoft.Json;

namespace Bunq.Sdk.Model.Generated
{
    /// <summary>
    /// Using this call you can retrieve information of the user you are logged in as. This includes your user id, which
    /// is referred to in endpoints.
    /// </summary>
    public class User : BunqModel
    {
        /// <summary>
        /// Endpoint constants.
        /// </summary>
        private const string ENDPOINT_URL_READ = "user/{0}";
        private const string ENDPOINT_URL_LISTING = "user";

        /// <summary>
        /// Object type.
        /// </summary>
        private const string OBJECT_TYPE = "User";

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "UserLight")]
        public UserLight UserLight { get; private set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "UserPerson")]
        public UserPerson UserPerson { get; private set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "UserCompany")]
        public UserCompany UserCompany { get; private set; }

        public static User Get(ApiContext apiContext, int userId)
        {
            return Get(apiContext, userId, new Dictionary<string, string>());
        }

        /// <summary>
        /// Get a specific user.
        /// </summary>
        public static User Get(ApiContext apiContext, int userId, IDictionary<string, string> customHeaders)
        {
            var apiClient = new ApiClient(apiContext);
            var response = apiClient.Get(string.Format(ENDPOINT_URL_READ, userId), customHeaders);

            return FromJson<User>(response.Content.ReadAsStringAsync().Result);
        }

        public static List<User> List(ApiContext apiContext)
        {
            return List(apiContext, new Dictionary<string, string>());
        }

        /// <summary>
        /// Get a collection of all available users.
        /// </summary>
        public static List<User> List(ApiContext apiContext, IDictionary<string, string> customHeaders)
        {
            var apiClient = new ApiClient(apiContext);
            var response = apiClient.Get(ENDPOINT_URL_LISTING, customHeaders);

            return FromJsonList<User>(response.Content.ReadAsStringAsync().Result);
        }
    }
}
