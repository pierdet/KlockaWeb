using System;
using System.Collections.Generic;
using System.Text;

namespace KlockaLib.Models
{
    public class ConnectionValidatorResponse
    {
        public string Connection { get; set; }
        public bool Success { get; set; }
        public string ErrorMessage { get; set; }
    }
}
