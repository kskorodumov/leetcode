using FluentAssertions;
using MaximumGap;
using Xunit;

namespace MaximumGap.Tests;

public class CountingSortTests
{
    [Theory]
    [InlineData(new[] {0}, 5)]
    [InlineData(new[] {4,2,1,5}, 5)]
    [InlineData(new[] {4,2,1, 1, 5}, 5)]
    public void FindTwosArraysMedianTest(int[] a, int max)
    {
        var actual = new CountingSort().Sort(a, max);
        Array.Sort(a);
        actual.Should().BeEquivalentTo(a);
    }
}