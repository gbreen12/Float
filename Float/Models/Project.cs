﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Float.Models
{
    public class Project
    {
        public int ProjectId { get; set; }

        [JsonProperty("active")]
        public bool Active { get; set; }
        [JsonProperty("all_pms_schedule")]
        public bool AllPmsSchedule { get; set; }
        [JsonProperty("client_id")]
        public int ClientId { get; set; }
        [JsonProperty("color")]
        public string Color { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("non_billable")]
        public bool NonBillable { get; set; }
        [JsonProperty("notes")]
        public string Notes { get; set; }
        [JsonProperty("project_manager")]
        public int ProjectManager { get; set; }
        [JsonProperty("tags")]
        public List<string> Tags { get; set; }
        [JsonProperty("tentative")]
        public bool Tentative { get; set; }

        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
    }
}