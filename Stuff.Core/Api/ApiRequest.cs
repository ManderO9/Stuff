namespace Stuff.Core
{
    /// <summary>
    /// An API request we send to the server
    /// </summary>
    /// <typeparam name="T">The data we send in the request if any</typeparam>
    public class ApiRequest<T>
    {
        /// <summary>
        /// The body of the request containing required data if any
        /// </summary>
        public T Body { get; set; }

        /// <summary>
        /// The token to send to authenticate
        /// </summary>
        public string Token { get; set; }
    }
}
