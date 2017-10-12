using Newtonsoft.Json;
using System;

namespace Float.Models
{
    public class FloatTask
    {
        public int TaskId { get; set; }

        [JsonProperty("end_date")]
        [JsonConverter(typeof(DateConverter))]
        public DateTime EndDate { get; set; }
        [JsonProperty("hours")]
        public decimal Hours { get; set; }
        [JsonProperty("people_id")]
        public int PeopleId { get; set; }
        [JsonProperty("priority")]
        [JsonConverter(typeof(BoolConverter))]
        public bool Priority { get; set; }
        [JsonProperty("project_id")]
        public int ProjectId { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("notes")]
        public string Notes { get; set; }
        [JsonProperty("repeat_end_date")]
        [JsonConverter(typeof(DateConverter))]
        public DateTime? RepeatEndDate { get; set; }
        [JsonProperty("repeat_state")]
        public RepeatState RepeatState { get; set; }
        [JsonProperty("start_date")]
        [JsonConverter(typeof(DateConverter))]
        public DateTime StartDate { get; set; }
        [JsonProperty("start_time")]
        [JsonConverter(typeof(TimeConverter))]
        public DateTime? StartTime { get; set; }

        public int CreatedBy { get; set; }
        public DateTime Created { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime Modified { get; set; }
    }
}
