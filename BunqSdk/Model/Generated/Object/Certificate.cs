using Newtonsoft.Json;

namespace Bunq.Sdk.Model.Generated.Object
{
    /// <summary>
    /// </summary>
    public class Certificate : BunqModel
    {
        /// <summary>
        /// A single certificate in the chain in .PEM format.
        /// </summary>
        [JsonProperty(PropertyName = "certificate")]
        public string CertificateString { get; set; }

        public Certificate(string certificateString)
        {
            CertificateString = certificateString;
        }
    }
}
