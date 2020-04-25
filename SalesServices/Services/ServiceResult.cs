using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesServices.Services
{
    public class ServiceResult<T> 
    {
        public bool IsSuccessful { get; set; }

        public string[] Errors { get; set; } = { };

        public T Result { get; set; }

        public static ServiceResult<T> Error(string message)
        {
            return new ServiceResult<T> { IsSuccessful = false, Errors = new[] { message } };
        }

        public static ServiceResult<T> Error(IEnumerable<string> messages)
        {
            return new ServiceResult<T> { IsSuccessful = false, Errors = messages.ToArray() };
        }

        public static ServiceResult<T> Success(T result)
        {
            return new ServiceResult<T> { IsSuccessful = true, Result = result };
        }


    }
}
