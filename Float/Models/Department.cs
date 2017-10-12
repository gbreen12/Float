using Newtonsoft.Json;

namespace Float.Models
{
    public class Department
    {
        [JsonProperty("department_id")]
        public int DepartmentId { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
