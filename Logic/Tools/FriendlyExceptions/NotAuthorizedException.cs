using System;
using System.Runtime.Serialization;

namespace Helpers
{
    /// <summary>
    /// no authriation info nor tenant token
    /// </summary>
    public class NotAuthorizedException : BaseFriendlyException
    {
        public NotAuthorizedException(object extra = null) : base(extra)
        {
        }

        public NotAuthorizedException(string message, object extra = null)
            : base(message, extra)
        {
        }

        public NotAuthorizedException(string title, string message, object extra = null) : base(title, message, extra)
        {
        }

        public NotAuthorizedException(string title, string message, string url, object extra = null) : base(title, message, url, extra)
        {
        }

        public NotAuthorizedException(string title, string message, string url, string urlTitle, object extra = null) : base(title, message, url, urlTitle, extra)
        {
        }

        public NotAuthorizedException(string message, Exception innerException, object extra = null)
            : base(message, innerException, extra)
        {
        }

        protected NotAuthorizedException(SerializationInfo info, StreamingContext context, object extra = null)
            : base(info, context, extra)
        {
        }
    }
}