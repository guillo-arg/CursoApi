using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CursoApi.Helpers
{
    public class LogicResponse
    {
        public LogicResponse()
        {
            Success = false;
            Message = "";
        }
        public bool Success { get; set; }
        public string Message { get; set; }
    }
}
