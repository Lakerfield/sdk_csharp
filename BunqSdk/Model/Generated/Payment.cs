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
    /// Using Payment, you can send payments to bunq and non-bunq users from your bunq MonetaryAccounts. This can be
    /// done using bunq Aliases or IBAN Aliases. When transferring money to other bunq MonetaryAccounts you can also
    /// refer to Attachments. These will be received by the counter-party as part of the Payment. You can also retrieve
    /// a single Payment or all executed Payments of a specific monetary account.
    /// </summary>
    public class Payment : BunqModel
    {
        /// <summary>
        /// Field constants.
        /// </summary>
        public const string FIELD_AMOUNT = "amount";
        public const string FIELD_COUNTERPARTY_ALIAS = "counterparty_alias";
        public const string FIELD_DESCRIPTION = "description";
        public const string FIELD_ATTACHMENT = "attachment";
        public const string FIELD_MERCHANT_REFERENCE = "merchant_reference";
        public const string FIELD_ALLOW_BUNQTO = "allow_bunqto";
        public const string FIELD_BUNQTO_STATUS = "bunqto_status";

        /// <summary>
        /// Endpoint constants.
        /// </summary>
        private const string ENDPOINT_URL_CREATE = "user/{0}/monetary-account/{1}/payment";
        private const string ENDPOINT_URL_READ = "user/{0}/monetary-account/{1}/payment/{2}";
        private const string ENDPOINT_URL_LISTING = "user/{0}/monetary-account/{1}/payment";

        /// <summary>
        /// Object type.
        /// </summary>
        private const string OBJECT_TYPE = "Payment";

        /// <summary>
        /// The id of the created Payment.
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public int? Id { get; private set; }

        /// <summary>
        /// The timestamp when the Payment was done.
        /// </summary>
        [JsonProperty(PropertyName = "created")]
        public string Created { get; private set; }

        /// <summary>
        /// The timestamp when the Payment was last updated (will be updated when chat messages are received).
        /// </summary>
        [JsonProperty(PropertyName = "updated")]
        public string Updated { get; private set; }

        /// <summary>
        /// The id of the MonetaryAccount the Payment was made to or from (depending on whether this is an incoming or
        /// outgoing Payment).
        /// </summary>
        [JsonProperty(PropertyName = "monetary_account_id")]
        public int? MonetaryAccountId { get; private set; }

        /// <summary>
        /// The Amount transferred by the Payment. Will be negative for outgoing Payments and positive for incoming
        /// Payments (relative to the MonetaryAccount indicated by monetary_account_id).
        /// </summary>
        [JsonProperty(PropertyName = "amount")]
        public Amount Amount { get; private set; }

        /// <summary>
        /// The LabelMonetaryAccount containing the public information of 'this' (party) side of the Payment.
        /// </summary>
        [JsonProperty(PropertyName = "alias")]
        public MonetaryAccountReference Alias { get; private set; }

        /// <summary>
        /// The LabelMonetaryAccount containing the public information of the other (counterparty) side of the Payment.
        /// </summary>
        [JsonProperty(PropertyName = "counterparty_alias")]
        public MonetaryAccountReference CounterpartyAlias { get; private set; }

        /// <summary>
        /// The description for the Payment. Maximum 140 characters for Payments to external IBANs, 9000 characters for
        /// Payments to only other bunq MonetaryAccounts.
        /// </summary>
        [JsonProperty(PropertyName = "description")]
        public string Description { get; private set; }

        /// <summary>
        /// The type of Payment, can be BUNQ, EBA_SCT, EBA_SDD, IDEAL, SWIFT or FIS (card).
        /// </summary>
        [JsonProperty(PropertyName = "type")]
        public string Type { get; private set; }

        /// <summary>
        /// The sub-type of the Payment, can be PAYMENT, WITHDRAWAL, REVERSAL, REQUEST, BILLING, SCT, SDD or NLO.
        /// </summary>
        [JsonProperty(PropertyName = "sub_type")]
        public string SubType { get; private set; }

        /// <summary>
        /// The status of the bunq.to payment.
        /// </summary>
        [JsonProperty(PropertyName = "bunqto_status")]
        public string BunqtoStatus { get; private set; }

        /// <summary>
        /// The sub status of the bunq.to payment.
        /// </summary>
        [JsonProperty(PropertyName = "bunqto_sub_status")]
        public string BunqtoSubStatus { get; private set; }

        /// <summary>
        /// The status of the bunq.to payment.
        /// </summary>
        [JsonProperty(PropertyName = "bunqto_share_url")]
        public string BunqtoShareUrl { get; private set; }

        /// <summary>
        /// When bunq.to payment is about to expire.
        /// </summary>
        [JsonProperty(PropertyName = "bunqto_expiry")]
        public string BunqtoExpiry { get; private set; }

        /// <summary>
        /// The timestamp of when the bunq.to payment was responded to.
        /// </summary>
        [JsonProperty(PropertyName = "bunqto_time_responded")]
        public string BunqtoTimeResponded { get; private set; }

        /// <summary>
        /// The Attachments attached to the Payment.
        /// </summary>
        [JsonProperty(PropertyName = "attachment")]
        public List<AttachmentMonetaryAccountPayment> Attachment { get; private set; }

        /// <summary>
        /// Optional data included with the Payment specific to the merchant.
        /// </summary>
        [JsonProperty(PropertyName = "merchant_reference")]
        public string MerchantReference { get; private set; }

        /// <summary>
        /// The id of the PaymentBatch if this Payment was part of one.
        /// </summary>
        [JsonProperty(PropertyName = "batch_id")]
        public int? BatchId { get; private set; }

        /// <summary>
        /// The id of the JobScheduled if the Payment was scheduled.
        /// </summary>
        [JsonProperty(PropertyName = "scheduled_id")]
        public int? ScheduledId { get; private set; }

        /// <summary>
        /// A shipping Address provided with the Payment, currently unused.
        /// </summary>
        [JsonProperty(PropertyName = "address_shipping")]
        public Address AddressShipping { get; private set; }

        /// <summary>
        /// A billing Address provided with the Payment, currently unused.
        /// </summary>
        [JsonProperty(PropertyName = "address_billing")]
        public Address AddressBilling { get; private set; }

        /// <summary>
        /// The Geolocation where the Payment was done from.
        /// </summary>
        [JsonProperty(PropertyName = "geolocation")]
        public Geolocation Geolocation { get; private set; }

        /// <summary>
        /// Whether or not chat messages are allowed.
        /// </summary>
        [JsonProperty(PropertyName = "allow_chat")]
        public bool? AllowChat { get; private set; }

        public static int Create(ApiContext apiContext, IDictionary<string, object> requestMap, int userId,
            int monetaryAccountId)
        {
            return Create(apiContext, requestMap, userId, monetaryAccountId, new Dictionary<string, string>());
        }

        /// <summary>
        /// Create a new Payment.
        /// </summary>
        public static int Create(ApiContext apiContext, IDictionary<string, object> requestMap, int userId,
            int monetaryAccountId, IDictionary<string, string> customHeaders)
        {
            var apiClient = new ApiClient(apiContext);
            var requestBytes = Encoding.UTF8.GetBytes(BunqJsonConvert.SerializeObject(requestMap));
            var response = apiClient.Post(string.Format(ENDPOINT_URL_CREATE, userId, monetaryAccountId), requestBytes,
                customHeaders);

            return ProcessForId(response.Content.ReadAsStringAsync().Result);
        }

        public static Payment Get(ApiContext apiContext, int userId, int monetaryAccountId, int paymentId)
        {
            return Get(apiContext, userId, monetaryAccountId, paymentId, new Dictionary<string, string>());
        }

        /// <summary>
        /// Get a specific previous Payment.
        /// </summary>
        public static Payment Get(ApiContext apiContext, int userId, int monetaryAccountId, int paymentId,
            IDictionary<string, string> customHeaders)
        {
            var apiClient = new ApiClient(apiContext);
            var response = apiClient.Get(string.Format(ENDPOINT_URL_READ, userId, monetaryAccountId, paymentId),
                customHeaders);

            return FromJson<Payment>(response.Content.ReadAsStringAsync().Result, OBJECT_TYPE);
        }

        public static List<Payment> List(ApiContext apiContext, int userId, int monetaryAccountId)
        {
            return List(apiContext, userId, monetaryAccountId, new Dictionary<string, string>());
        }

        /// <summary>
        /// Get a listing of all Payments performed on a given MonetaryAccount (incoming and outgoing).
        /// </summary>
        public static List<Payment> List(ApiContext apiContext, int userId, int monetaryAccountId,
            IDictionary<string, string> customHeaders)
        {
            var apiClient = new ApiClient(apiContext);
            var response = apiClient.Get(string.Format(ENDPOINT_URL_LISTING, userId, monetaryAccountId), customHeaders);

            return FromJsonList<Payment>(response.Content.ReadAsStringAsync().Result, OBJECT_TYPE);
        }
    }
}
