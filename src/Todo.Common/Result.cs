using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todo.Common
{
    public class Result
    {
        private bool ok;
        public string Error {  get; private set; }
        private Result()
        {
            this.ok = true;
            this.Error = string.Empty;
        }

        private Result(string error)
        {
            this.ok = false;
            this.Error = error;
        }


        public bool IsErr()
        {
            return this.ok;
        }

        public bool IsOk()
        {
            return this.ok;
        }

        public string GetErr()
        {
            return this.Error;
        }

        public static Result Ok()
        {
            return new Result();
        }

        public static Result Err(string err)
        {
            return new Result(err);
        }
    }

    public class Result<T> where T : class
    {
        private bool ok;
        private string Error;

        private T? Value;

        public bool IsErr()
        {
            return this.ok;
        }

        public bool IsOk()
        {
            return this.ok;
        }

        public string GetErr()
        {
            return this.Error;
        }

        public T? GetVal()
        {
            return this.Value;
        }

        private Result(T val)
        {
            this.Value = val;
            this.ok = true;
            this.Error = string.Empty;
        }

        private Result(string error)
        {
            this.Value = null;
            this.ok = false;
            this.Error = error;
        }

        public static Result<T> Ok(T? val)
        {
            return new Result<T>(val);
        }

        public static Result<T> Err(string err)
        {
            return new Result<T>(err);
        }
    }
}
