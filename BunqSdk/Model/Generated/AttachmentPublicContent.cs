using System.Collections.Generic;
using Bunq.Sdk.Context;
using Bunq.Sdk.Http;

namespace Bunq.Sdk.Model.Generated
{
    /// <summary>
    /// Fetch the raw content of a public attachment with given ID. The raw content is the binary representation of a
    /// file, without any JSON wrapping.
    /// </summary>
    public class AttachmentPublicContent : BunqModel
    {
        /// <summary>
        /// Endpoint constants.
        /// </summary>
        private const string ENDPOINT_URL_LISTING = "attachment-public/{0}/content";

        /// <summary>
        /// Object type.
        /// </summary>
        private const string OBJECT_TYPE = "AttachmentPublicContent";

        public static byte[] List(ApiContext apiContext, string attachmentPublicUuid)
        {
            return List(apiContext, attachmentPublicUuid, new Dictionary<string, string>());
        }

        /// <summary>
        /// Get the raw content of a specific attachment.
        /// </summary>
        public static byte[] List(ApiContext apiContext, string attachmentPublicUuid,
            IDictionary<string, string> customHeaders)
        {
            var apiClient = new ApiClient(apiContext);

            return apiClient.Get(string.Format(ENDPOINT_URL_LISTING, attachmentPublicUuid), customHeaders).Content
                .ReadAsByteArrayAsync().Result;
        }
    }
}
