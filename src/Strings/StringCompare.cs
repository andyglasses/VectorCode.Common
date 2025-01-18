using System.Text.RegularExpressions;

namespace VectorCode.Common.Strings;

/// <summary>
/// Utilities methods for comparing strings
/// </summary>
public static class StringCompare
{
  /// <summary>
  /// Compares two strings and returns a similarity score between 0 and 1
  /// </summary>
  /// <param name="str1">First string</param>
  /// <param name="str2">Second string</param>
  /// <returns></returns>
  public static double ComputeStringSimilarity(string str1, string str2)
  {
    var pairs1 = WordLetterPairs(str1);
    var pairs2 = WordLetterPairs(str2);

    int intersection = 0;
    int union = pairs1.Count + pairs2.Count;

    for (int i = 0; i < pairs1.Count; i++)
    {
      for (int j = 0; j < pairs2.Count; j++)
      {
        if (pairs1[i] == pairs2[j])
        {
          intersection++;
          pairs2.RemoveAt(j);//Must remove the match to prevent "AAAA" from appearing to match "AA" with 100% success
          break;
        }
      }
    }

    return (2.0 * intersection) / union;
  }




  private static List<string> WordLetterPairs(string value)
  {
    List<string> allPairs = new();

    string[] words = Regex.Split(value.ToUpperInvariant(), @"\s");

    // For each word
    for (int w = 0; w < words.Length; w++)
    {
      if (!string.IsNullOrEmpty(words[w]))
      {
        // Find the pairs of characters
        string[] pairsInWord = LetterPairs(words[w]);

        for (int p = 0; p < pairsInWord.Length; p++)
        {
          allPairs.Add(pairsInWord[p]);
        }
      }
    }
    return allPairs;
  }

  private static string[] LetterPairs(string value)
  {
    int numPairs = value.Length - 1;
    string[] pairs = new string[numPairs];

    for (int i = 0; i < numPairs; i++)
    {
      pairs[i] = value.Substring(i, 2);
    }
    return pairs;
  }
}
