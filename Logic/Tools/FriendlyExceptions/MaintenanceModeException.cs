using System;
using System.Runtime.Serialization;

namespace Helpers
{
    /// <summary>
    /// app in maintenance mode
    /// </summary>
    public class MaintenanceModeException : BaseFriendlyException
    {
        public MaintenanceModeException(object extra = null) : base(extra)
        {
        }

        public MaintenanceModeException(string message, object extra = null)
            : base(message, extra)
        {
        }

        public MaintenanceModeException(string title, string message, object extra = null) : base(title, message, extra)
        {
        }

        public MaintenanceModeException(string title, string message, string url, object extra = null) : base(title, message, url, extra)
        {
        }

        public MaintenanceModeException(string title, string message, string url, string urlTitle, object extra = null) : base(title, message, url, urlTitle, extra)
        {
        }

        public MaintenanceModeException(string message, Exception innerException, object extra = null)
            : base(message, innerException, extra)
        {
        }

        protected MaintenanceModeException(SerializationInfo info, StreamingContext context, object extra = null)
            : base(info, context, extra)
        {
        }
    }
}