using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTOs
{
    public class ServiceResult
    {
        public bool Success { get; set; }
        public object Data { get; set; }
        public HttpStatusCode StatusCode { get; set; }
        public List<string> DevMsg { get; set; }
        public List<string> UserMsg { get; set; }
    }
}
