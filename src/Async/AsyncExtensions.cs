namespace CodedVector.Common.Async;

/// <summary>
/// Useful Async Collection Extenion methods
/// </summary>
public static class CollectionExtensions
{
  /// <summary>
  /// Converts an IAsyncEnumerable to a List
  /// </summary>
  /// <typeparam name="T">List Type</typeparam>
  /// <param name="asyncEnumerable">Collection to parse</param>
  /// <param name="cancellationToken">Cancellation token</param>
  /// <returns></returns>
  public static async Task<List<T>> ToListAsync<T>(this IAsyncEnumerable<T> asyncEnumerable, CancellationToken? cancellationToken = null)
  {
    var list = new List<T>();
    await foreach (var item in asyncEnumerable)
    {
      cancellationToken?.ThrowIfCancellationRequested();
      list.Add(item);
    }
    return list;
  }
}
