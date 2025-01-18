using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VectorCode.Common.Strings;

namespace VectorCode.Common.Test;

[TestFixture]
public class StringCompareTests
{
  [Test]
  [TestCase("Hello", "Hello", 1)]
  [TestCase("Hello", "hELLO", 1)]
  [TestCase("Hello", "Helo", 0.857)]
  [TestCase("Hello", "ABC", 0)]
  [TestCase("Hello World", "HelloWorld", 0.941)]
  [TestCase("Hello", "ABC", 0)]
  [TestCase("Hello", "", 0)]
  public void ComputeStringSimilarity_WhenCalled_ReturnsSimilarityScore(string val1, string val2, double expected)
  {

    // Act
    var result = StringCompare.ComputeStringSimilarity(val1, val2);

    // Assert
    result = Math.Round(result, 3);
    Assert.That(result, Is.EqualTo(expected));
  }  
}
