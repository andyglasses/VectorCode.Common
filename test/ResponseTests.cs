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
    Assert.That(response.Success, Is.True);
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
    Assert.That(response.Success, Is.False);
    Assert.That(response.Errors, Is.EquivalentTo(errors));
  }

  [Test]
  public void Successful_ShouldReturnWithSuccessTrueAndData()
  {
    // Arrange
    var data = new { Name = "John Doe" };

    // Act
    var response = Response.Builder.Successful(data);

    // Assert
    Assert.That(response.Success, Is.True);
    Assert.That(response.Data, Is.EqualTo(data));
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
    Assert.That(response.Success, Is.False);
    Assert.That(response.Errors, Is.EquivalentTo(errors));
  }


}
