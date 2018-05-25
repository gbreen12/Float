using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace Float
{
    public class ValidationException : Exception
    {
        public IEnumerable<ValidationError> ValidationErrors { get; set; } = new List<ValidationError>();

        public override string Message => string.Join(Environment.NewLine, ValidationErrors.Select(x => $"{x.Field}: {x.Message}"));

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            var tempInfo = new SerializationInfo(GetType(), new FormatterConverter());
            base.GetObjectData(tempInfo, context);
            foreach (var entry in tempInfo)
                if (entry.Name != "Message")
                    info.AddValue(entry.Name, entry.Value, entry.ObjectType);
                else
                    info.AddValue("Message", Message);
        }
    }

    public class ValidationError
    {
        public string Field { get; set; }
        public string Message { get; set; }
    }
}
