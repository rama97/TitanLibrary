using System;
using System.Runtime.Serialization;

namespace Helpers
{
    /// <summary>
    /// data you passed are not valid, used on not valid modal
    /// or on any data not valid exceptions
    /// will show toast on production
    /// and alert on development
    /// </summary>
    public class NotValidException : BaseFriendlyException
    {
        public NotValidException(object extra = null) : base(extra)
        {
        }

        public NotValidException(string message, object extra = null)
            : base(message, extra)
        {
        }

        public NotValidException(string title, string message, object extra = null) : base(title, message, extra)
        {
        }

        public NotValidException(string title, string message, string url, object extra = null) : base(title, message, url, extra)
        {
        }

        public NotValidException(string title, string message, string url, string urlTitle, object extra = null) : base(title, message, url, urlTitle, extra)
        {
        }

        public NotValidException(string message, Exception innerException, object extra = null)
             : base(message, innerException, extra)
        {
        }

        protected NotValidException(SerializationInfo info, StreamingContext context, object extra = null)
            : base(info, context, extra)
        {
        }
    }
}