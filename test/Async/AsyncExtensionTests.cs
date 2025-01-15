using Azure;
using VectorCode.Common.Async;
using Moq;

namespace VectorCode.Common.Test.Async;

[TestFixture]
public class AsyncExtensionsTests
{

  [Test]
  public async Task ToListAsync_ShouldReturnTheList()
  {
    // Arrange
    var sourceList = new List<int> { 1, 2, 3 };
    var pageCollection = Page<int>.FromValues(sourceList, null, new Mock<Azure.Response>().Object);
    var asyncCollection = AsyncPageable<int>.FromPages(new[] { pageCollection });

    // Act
    var actual = await asyncCollection.ToListAsync();

    // Assert
    Assert.That(actual, Is.EquivalentTo(sourceList));
  }

  [Test]
  public async Task ToListAsync_WhenUsingMapping_ShouldReturnList()
  {
    // Arrange
    var sourceList = new List<int> { 1, 2, 3 };
    var expectedList = new List<string> { "m1", "m2", "m3" };
    var pageCollection = Page<int>.FromValues(sourceList, null, new Mock<Azure.Response>().Object);
    var asyncCollection = AsyncPageable<int>.FromPages(new[] { pageCollection });

    // Act
    var actual = await asyncCollection.ToListAsync(i => $"m{i}");

    // Assert
    Assert.That(actual, Is.EquivalentTo(expectedList));
  }

  [Test]
  public async Task ToListAsync_WhenUsingMapping_ShouldIgnoreSourceNulls()
  {
    // Arrange
    var sourceList = new List<string> { "1", "2", null!, "3" };
    var expectedList = new List<string> { "m1", "m2", "m3" };
    var pageCollection = Page<string>.FromValues(sourceList, null, new Mock<Azure.Response>().Object);
    var asyncCollection = AsyncPageable<string>.FromPages(new[] { pageCollection });

    // Act
    var actual = await asyncCollection.ToListAsync(i => $"m{i}");

    // Assert
    Assert.That(actual, Is.EquivalentTo(expectedList));
  }

  [Test]
  public async Task ToListAsync_WhenUsingMapping_ShouldIgnoreMappedNulls()
  {
    // Arrange
    var sourceList = new List<int> { 1, 2, 3 };
    var expectedList = new List<string> { "m1", "m3" };
    var pageCollection = Page<int>.FromValues(sourceList, null, new Mock<Azure.Response>().Object);
    var asyncCollection = AsyncPageable<int>.FromPages(new[] { pageCollection });

    // Act
    var actual = await asyncCollection.ToListAsync(i => i == 2 ? null! :  $"m{i}");

    // Assert
    Assert.That(actual, Is.EquivalentTo(expectedList));
  }
}
