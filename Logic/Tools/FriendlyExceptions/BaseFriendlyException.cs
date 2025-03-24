using System;
using System.Runtime.Serialization;

namespace Helpers
{
    /// <summary>
    /// friendly "pre-known" Exceptions
    /// </summary>
    public class BaseFriendlyException : Exception
    {
        public string Title { get; set; }

        public string UrlTitle { get; set; }

        public string Url { get; set; } = null;

        public object Extra { get; set; } = null;

        public BaseFriendlyException(object extra = null)
            : base()
        {
            this.Extra = extra;
        }

        public BaseFriendlyException(string message, object extra = null)
            : base(message)
        {
            this.Extra = extra;
        }

        public BaseFriendlyException(string title, string message, object extra = null)
            : base(message)
        {
            Title = title;
            this.Extra = extra;
        }

        public BaseFriendlyException(string title, string message, string url, object extra = null)
            : base(message)
        {
            Title = title;
            Url = url;
            this.Extra = extra;
        }

        public BaseFriendlyException(string title, string message, string url, string urlTitle, object extra = null)
            : base(message)
        {
            Title = title;
            Url = url;
            UrlTitle = urlTitle;
            this.Extra = extra;
        }

        public BaseFriendlyException(string message, Exception innerException, object extra = null)
            : base(message, innerException)
        {
            this.Extra = extra;
        }

        protected BaseFriendlyException(SerializationInfo info, StreamingContext context, object extra = null)
            : base(info, context)
        {
            this.Extra = extra;
        }
    }

}