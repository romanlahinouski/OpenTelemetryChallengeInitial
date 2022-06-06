using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace GuestManagement.Domain.Base
{
    public class BusinessRuleValidationException: Exception
    {
        public string Message { get; }
        
        
       
        public BusinessRuleValidationException(string message)
        {
           Message = message;
        }

        // public void AddValidationResult(ValidationResult invalidResult)
        // {
        //     InvalidResults.Add(invalidResult);
        // }

    }
}
