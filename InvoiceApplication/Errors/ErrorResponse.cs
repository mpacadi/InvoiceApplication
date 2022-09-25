using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InvoiceApplication.ViewModel
{
    public class ErrorResponse
    {
        public string Key { get; set; }
        public string Value { get; set; }

        public ErrorResponse(string key, string value)
        {
            Key = key;
            Value = value;
        }

        public override string ToString()
        {
            return this.Key + " : " + this.Value;
        }
    }
}