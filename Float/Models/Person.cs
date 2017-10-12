using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Float.Models
{
    public class Person
    {
        public int PeopleId { get; set; }

        [JsonProperty("active")]
        public bool Active { get; set; }
        [JsonProperty("auto_email")]
        [JsonConverter(typeof(BoolConverter))]
        public bool AutoEmail { get; set; }
        public string AvatarFile { get; set; }
        [JsonProperty("contractor")]
        public bool Contractor { get; set; }
        [JsonProperty("department")]
        public Department Department { get; set; }
        [JsonProperty("email")]
        public string Email { get; set; }
        [JsonProperty("employee_type")]
        public EmployeeType EmployeeType { get; set; }
        [JsonProperty("end_date")]
        [JsonConverter(typeof(DateConverter))]
        public DateTime? EndDate { get; set; }
        [JsonProperty("job_title")]
        public string JobTitle { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("non_work_days")]
        public List<WeekDay> NonWorkDays { get; set; }
        [JsonProperty("notes")]
        public string Notes { get; set; }
        [JsonProperty("start_date")]
        [JsonConverter(typeof(DateConverter))]
        public DateTime? StartDate { get; set; }
        [JsonProperty("tags")]
        public List<PersonTag> Tags { get; set; }
        [JsonProperty("work_day_hours")]
        public decimal? WorkDayHours { get; set; }

        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
    }
}
