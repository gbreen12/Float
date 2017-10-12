using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Float
{
    public class ValidationException : Exception
    {
        public IEnumerable<ValidationError> ValidationErrors { get; set; }
        public ValidationException(string body)
        {
            ValidationErrors = JsonConvert.DeserializeObject<List<ValidationError>>(body);
        }

        public ValidationException()
        {
            ValidationErrors = new List<ValidationError>();
        }

        public ValidationException(IEnumerable<ValidationError> validationErrors)
        {
            ValidationErrors = validationErrors;
        }
    }

    public class ValidationError
    {
        public string Field { get; set; }
        public string Message { get; set; }
    }
}
