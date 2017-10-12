using Newtonsoft.Json;

namespace Float.Models
{
    public class PersonTag
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("type")]
        public TagType Type { get; set; }
    }
}
