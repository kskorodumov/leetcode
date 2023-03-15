using FluentAssertions;
using Xunit;

namespace MedianOfTwoSortedArrays.MaximumGap;

public class MaximumGapFinderTests
{
    [Theory]
    [InlineData(new[] {0}, 0)]
    [InlineData(new[] {3,6,9,1}, 3)]
    [InlineData(new[] {1,10000000}, 9999999)]
    public void FindTwosArraysMedianTest(int[] a, int expected)
    {
        var actual = new MaximumGapFinder().MaximumGap(a);
        actual.Should().Be(expected);
    }
}