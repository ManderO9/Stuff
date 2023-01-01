namespace Stuff.Core
{
    /// <summary>
    /// The response of an API call containing a body
    /// </summary>
    /// <typeparam name="T">The type of the data we are expecting to get</typeparam>
    public class ApiResponse<T> : ApiResponse
	{
        /// <summary>
        /// The content result for the API request 
        /// </summary>
        public T? Body { get; set; }
    }

	/// <summary>
	/// The response of an API call
	/// </summary>
	/// <typeparam name="T">The type of the data we are expecting to get</typeparam>
	public class ApiResponse
	{
		/// <summary>
		/// Whether the request was successful or not
		/// </summary>
		public bool Successful { get; set; }

		/// <summary>
		/// A list of errors if the request was unsuccessful    
		/// </summary>
		public List<string>? Errors { get; set; }
	}



}
