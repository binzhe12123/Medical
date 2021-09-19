using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SY.Com.Infrastructure
{
    public class ExceptionNotData : Exception
    {        
        public ExceptionNotData() { }
        public ExceptionNotData(string message) : base(message) {

        }
        public ExceptionNotData(string message, Exception inner) : base(message, inner) { }
        public override string Message
        {
            get
            {
                return base.Message;
            }
        }

    }

    public class ExceptionNoCondition : Exception
    {
        public ExceptionNoCondition() { }
        public ExceptionNoCondition(string message) : base(message)
        {

        }
        public ExceptionNoCondition(string message, Exception inner) : base(message, inner) { }
        public override string Message
        {
            get
            {
                return base.Message;
            }
        }

    }


}
