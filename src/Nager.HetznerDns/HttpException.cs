using System;

namespace Nager.HetznerDns
{
    [Serializable]
    public class HttpException : Exception
    {
        public HttpException() : base() { }
        public HttpException(string message) : base(message) { }
        public HttpException(string message, Exception inner) : base(message, inner) { }
    }
}
