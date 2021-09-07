using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Orange.Web.SD;

namespace Orange.Web.Models
{
    // for reducing the redundanecv craeating request model
    public class ApiRequest
    {
        public ApiType ApiType { get; set; } = ApiType.GET;
        public string Url { get; set; }
        public object Data { get; set; }
        public string AccessToken { get; set; }
    }
}
