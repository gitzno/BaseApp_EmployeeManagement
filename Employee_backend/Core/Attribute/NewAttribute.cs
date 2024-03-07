using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.NewAttribute
{
    [AttributeUsage(AttributeTargets.Property)]
    public class NotEmpty : Attribute
    {

    }
    public class Identification : Attribute { }
    public class CodeLegal : Attribute { }
    public class NameEnity : Attribute
    {
        private string name;

        public NameEnity(string name)
        {
            this.name = name;
        }
    }
}
