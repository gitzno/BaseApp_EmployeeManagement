using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Exceptions
{
    public class ValidateException : Exception
    {
        private string? MsgErroValidate = string.Empty;
        public ValidateException(string msg)
        {
            this.MsgErroValidate = msg;
        }
        public override string Message
        {
            get
            {
                return MsgErroValidate;
            }
        }
    }
}
