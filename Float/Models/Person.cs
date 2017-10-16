using Newtonsoft.Json;
using RestSharp.Deserializers;
using System;
using System.Collections.Generic;

namespace Float.Models
{
    public class Person : BaseModel
    {
        public Person()
        {
            _employeeType = EmployeeType.FullTime;
        }

        //READ ONLY
        [DeserializeAs(Name = "people_id")]
        public override int ID { get; set; }

        [JsonProperty("active")]
        public bool Active
        {
            get => _isActive;
            set => SetProperty(ref _serializeIsActive, ref _isActive, value);
        }
        [JsonProperty("auto_email")]
        [JsonConverter(typeof(BoolConverter))]
        public bool AutoEmail
        {
            get => _autoEmail;
            set => SetProperty(ref _serializeAutoEmail, ref _autoEmail, value);
        }
        //READ ONLY
        public string AvatarFile { get; set; }
        [JsonProperty("contractor")]
        public bool Contractor
        {
            get => _contractor;
            set => SetProperty(ref _serializeContractor, ref _contractor, value);
        }
        [JsonProperty("department")]
        public Department Department
        {
            get => _department;
            set => SetProperty(ref _serializeDepartment, ref _department, value);
        }
        [JsonProperty("email")]
        public string Email
        {
            get => _email;
            set => SetProperty(ref _serializeEmail, ref _email, value);
        }
        [JsonProperty("employee_type")]
        public EmployeeType EmployeeType
        {
            get => _employeeType;
            set => SetProperty(ref _serializeEmployeeType, ref _employeeType, value);
        }
        [JsonProperty("end_date")]
        [JsonConverter(typeof(DateConverter))]
        public DateTime? EndDate
        {
            get => _endDate;
            set => SetProperty(ref _serializeEndDate, ref _endDate, value);
        }
        [JsonProperty("job_title")]
        public string JobTitle
        {
            get => _jobTitle;
            set => SetProperty(ref _serializeJobTitle, ref _jobTitle, value);
        }
        [JsonProperty("name")]
        public string Name
        {
            get => _name;
            set => SetProperty(ref _serializeName, ref _name, value);
        }
        [JsonProperty("non_work_days")]
        public List<WeekDay> NonWorkDays { get; set; }
        [JsonProperty("notes")]
        public string Notes
        {
            get => _notes;
            set => SetProperty(ref _serializeNotes, ref _notes, value);
        }
        [JsonProperty("start_date")]
        [JsonConverter(typeof(DateConverter))]
        public DateTime? StartDate
        {
            get => _startDate;
            set => SetProperty(ref _serializeStartDate, ref _startDate, value);
        }
        [JsonProperty("tags")]
        public List<PersonTag> Tags { get; set; }
        [JsonProperty("work_day_hours")]
        public decimal? WorkDayHours
        {
            get => _workDayHours;
            set => SetProperty(ref _serializeWorkDayHours, ref _workDayHours, value);
        }

        //READ ONLY
        public DateTime Created { get; set; }
        //READ ONLY
        public DateTime Modified { get; set; }

        private bool _isActive;
        private bool _serializeIsActive;
        public bool ShouldSerializeIsActive() => FullUpdate || _serializeIsActive;

        private bool _autoEmail;
        private bool _serializeAutoEmail;
        public bool ShouldSerializeAutoEmail() => FullUpdate || _serializeAutoEmail;

        private bool _contractor;
        private bool _serializeContractor;
        public bool ShouldSerializeContractor() => FullUpdate || _serializeContractor;

        private Department _department;
        private bool _serializeDepartment;
        public bool ShouldSerializeDepartment() => FullUpdate || _serializeDepartment;

        private string _email;
        private bool _serializeEmail;
        public bool ShouldSerializeEmail() => FullUpdate || _serializeEmail;

        private EmployeeType _employeeType;
        private bool _serializeEmployeeType;
        public bool ShouldSerializeEmployeeType() => FullUpdate || _serializeEmployeeType;

        private DateTime? _endDate;
        private bool _serializeEndDate;
        public bool ShouldSerializeEndDate() => FullUpdate || _serializeEndDate;

        private string _jobTitle;
        private bool _serializeJobTitle;
        public bool ShouldSerializeJobTitle() => FullUpdate || _serializeJobTitle;

        private string _name;
        private bool _serializeName;
        public bool ShouldSerializeName() => FullUpdate || _serializeName;

        private string _notes;
        private bool _serializeNotes;
        public bool ShouldSerializeNotes() => FullUpdate || _serializeNotes;

        private DateTime? _startDate;
        private bool _serializeStartDate;
        public bool ShouldSerializeStartDate() => FullUpdate || _serializeStartDate;

        private decimal? _workDayHours;
        private bool _serializeWorkDayHours;
        public bool ShouldSerializeWorkDayHours() => FullUpdate || _serializeWorkDayHours;

        public override void ClearDirty()
        {
            _serializeAutoEmail = false;
            _serializeContractor = false;
            _serializeDepartment = false;
            _serializeEmail = false;
            _serializeEmployeeType = false;
            _serializeEndDate = false;
            _serializeIsActive = false;
            _serializeJobTitle = false;
            _serializeName = false;
            _serializeNotes = false;
            _serializeStartDate = false;
            _serializeWorkDayHours = false;
        }
    }
}
