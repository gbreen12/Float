using Newtonsoft.Json;
using RestSharp.Deserializers;
using System;
using System.Collections.Generic;

namespace Float.Models
{
    public class Project : BaseModel
    {
        [DeserializeAs(Name = "project_id")]
        public override int ID { get; set; }

        [JsonProperty("active")]
        [JsonConverter(typeof(BoolConverter))]
        public bool Active
        {
            get => _active;
            set => SetProperty(ref _serializeActive, ref _active, value);
        }
        [JsonProperty("all_pms_schedule")]
        public bool AllPmsSchedule
        {
            get => _allPmsSchedule;
            set => SetProperty(ref _serializeAllPmsSchedule, ref _allPmsSchedule, value);
        }
        [JsonProperty("client_id")]
        public int? ClientId
        {
            get => _clientId;
            set => SetProperty(ref _serializeClientId, ref _clientId, value);
        }
        [JsonProperty("color")]
        public string Color
        {
            get => _color;
            set => SetProperty(ref _serializeColor, ref _color, value);
        }
        [JsonProperty("name")]
        public string Name
        {
            get => _name;
            set => SetProperty(ref _serializeName, ref _name, value);
        }
        [JsonProperty("non_billable")]
        [JsonConverter(typeof(BoolConverter))]
        public bool NonBillable
        {
            get => _nonBillable;
            set => SetProperty(ref _serializeNonBillable, ref _nonBillable, value);
        }
        [JsonProperty("notes")]
        public string Notes
        {
            get => _notes;
            set => SetProperty(ref _serializeNotes, ref _notes, value);
        }
        [JsonProperty("project_manager")]
        public int? ProjectManager
        {
            get => _projectManager;
            set => SetProperty(ref _serializeProjectManager, ref _projectManager, value);
        }
        [JsonProperty("tags")]
        public List<string> Tags { get; set; }
        [JsonProperty("tentative")]
        [JsonConverter(typeof(BoolConverter))]
        public bool Tentative
        {
            get => _tentative;
            set => SetProperty(ref _serializeTentative, ref _tentative, value);
        }

        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }

        private bool _active;
        private bool _serializeActive;
        public bool ShouldSerializeActive() => FullUpdate || _serializeActive;

        private bool _allPmsSchedule;
        private bool _serializeAllPmsSchedule;
        public bool ShouldSerializeAllPmsSchedule() => FullUpdate || _serializeAllPmsSchedule;

        private int? _clientId;
        private bool _serializeClientId;
        public bool ShouldSerializeClientId() => FullUpdate || _serializeClientId;

        private string _color;
        private bool _serializeColor;
        public bool ShouldSerializeColor() => !string.IsNullOrEmpty(Color) && (FullUpdate || _serializeColor);

        private string _name;
        private bool _serializeName;
        public bool ShouldSerializeName() => FullUpdate || _serializeName;

        private bool _nonBillable;
        private bool _serializeNonBillable;
        public bool ShouldSerializeNonBillable() => FullUpdate || _serializeNonBillable;

        private string _notes;
        private bool _serializeNotes;
        public bool ShouldSerializeNotes() => FullUpdate || _serializeNotes;

        private int? _projectManager;
        private bool _serializeProjectManager;
        public bool ShouldSerializeProjectManager() => FullUpdate || _serializeProjectManager;

        private bool _tentative;
        private bool _serializeTentative;
        public bool ShouldSerializeTentative() => FullUpdate || _serializeTentative;

        public bool ShouldSerializeTags() => ID == 0;

        public override void ClearDirty()
        {
            _serializeActive = false;
            _serializeAllPmsSchedule = false;
            _serializeClientId = false;
            _serializeColor = false;
            _serializeName = false;
            _serializeNonBillable = false;
            _serializeNotes = false;
            _serializeProjectManager = false;
            _serializeTentative = false;
        }
    }
}
