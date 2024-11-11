using Azure;
using CodedVector.Common.Async;
using FluentAssertions;
using Moq;

namespace CodedVector.Common.Test.Async;

[TestFixture]
public class AsyncExtensionsTests
{

  [Test]
  public async Task ToListAsync_Returns_Expected_Values()
  {
    // Arrange
    var sourceList = new List<int> { 1, 2, 3 };
    var pageCollection = Page<int>.FromValues(sourceList, null, new Mock<Response>().Object);
    var asyncCollection = AsyncPageable<int>.FromPages(new[] { pageCollection });

    // Act
    var actual = await asyncCollection.ToListAsync();

    // Assert
    actual.Should().BeEquivalentTo(sourceList);
  }
}
