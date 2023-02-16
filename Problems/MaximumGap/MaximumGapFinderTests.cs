using FluentAssertions;
using Xunit;

namespace MedianOfTwoSortedArrays.MaximumGap;

public class MaximumGapFinderTests
{
    [Theory]
    [InlineData(new[] {0}, 0)]
    public void FindTwosArraysMedianTest(int[] a, int expected)
    {
        var actual = new MaximumGapFinder().MaximumGap(a);
        actual.Should().Be(expected);
    }
}