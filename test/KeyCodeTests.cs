using FluentAssertions;
using System.Collections;

namespace VectorCode.Common.Test;

[TestFixture]
public class KeyCodeTests
{
  [Test]
  public void ToString_ShouldReturnKeyAndCode()
  {
    // Arrange
    var keyCode = new KeyCode("key", "code");

    // Act
    var result = keyCode.ToString();

    // Assert
    result.Should().Be("key: code");

  }

  [Test]
  public void KeyCodeWithNumberDetail_ShouldReturnKeyCodeWithNumber()
  {
    // Arrange
    var key = "key";
    var code = "code";
    var number = 1;

    // Act
    var result = KeyCode.Builder.KeyCodeWithNumberDetail(key, code, number);

    // Assert
    result.Key.Should().Be(key);
    result.Code.Should().Be($"{code}:{number}");
  }

  [Test]
  public void KeyCodeWithNumberDetail_ShouldThrowArgumentException_WhenCodeContainsColon()
  {
    // Arrange
    var key = "key";
    var code = "cod:e";
    var number = 1;

    // Act
    var act = () => KeyCode.Builder.KeyCodeWithNumberDetail(key, code, number);

    // Assert
    act.Should().Throw<ArgumentException>().WithMessage("Code cannot contain a colon");
  }

  [Test]
  public void KeyCodeWithStringDetail_ShouldReturnKeyCodeWithString()
  {
    // Arrange
    var key = "key";
    var code = "code";
    var detail = "detail";

    // Act
    var result = KeyCode.Builder.KeyCodeWithStringDetail(key, code, detail);

    // Assert
    result.Key.Should().Be(key);
    result.Code.Should().Be($"{code}:{detail}");
  }

  [Test]
  public void KeyCodeWithStringDetail_ShouldReturnKeyCodeWithoutDetail_WhenDetailIsNullOrWhiteSpace()
  {
    // Arrange
    var key = "key";
    var code = "code";
    var detail = string.Empty;

    // Act
    var result = KeyCode.Builder.KeyCodeWithStringDetail(key, code, detail);

    // Assert
    result.Key.Should().Be(key);
    result.Code.Should().Be(code);
  }

  [Test]
  public void KeyCodeWithStringDetail_ShouldThrowArgumentException_WhenCodeContainsColon()
  {
    // Arrange
    var key = "key";
    var code = "cod:e";
    var detail = "detail";

    // Act
    var act = () => KeyCode.Builder.KeyCodeWithStringDetail(key, code, detail);

    // Assert
    act.Should().Throw<ArgumentException>();
  }

  [Test]
  public void KeyCodeWithStringDetail_ShouldThrowArgumentException_WhenDetailContainsColon()
  {
    // Arrange
    var key = "key";
    var code = "code";
    var detail = "det:ail";

    // Act
    var act = () => KeyCode.Builder.KeyCodeWithStringDetail(key, code, detail);

    // Assert
    act.Should().Throw<ArgumentException>();
  }

  [Test]
  public void KeyCodeWithStringListDetail_ShouldReturnKeyCodeWithStringList()
  {
    // Arrange
    var key = "key";
    var code = "code";
    var details = new List<string> { "detail1", "detail2" };

    // Act
    var result = KeyCode.Builder.KeyCodeWithStringListDetail(key, code, details);

    // Assert
    result.Key.Should().Be(key);
    result.Code.Should().Be($"{code}:{string.Join(";", details)}");
  }

  [Test]
  public void KeyCodeWithStringListDetail_ShouldReturnKeyCode_WhenEmptyList()
  {
    // Arrange
    var key = "key";
    var code = "code";
    var details = new List<string>();

    // Act
    var result = KeyCode.Builder.KeyCodeWithStringListDetail(key, code, details);

    // Assert
    result.Key.Should().Be(key);
    result.Code.Should().Be(code);
  }

  [Test]
  [TestCaseSource(nameof(CodeOrDetailsContainsColonOrSemi_TestCases))]
  public void KeyCodeWithStringListDetail_ShouldThrowArgumentException_WhenCodeOrDetailsContainsColonOrSemi(string code, string detail1)
  {
    // Arrange
    var key = "key";
    var details = new List<string> { detail1, "detail2" };

    // Act
    var act = () => KeyCode.Builder.KeyCodeWithStringListDetail(key, code, details);

    // Assert
    act.Should().Throw<ArgumentException>();
  }

  public static IEnumerable CodeOrDetailsContainsColonOrSemi_TestCases
  {
    get
    {
      yield return new TestCaseData("cod:e", "detail1");
      yield return new TestCaseData("code", "detai:l1");
      yield return new TestCaseData("cod;e", "detail1");
      yield return new TestCaseData("code", "detai;l1");
    }
  }

}
