namespace VectorCode.Common.Async;

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

  /// <summary>
  /// Converts an IAsyncEnumerable to a List with a mapping function
  /// </summary>
  /// <typeparam name="T">List Type</typeparam>
  /// <typeparam name="TOut">Mapped List Type</typeparam>
  /// <param name="asyncEnumerable">Collection to parse</param>
  /// <param name="mappingFunc"></param>
  /// <param name="cancellationToken">Cancellation token</param>
  /// <returns></returns>
  public static async Task<List<TOut>> ToListAsync<T, TOut>(this IAsyncEnumerable<T> asyncEnumerable, Func<T, TOut> mappingFunc, CancellationToken? cancellationToken = null)
  {
    var list = new List<TOut>();
    await foreach (var item in asyncEnumerable)
    {
      cancellationToken?.ThrowIfCancellationRequested();
      if(item == null)
      {
        continue;
      }
      var mapped = mappingFunc(item);
      if(mapped == null)
      {
        continue;
      }
      list.Add(mapped);      
    }
    return list;
  }
}
