using System;
using System.Runtime.Serialization;

namespace ShoeStore_Project_MVC_EntityFramework.Controllers
{
    [Serializable]
    internal class sqlException : Exception
    {
        public sqlException()
        {
        }

        public sqlException(string message) : base(message)
        {
        }

        public sqlException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected sqlException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}