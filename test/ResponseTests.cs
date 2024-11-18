using FluentAssertions;

namespace VectorCode.Common.Test;

[TestFixture]
public class ResponseExtensionTests
{
  [Test]
  public void Successful_ShouldReturnWithSuccessTrue()
  {
    // Arrange

    // Act
    var response = Response.Builder.Successful();

    // Assert
    response.Success.Should().BeTrue();
  }

  [Test]
  public void Failed_ShouldReturnWithSuccessFalseAndAllErrors()
  {
    // Arrange
    var errors = new List<KeyCode>
    {
      new KeyCode("Key1", "Code1"),
      new KeyCode("Key2", "Code2")
    };

    // Act
    var response = Response.Builder.Failed(errors);

    // Assert
    response.Success.Should().BeFalse();
    response.Errors.Should().BeEquivalentTo(errors);
  }

  [Test]
  public void Successful_ShouldReturnWithSuccessTrueAndData()
  {
    // Arrange
    var data = new { Name = "John Doe" };

    // Act
    var response = Response.Builder.Successful(data);

    // Assert
    response.Success.Should().BeTrue();
    response.Data.Should().BeEquivalentTo(data);
  }

  [Test]
  public void Failed_ShouldReturnWithSuccessFalseAndAllErrorsForGeneric()
  {
    // Arrange
    var errors = new List<KeyCode>
    {
      new KeyCode("Key1", "Code1"),
      new KeyCode("Key2", "Code2")
    };

    // Act
    var response = Response.Builder.Failed<string>(errors);

    // Assert
    response.Success.Should().BeFalse();
    response.Errors.Should().BeEquivalentTo(errors);
  }


}
