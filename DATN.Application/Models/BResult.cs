using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATN.Application.Models
{
    public class BResult
    {
        public bool Succeeded { get; set; }

        public string Message { get; set; }

        internal BResult(bool succeeded, string message)
        {
            Succeeded = succeeded;
            Message = message;
        }

        public static BResult Success()
        {
            return new BResult(true, "");
        }
        public static BResult Success(string message)
        {
            return new BResult(true, message);
        }

        public static BResult Failure(string message)
        {
            return new BResult(false, message);
        }

        public static BResult Failure()
        {
            return new BResult(false, "");
        }
    }

    public class BResult<T>
    {
        internal BResult(bool succeeded, string message, T result)
        {
            Succeeded = succeeded;
            Message = message;
            Result = result;
        }

        public bool Succeeded { get; set; }

        public string Message { get; set; }

        public T Result { get; set; }

        public static BResult<T> Success(T result)
        {
            return new BResult<T>(true, "", result);
        }
        public static BResult<T> Success(T result, string message)
        {
            return new BResult<T>(true, message, result);
        }
        public static BResult<T> Failure(T result)
        {
            return new BResult<T>(false, "", result);
        }
        public static BResult<T> Failure(T result, string message)
        {
            return new BResult<T>(false, message, result);
        }
    }
}
