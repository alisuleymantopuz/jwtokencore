using System;
using System.Collections.Generic;
using System.Text;

namespace jwtokencore.Api.Core.Dto
{
    public class ProcessorResponseMessage
    {
        protected ProcessorResponseMessage(bool success = false, string message = null)
        {
            Success = success;
            Message = message;
        }

        public bool Success { get; }
        public string Message { get; }
    }
}
