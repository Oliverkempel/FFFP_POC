namespace FFFP_POC_Core
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Request
    {
        public Request(string requestType)
        {
            this.RequestType = requestType;

            // Genetate the response identifyer for identifying the response from process A
            ResponseIndentifyer = Guid.NewGuid();
        }

        public string RequestType { get; set; }

        public Guid ResponseIndentifyer { get; set; }
    }
}
