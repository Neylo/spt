using System;
using System.Collections.Generic;
using System.Text;

namespace SP.Core.ProcessResult
{
    public class ProcessResult<T>
    {
        public ProcessResult()
        {
            Errors = new List<ResultError>();
        }
        public List<ResultError> Errors
        {
            get;
            private set;
        }
        public void AddError(string message)
        {
            Errors.Add(new ResultError(string.Empty, message));
        }
        public void AddError(string name, string message)
        {
            Errors.Add(new ResultError(name, message));
        }
        public bool HasErrors
        {
            get { return Errors != null && Errors.Count > 0; }
        }

        public string ErrorMessage
        {
            get
            {
                string msg = string.Empty;
                if (Errors != null && Errors.Count > 0)
                {
                    foreach (var item in Errors)
                    {
                        if (msg != string.Empty)
                            msg += "\r\n";
                        msg += item.ErrorMessage;
                    }
                }
                return msg;
            }
        }
        public T Result { get; set; }
    }
}
