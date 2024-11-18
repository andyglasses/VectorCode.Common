namespace VectorCode.Common.List;

/// <summary>
/// Utilities methods for comparing lists
/// </summary>
public static class ListComparison
{
  /// <summary>
  /// Compares two lists and returns the items that are in both, deleted in the new list, and added in the new list
  /// </summary>
  /// <typeparam name="T">List type</typeparam>
  /// <param name="origionalList">The origonal list</param>
  /// <param name="newList">The new list</param>
  /// <param name="toHashable">A method to create a hashable string</param>
  /// <returns></returns>
  public static (List<T> InBoth, List<T> DeletedInNew, List<T>AddedInNew) ComputeListDif<T>(this List<T> origionalList, List<T> newList, Func<T, string> toHashable)
  {
    var origionalHashSet = new HashSet<string>(origionalList.Select(toHashable));
    var newHashSet = new HashSet<string>(newList.Select(toHashable));

    var inBoth = origionalHashSet.Intersect(newHashSet).Select(hash => origionalList.First(item => toHashable(item) == hash)).ToList();
    var deletedInNew = origionalHashSet.Except(newHashSet).Select(hash => origionalList.First(item => toHashable(item) == hash)).ToList();
    var addedInNew = newHashSet.Except(origionalHashSet).Select(hash => newList.First(item => toHashable(item) == hash)).ToList();

    return (inBoth, deletedInNew, addedInNew);

  }
}
