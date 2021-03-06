using System.Collections.Generic;
using Bunq.Sdk.Context;
using Bunq.Sdk.Http;
using Bunq.Sdk.Model.Generated.Object;
using Newtonsoft.Json;

namespace Bunq.Sdk.Model.Generated
{
    /// <summary>
    /// This call is used to upload an attachment that can be referenced to as an avatar (through the Avatar endpoint)
    /// or in a tab sent. Attachments supported are png, jpg and gif.
    /// </summary>
    public class AttachmentPublic : BunqModel
    {
        /// <summary>
        /// Endpoint constants.
        /// </summary>
        private const string ENDPOINT_URL_CREATE = "attachment-public";
        private const string ENDPOINT_URL_READ = "attachment-public/{0}";

        /// <summary>
        /// Object type.
        /// </summary>
        private const string OBJECT_TYPE = "AttachmentPublic";

        /// <summary>
        /// The UUID of the attachment.
        /// </summary>
        [JsonProperty(PropertyName = "uuid")]
        public string Uuid { get; private set; }

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

        public static string Create(ApiContext apiContext, byte[] requestBytes)
        {
            return Create(apiContext, requestBytes, new Dictionary<string, string>());
        }

        /// <summary>
        /// Create a new public attachment. Create a POST request with a payload that contains a binary representation
        /// of the file, without any JSON wrapping. Make sure you define the MIME type (i.e. image/jpeg, or image/png)
        /// in the Content-Type header. You are required to provide a description of the attachment using the
        /// X-Bunq-Attachment-Description header.
        /// </summary>
        public static string Create(ApiContext apiContext, byte[] requestBytes,
            IDictionary<string, string> customHeaders)
        {
            var apiClient = new ApiClient(apiContext);
            var response = apiClient.Post(ENDPOINT_URL_CREATE, requestBytes, customHeaders);

            return ProcessForUuid(response.Content.ReadAsStringAsync().Result);
        }

        public static AttachmentPublic Get(ApiContext apiContext, string attachmentPublicUuid)
        {
            return Get(apiContext, attachmentPublicUuid, new Dictionary<string, string>());
        }

        /// <summary>
        /// Get a specific attachment's metadata through its UUID. The Content-Type header of the response will describe
        /// the MIME type of the attachment file.
        /// </summary>
        public static AttachmentPublic Get(ApiContext apiContext, string attachmentPublicUuid,
            IDictionary<string, string> customHeaders)
        {
            var apiClient = new ApiClient(apiContext);
            var response = apiClient.Get(string.Format(ENDPOINT_URL_READ, attachmentPublicUuid), customHeaders);

            return FromJson<AttachmentPublic>(response.Content.ReadAsStringAsync().Result, OBJECT_TYPE);
        }
    }
}
