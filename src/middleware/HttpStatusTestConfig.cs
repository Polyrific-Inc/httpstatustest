namespace Polyrific.Middleware.HttpStatusTest
{
    /// <summary>
    /// The configurations that can be applied to the middleware
    /// </summary>
    public class HttpStatusTestConfig
    {
        /// <summary>
        /// The URL path to do the HTTP status test (default: "/httpstatus")
        /// </summary>
        /// <value></value>
        public string TestPath { get; set; }

        /// <summary>
        /// The key name of the expected status code in the query string (default: "c")
        /// </summary>
        /// <value></value>
        public string CodeKeyName { get; set; }
        
        public HttpStatusTestConfig()
        {
            TestPath = "/httpstatus";
            CodeKeyName = "c";
        }
    }
}