using System;
using System.Runtime.Serialization;

namespace Helpers
{
    public class UpgradeRequiredException : BaseFriendlyException
    {
        public UpgradeRequiredException(object extra = null) : base(extra)
        {
        }

        public UpgradeRequiredException(string message, object extra = null)
            : base(message, extra)
        {
        }

        public UpgradeRequiredException(string title, string message, object extra = null) : base(title, message, extra)
        {
        }

        public UpgradeRequiredException(string title, string message, string url, object extra = null) : base(title, message, url, extra)
        {
        }

        public UpgradeRequiredException(string title, string message, string url, string urlTitle, object extra = null) : base(title, message, url, urlTitle, extra)
        {
        }

        public UpgradeRequiredException(string message, Exception innerException, object extra = null)
            : base(message, innerException, extra)
        {
        }

        protected UpgradeRequiredException(SerializationInfo info, StreamingContext context, object extra = null)
            : base(info, context, extra)
        {
        }
    }
}