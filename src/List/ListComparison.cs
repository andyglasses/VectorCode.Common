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
  /// <param name="originalList">The origonal list</param>
  /// <param name="newList">The new list</param>
  /// <param name="toHash">A method to create a hashable string</param>
  /// <returns></returns>
  public static (List<T> InBoth, List<T> DeletedInNew, List<T>AddedInNew) ComputeListDifference<T>(this List<T> originalList, List<T> newList, Func<T, string> toHash)
  {
    var origionalHashSet = new HashSet<string>(originalList.Select(toHash));
    var newHashSet = new HashSet<string>(newList.Select(toHash));

    var inBoth = origionalHashSet.Intersect(newHashSet).Select(hash => originalList.First(item => toHash(item) == hash)).ToList();
    var deletedInNew = origionalHashSet.Except(newHashSet).Select(hash => originalList.First(item => toHash(item) == hash)).ToList();
    var addedInNew = newHashSet.Except(origionalHashSet).Select(hash => newList.First(item => toHash(item) == hash)).ToList();

    return (inBoth, deletedInNew, addedInNew);

  }
}
