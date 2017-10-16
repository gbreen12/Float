using Newtonsoft.Json;
using RestSharp.Deserializers;
using System;

namespace Float.Models
{
    public class FloatTask : BaseModel
    {
        [DeserializeAs(Name = "task_id")]
        public override int ID { get; set; }

        [JsonProperty("end_date")]
        [JsonConverter(typeof(DateConverter))]
        public DateTime EndDate
        {
            get => _endDate;
            set => SetProperty(ref _serializeEndDate, ref _endDate, value);
        }
        [JsonProperty("hours")]
        public decimal Hours
        {
            get => _hours;
            set => SetProperty(ref _serializeHours, ref _hours, value);
        }
        [JsonProperty("people_id")]
        public int PeopleId
        {
            get => _peopleId;
            set => SetProperty(ref _serializePeopleId, ref _peopleId, value);
        }
        [JsonProperty("priority")]
        [JsonConverter(typeof(BoolConverter))]
        public bool Priority
        {
            get => _priority;
            set => SetProperty(ref _serializePriority, ref _priority, value);
        }
        [JsonProperty("project_id")]
        public int ProjectId
        {
            get => _projectId;
            set => SetProperty(ref _serializeProjectId, ref _projectId, value);
        }
        [JsonProperty("name")]
        public string Name
        {
            get => _name;
            set => SetProperty(ref _serializeName, ref _name, value);
        }
        [JsonProperty("notes")]
        public string Notes
        {
            get => _notes;
            set => SetProperty(ref _serializeNotes, ref _notes, value);
        }
        [JsonProperty("repeat_end_date")]
        [JsonConverter(typeof(DateConverter))]
        public DateTime? RepeatEndDate
        {
            get => _repeatEndDate;
            set => SetProperty(ref _serializeRepeatEndDate, ref _repeatEndDate, value);
        }
        [JsonProperty("repeat_state")]
        public RepeatState RepeatState
        {
            get => _repeatState;
            set => SetProperty(ref _serializeRepeatState, ref _repeatState, value);
        }
        [JsonProperty("start_date")]
        [JsonConverter(typeof(DateConverter))]
        public DateTime StartDate
        {
            get => _startDate;
            set => SetProperty(ref _serializeStartDate, ref _startDate, value);
        }
        [JsonProperty("start_time")]
        [JsonConverter(typeof(TimeConverter))]
        public DateTime? StartTime
        {
            get => _startTime;
            set => SetProperty(ref _serializeStartTime, ref _startTime, value);
        }

        public int CreatedBy { get; set; }
        public DateTime Created { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime Modified { get; set; }

        private DateTime _endDate;
        private bool _serializeEndDate;
        public bool ShouldSerializeEndDate() => FullUpdate || _serializeEndDate;

        private decimal _hours;
        private bool _serializeHours;
        public bool ShouldSerializeHours() => FullUpdate || _serializeHours;

        private int _peopleId;
        private bool _serializePeopleId;
        public bool ShouldSerializePeopleId() => FullUpdate || _serializePeopleId;

        private bool _priority;
        private bool _serializePriority;
        public bool ShouldSerializePriority() => FullUpdate || _serializePriority;

        private int _projectId;
        private bool _serializeProjectId;
        public bool ShouldSerializeProjectId() => FullUpdate || _serializeProjectId;

        private string _name;
        private bool _serializeName;
        public bool ShouldSerializeName() => FullUpdate || _serializeName;

        private string _notes;
        private bool _serializeNotes;
        public bool ShouldSerializeNotes() => FullUpdate || _serializeNotes;

        private DateTime? _repeatEndDate;
        private bool _serializeRepeatEndDate;
        public bool ShouldSerializeRepeatEndDate() => FullUpdate || _serializeRepeatEndDate;

        private RepeatState _repeatState;
        private bool _serializeRepeatState;
        public bool ShouldSerializeRepeatState() => FullUpdate || _serializeRepeatState;

        private DateTime _startDate;
        private bool _serializeStartDate;
        public bool ShouldSerializeStartDate() => FullUpdate || _serializeStartDate;

        private DateTime? _startTime;
        private bool _serializeStartTime;
        public bool ShouldSerializeStartTime() => FullUpdate || _serializeStartTime;

        public override void ClearDirty()
        {
            _serializeEndDate = false;
            _serializeHours = false;
            _serializeName = false;
            _serializeNotes = false;
            _serializePeopleId = false;
            _serializePriority = false;
            _serializeProjectId = false;
            _serializeRepeatEndDate = false;
            _serializeRepeatState = false;
            _serializeStartDate = false;
            _serializeStartTime = false;
        }
    }
}
