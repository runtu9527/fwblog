using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace fwblog.Entity
{
    public class ApiResponse
    {
        public int code { get; set; }
        public string msg { get; set; }
        public object data { get; set; }
        public ApiResponse()
        {
            code = 0;
            msg = "";
            data = null;
        }
    }
}
