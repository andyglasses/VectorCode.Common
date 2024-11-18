using VectorCode.Common.List;

namespace VectorCode.Common.Test;

[TestFixture]
public class ListComparisonTests
{
  [Test]
  public void ComputeListDif_WhenCalled_ReturnsInBothDeletedInNewAndAddedInNew()
  {
    // Arrange
    var origionalList = new List<string> { "a", "b", "c" };
    var newList = new List<string> { "b", "c", "d" };
    Func<string, string> toHashable = (item) => item;
    // Act
    var result = ListComparison.ComputeListDif(origionalList, newList, toHashable);
    // Assert
    Assert.That(result.InBoth, Is.EquivalentTo(new List<string> { "b", "c" }));
    Assert.That(result.DeletedInNew, Is.EquivalentTo(new List<string> { "a" }));
    Assert.That(result.AddedInNew, Is.EquivalentTo(new List<string> { "d" }));
  }
}
