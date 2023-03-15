using FluentAssertions;
using Xunit;

namespace MedianOfTwoSortedArrays.MaximumGap;

public class RadixSortTests
{
    [Theory]
    [InlineData(new[] {0})]
    [InlineData(new[] {4,2,1,5})]
    [InlineData(new[] {4,2,1,1,5})]
    [InlineData(new[] {4,2,1,1,5, 10, 2, 0, 12})]
    [InlineData(new[] {329, 457, 657, 839, 436, 720, 355})]
    public void FindTwosArraysMedianTest(int[] a)
    {
        var actual = new RadixSort().Sort(a);
        Array.Sort(a);
        actual.Should().BeEquivalentTo(a);
    }
}