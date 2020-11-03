using System;
using System.Collections.Generic;
using System.Text;

namespace SP.Core.ProcessResult
{
    public class ResultError
    {
        public ResultError(string parameterName, string errorMessage)
        {
            ParameterName = parameterName;
            ErrorMessage = errorMessage;
        }
        public string ParameterName
        {
            get;
            private set;
        }
        public string ErrorMessage
        {
            get;
            private set;
        }
    }
}
