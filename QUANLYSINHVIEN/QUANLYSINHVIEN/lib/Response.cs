using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QUANLYSINHVIEN
{
    public class Response
    {
        public bool success { get; set; }
        public string message { get; set; }
        public Response(bool success, string message)
        {
            this.success = success;
            this.message = message;
        }
    }
}
