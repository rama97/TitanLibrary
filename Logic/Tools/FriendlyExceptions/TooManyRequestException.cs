using System;
using System.Runtime.Serialization;

namespace Helpers
{
    /// <summary>
    /// too many request to server
    /// </summary>
    public class TooManyRequestException : BaseFriendlyException
    {
        public TooManyRequestException(object extra = null) : base(extra)
        {
        }

        public TooManyRequestException(string message, object extra = null)
            : base(message, extra)
        {
        }

        public TooManyRequestException(string title, string message, object extra = null) : base(title, message, extra)
        {
        }

        public TooManyRequestException(string title, string message, string url, object extra = null) : base(title, message, url, extra)
        {
        }

        public TooManyRequestException(string title, string message, string url, string urlTitle, object extra = null) : base(title, message, url, urlTitle, extra)
        {
        }

        public TooManyRequestException(string message, Exception innerException, object extra = null)
            : base(message, innerException, extra)
        {
        }

        protected TooManyRequestException(SerializationInfo info, StreamingContext context, object extra = null)
            : base(info, context, extra)
        {
        }
    }
}