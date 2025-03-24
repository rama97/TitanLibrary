using System;
using System.Runtime.Serialization;

namespace Helpers
{
    public class ConflictExcption : BaseFriendlyException
    {
        public ConflictExcption(object extra = null)
            : base(extra)
        {
        }

        public ConflictExcption(string message, object extra = null)
            : base(message, extra)
        {
        }

        public ConflictExcption(string title, string message, object extra = null) : base(title, message, extra)
        {
        }

        public ConflictExcption(string title, string message, string url, object extra = null) : base(title, message, url, extra)
        {
        }

        public ConflictExcption(string title, string message, string url, string urlTitle, object extra = null) : base(title, message, url, urlTitle, extra)
        {
        }

        public ConflictExcption(string message, Exception innerException, object extra = null)
            : base(message, innerException, extra)
        {
        }

        protected ConflictExcption(SerializationInfo info, StreamingContext context, object extra = null)
            : base(info, context, extra)
        {
        }
    }
}
