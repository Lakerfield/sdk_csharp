using Newtonsoft.Json;

namespace Bunq.Sdk.Model.Generated.Object
{
    /// <summary>
    /// </summary>
    public class BunqId : BunqModel
    {
        /// <summary>
        /// An integer ID of an object. Unique per object type.
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public int? Id { get; set; }

        public BunqId(int? id)
        {
            Id = id;
        }
    }
}
