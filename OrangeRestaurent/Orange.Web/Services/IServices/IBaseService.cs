using Orange.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Orange.Web.Services.IServices
{
   
    // Idisposable to implement the dipose method in concrete class
    public interface IBaseService : IDisposable
    {
       
        ResponseDto responseModel { get; set; }

        Task<T> SendAsync<T>(ApiRequest apiRequest);
    }
}
