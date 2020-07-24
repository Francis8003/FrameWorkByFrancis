
using System;
using System.Runtime.Serialization;

namespace FrameWorkByFrancis
{
    public class FrameworkException:Exception
    {
        public FrameworkException():base()
        {

        }
        public FrameworkException(string message):base(message)
        {

        }
        public FrameworkException(string message,Exception innerException):base (message,innerException)
        {
            
        }

        protected FrameworkException(SerializationInfo info ,StreamingContext context):base(info,context)
        {
            
        }
    }
}