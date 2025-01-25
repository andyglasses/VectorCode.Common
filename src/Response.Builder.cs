namespace VectorCode.Common;

public partial class Response
{
  /// <summary>
  /// Creates instances of the Response object
  /// </summary>
  public static class Builder
  {
    /// <summary>
    /// Create a successful response
    /// </summary>
    /// <returns>Response</returns>
    public static Response Successful()
    {
      return new Response()
      {
        Success = true
      };
    }

    /// <summary>
    /// Create a failed response
    /// </summary>
    /// <param name="errors">Collection of errors</param>
    /// <returns>Response</returns>
    public static Response Failed(List<KeyCode> errors)
    {
      return new Response()
      {
        Success = false,
        Errors = errors
      };
    }

    /// <summary>
    /// Create a failed response with a single error
    /// </summary>
    /// <param name="error">The error</param>
    /// <returns></returns>
    public static Response Failed(KeyCode error)
    {
      return new Response()
      {
        Success = false,
        Errors = new List<KeyCode>() { error }
      };
    }

    /// <summary>
    /// Create a successful response with data
    /// </summary>
    /// <typeparam name="T">The payload type</typeparam>
    /// <param name="data">The payload data</param>
    /// <returns>Response</returns>
    public static Response<T> Successful<T>(T data)
    {
      return new Response<T>()
      {
        Success = true,
        Data = data
      };
    }

    /// <summary>
    /// Create a failed payload response with errors
    /// </summary>
    /// <typeparam name="T">The payload type</typeparam>
    /// <param name="errors">Collection of errors</param>
    /// <returns>Response</returns>
    public static Response<T> Failed<T>(List<KeyCode> errors)
    {
      return new Response<T>()
      {
        Success = false,
        Errors = errors
      };
    }

    /// <summary>
    /// Create a failed payload response with a single error
    /// </summary>
    /// <typeparam name="T">The payload type</typeparam>
    /// <param name="error">The error</param>
    /// <returns></returns>
    public static Response<T> Failed<T>(KeyCode error)
    {
      return new Response<T>()
      {
        Success = false,
        Errors = new List<KeyCode>() { error }
      };
    }
  }
}
