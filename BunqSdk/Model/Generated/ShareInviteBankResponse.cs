using System.Collections.Generic;
using System.Text;
using Bunq.Sdk.Context;
using Bunq.Sdk.Http;
using Bunq.Sdk.Json;
using Bunq.Sdk.Model.Generated.Object;
using Newtonsoft.Json;

namespace Bunq.Sdk.Model.Generated
{
    /// <summary>
    /// Used to view or respond to shares a user was invited to. See 'share-invite-bank-inquiry' for more information
    /// about the inquiring endpoint.
    /// </summary>
    public class ShareInviteBankResponse : BunqModel
    {
        /// <summary>
        /// Field constants.
        /// </summary>
        public const string FIELD_STATUS = "status";

        /// <summary>
        /// Endpoint constants.
        /// </summary>
        private const string ENDPOINT_URL_READ = "user/{0}/share-invite-bank-response/{1}";
        private const string ENDPOINT_URL_UPDATE = "user/{0}/share-invite-bank-response/{1}";
        private const string ENDPOINT_URL_LISTING = "user/{0}/share-invite-bank-response";

        /// <summary>
        /// Object type.
        /// </summary>
        private const string OBJECT_TYPE = "ShareInviteBankResponse";

        /// <summary>
        /// The monetary account and user who created the share.
        /// </summary>
        [JsonProperty(PropertyName = "counter_alias")]
        public MonetaryAccountReference CounterAlias { get; private set; }

        /// <summary>
        /// The user who cancelled the share if it has been revoked or rejected.
        /// </summary>
        [JsonProperty(PropertyName = "user_alias_cancelled")]
        public LabelUser UserAliasCancelled { get; private set; }

        /// <summary>
        /// The id of the monetary account the ACCEPTED share applies to. null otherwise.
        /// </summary>
        [JsonProperty(PropertyName = "monetary_account_id")]
        public int? MonetaryAccountId { get; private set; }

        /// <summary>
        /// The id of the draft share invite bank.
        /// </summary>
        [JsonProperty(PropertyName = "draft_share_invite_bank_id")]
        public int? DraftShareInviteBankId { get; private set; }

        /// <summary>
        /// The share details.
        /// </summary>
        [JsonProperty(PropertyName = "share_detail")]
        public ShareDetail ShareDetail { get; private set; }

        /// <summary>
        /// The status of the share. Can be ACCEPTED (other user scans the QR and accepts the share), REVOKED (other
        /// user scans the QR but denies the share), CANCELLED (other user cancels an existing share), EXPIRED (other
        /// user did not react before expiration), PENDING (share is waiting for reply by the other user) or REJECTED
        /// (share initiated by other user but rejected). Once the share's status becomes REVOKED, CANCELLED, EXPIRED or
        /// REJECTED, its status can no longer be updated.
        /// </summary>
        [JsonProperty(PropertyName = "status")]
        public string Status { get; private set; }

        /// <summary>
        /// The start date of this share.
        /// </summary>
        [JsonProperty(PropertyName = "start_date")]
        public string StartDate { get; private set; }

        /// <summary>
        /// The expiration date of this share.
        /// </summary>
        [JsonProperty(PropertyName = "end_date")]
        public string EndDate { get; private set; }

        /// <summary>
        /// The description of this share. It is basically the monetary account description.
        /// </summary>
        [JsonProperty(PropertyName = "description")]
        public string Description { get; private set; }

        public static ShareInviteBankResponse Get(ApiContext apiContext, int userId, int shareInviteBankResponseId)
        {
            return Get(apiContext, userId, shareInviteBankResponseId, new Dictionary<string, string>());
        }

        /// <summary>
        /// Return the details of a specific share a user was invited to.
        /// </summary>
        public static ShareInviteBankResponse Get(ApiContext apiContext, int userId, int shareInviteBankResponseId,
            IDictionary<string, string> customHeaders)
        {
            var apiClient = new ApiClient(apiContext);
            var response = apiClient.Get(string.Format(ENDPOINT_URL_READ, userId, shareInviteBankResponseId),
                customHeaders);

            return FromJson<ShareInviteBankResponse>(response.Content.ReadAsStringAsync().Result, OBJECT_TYPE);
        }

        public static ShareInviteBankResponse Update(ApiContext apiContext, IDictionary<string, object> requestMap,
            int userId, int shareInviteBankResponseId)
        {
            return Update(apiContext, requestMap, userId, shareInviteBankResponseId, new Dictionary<string, string>());
        }

        /// <summary>
        /// Accept or reject a share a user was invited to.
        /// </summary>
        public static ShareInviteBankResponse Update(ApiContext apiContext, IDictionary<string, object> requestMap,
            int userId, int shareInviteBankResponseId, IDictionary<string, string> customHeaders)
        {
            var apiClient = new ApiClient(apiContext);
            var requestBytes = Encoding.UTF8.GetBytes(BunqJsonConvert.SerializeObject(requestMap));
            var response = apiClient.Put(string.Format(ENDPOINT_URL_UPDATE, userId, shareInviteBankResponseId),
                requestBytes, customHeaders);

            return FromJson<ShareInviteBankResponse>(response.Content.ReadAsStringAsync().Result, OBJECT_TYPE);
        }

        public static List<ShareInviteBankResponse> List(ApiContext apiContext, int userId)
        {
            return List(apiContext, userId, new Dictionary<string, string>());
        }

        /// <summary>
        /// Return all the shares a user was invited to.
        /// </summary>
        public static List<ShareInviteBankResponse> List(ApiContext apiContext, int userId,
            IDictionary<string, string> customHeaders)
        {
            var apiClient = new ApiClient(apiContext);
            var response = apiClient.Get(string.Format(ENDPOINT_URL_LISTING, userId), customHeaders);

            return FromJsonList<ShareInviteBankResponse>(response.Content.ReadAsStringAsync().Result, OBJECT_TYPE);
        }
    }
}
