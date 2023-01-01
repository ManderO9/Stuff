namespace Stuff.Core
{
    /// <summary>
    /// An API request we send to the server containing a body
    /// </summary>
    /// <typeparam name="T">The data we send in the request if any</typeparam>
    public class ApiRequest<T> : ApiRequest
    {
        /// <summary>
        /// The body of the request containing required data if any
        /// </summary>
        public required T Body { get; set; }

    }

	/// <summary>
	/// An API request we send to the server
	/// </summary>
	public class ApiRequest
	{
		/// <summary>
		/// The token to send to authenticate
		/// </summary>
		public required string Token { get; set; }
	}
}
