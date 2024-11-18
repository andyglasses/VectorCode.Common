namespace VectorCode.Common;

/// <summary>
/// A basic response object.
/// </summary>
public partial class Response
{
    /// <summary>
    /// Success indicator
    /// </summary>
    public bool Success { get; set; }

    /// <summary>
    /// List of errors, should only be populated if Success is false.
    /// </summary>
    public List<KeyCode> Errors { get; set; } = new();
}

/// <summary>
/// Payload response
/// </summary>
/// <typeparam name="T"></typeparam>
public class Response<T> : Response
{
  /// <summary>
  /// The data payload
  /// </summary>
  public T? Data { get; set; }
}
