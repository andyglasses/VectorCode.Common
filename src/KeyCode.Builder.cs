namespace VectorCode.Common;

public partial record KeyCode
{
  /// <summary>
  /// Utility method creates instances of the Key Code record.
  /// </summary>
  public static class Builder
  {
    /// <summary>
    /// Creates a key code with a number prostfixed to the code
    /// </summary>
    /// <param name="key">The key</param>
    /// <param name="code">The code</param>
    /// <param name="number">The detail number</param>
    /// <returns>A colon seperate key value pair</returns>
    /// <exception cref="ArgumentException"></exception>
    public static KeyCode KeyCodeWithNumberDetail(string key, string code, int number)
    {
      if (code.Contains(':'))
      {
        throw new ArgumentException("Code cannot contain a colon");
      }
      return new KeyCode(key, $"{code}:{number}");
    }

    /// <summary>
    /// Creates a key code with a string detail
    /// </summary>
    /// <param name="key">The key</param>
    /// <param name="code">The code</param>
    /// <param name="detail">The detail string</param>
    /// <returns>A colon seperate key value pair</returns>
    /// <exception cref="ArgumentException"></exception>
    public static KeyCode KeyCodeWithStringDetail(string key, string code, string detail)
    {
      if (code.Contains(':'))
      {
        throw new ArgumentException("Code cannot contain a colon", nameof(code));
      }
      if (detail.Contains(':'))
      {
        throw new ArgumentException("Code detail cannot contain a colon", nameof(detail));
      }
      if (string.IsNullOrWhiteSpace(detail))
      {
        return new KeyCode(key, code);
      }
      return new KeyCode(key, $"{code}:{detail}");
    }

    /// <summary>
    /// Creates a key code with a list of string details
    /// </summary>
    /// <param name="key">The key</param>
    /// <param name="code">The code</param>
    /// <param name="details">The list of details</param>
    /// <returns>A colon seperate key value pair with semi colon delimited value</returns>
    /// <exception cref="ArgumentException"></exception>
    public static KeyCode KeyCodeWithStringListDetail(string key, string code, List<string> details)
    {
      if (code.Contains(':') || code.Contains(';'))
      {
        throw new ArgumentException("Code cannot contain a colon or semicolon", nameof(code));
      }
      if (details.Any(d => d.Contains(':') || d.Contains(';')))
      {
        throw new ArgumentException("Code detail cannot contain a colon or semicolon", nameof(details));
      }
      if (details.Count == 0)
      {
        return new KeyCode(key, code);
      }
      return new KeyCode(key, $"{code}:{string.Join(';', details)}");
    }
  }
}
