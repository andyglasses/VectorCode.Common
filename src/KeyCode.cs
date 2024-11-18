namespace VectorCode.Common;

/// <summary>
/// A simple key and string code pair.
/// </summary>
/// <param name="Key">The key</param>
/// <param name="Code">The keyed value</param>
public partial record KeyCode(string Key, string Code)
{
  /// <inheritdoc/>
  public override string ToString() => $"{Key}: {Code}";
}