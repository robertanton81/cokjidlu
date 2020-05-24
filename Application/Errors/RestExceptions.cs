namespace Application.Errors
{
    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Text;

    public class RestExceptions : Exception
    {
        public HttpStatusCode Code { get; }
        public object Errors { get; }

        public RestExceptions(HttpStatusCode code, object errors = null)
        {
            this.Code= code;
            this.Errors= errors;
        }
    }
}
