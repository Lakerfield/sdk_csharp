using System.Collections.Generic;
using Bunq.Sdk.Context;
using Bunq.Sdk.Http;
using Bunq.Sdk.Model.Generated.Object;
using Newtonsoft.Json;

namespace Bunq.Sdk.Model.Generated
{
    /// <summary>
    /// This call is used to view an attachment that is linked to a tab.
    /// </summary>
    public class TabAttachmentTab : BunqModel
    {
        /// <summary>
        /// Endpoint constants.
        /// </summary>
        private const string ENDPOINT_URL_READ = "tab/{0}/attachment/{1}";

        /// <summary>
        /// Object type.
        /// </summary>
        private const string OBJECT_TYPE = "TabAttachmentTab";

        /// <summary>
        /// The id of the attachment.
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public int? Id { get; private set; }

        /// <summary>
        /// The timestamp of the attachment's creation.
        /// </summary>
        [JsonProperty(PropertyName = "created")]
        public string Created { get; private set; }

        /// <summary>
        /// The timestamp of the attachment's last update.
        /// </summary>
        [JsonProperty(PropertyName = "updated")]
        public string Updated { get; private set; }

        /// <summary>
        /// The attachment.
        /// </summary>
        [JsonProperty(PropertyName = "attachment")]
        public Attachment Attachment { get; private set; }

        public static TabAttachmentTab Get(ApiContext apiContext, string tabUuid, int tabAttachmentTabId)
        {
            return Get(apiContext, tabUuid, tabAttachmentTabId, new Dictionary<string, string>());
        }

        /// <summary>
        /// Get a specific attachment. The header of the response contains the content-type of the attachment.
        /// </summary>
        public static TabAttachmentTab Get(ApiContext apiContext, string tabUuid, int tabAttachmentTabId,
            IDictionary<string, string> customHeaders)
        {
            var apiClient = new ApiClient(apiContext);
            var response = apiClient.Get(string.Format(ENDPOINT_URL_READ, tabUuid, tabAttachmentTabId), customHeaders);

            return FromJson<TabAttachmentTab>(response.Content.ReadAsStringAsync().Result, OBJECT_TYPE);
        }
    }
}
