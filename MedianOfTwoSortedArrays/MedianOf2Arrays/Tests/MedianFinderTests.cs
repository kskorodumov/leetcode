using FluentAssertions;
using Xunit;

namespace MedianOfTwoSortedArrays.MedianOf2Arrays.Tests;

public class MedianFinderTests
{
    [Theory]
    [InlineData(new[] {1, 2, 3, 5}, new [] {-1, 0, 6}, 2)]
    [InlineData(new[] {1, 2, 3, 5}, new [] {0}, 2)]
    [InlineData(new[] {1, 2, 3, 5, 6}, new [] {0, 7}, 3)]
    [InlineData(new[] {1, 2, 3, 50, 53, 300, 301}, new [] {100, 200}, 53)]
    [InlineData(new[] {1, 2, 3, 50, 53, 300, 301}, new [] {0, 100, 200, 1000, 1001, 1002}, 100)]
    [InlineData(new[] {1, 5}, new [] {2, 3}, 2.5)]
    [InlineData(new[] {1, 5, 8, 10}, new [] {2, 3}, 4)]
    [InlineData(new[] {1, 3}, new [] {2}, 2)]
    [InlineData(new[] {1, 2}, new [] {3, 4}, 2.5)]
    [InlineData(new[] {1, 2}, new [] {3}, 2)]
    [InlineData(new[] {1}, new [] {3}, 2)]
    [InlineData(new[] {5}, new [] {100, 200}, 100)]
    [InlineData(new[] {1, 2, 3}, new [] {100, 200, 201}, 51.5)]
    [InlineData(new[] {1, 2, 3, 4}, new [] {100}, 3)]
    [InlineData(new[] {2, 2, 2}, new [] {3, 3, 3}, 2.5)]
    [InlineData(new[] {2, 2, 2}, new [] {3, 3}, 2)]
    [InlineData(new[] {1, 2, 3, 5}, new [] {2, 3}, 2.5)]
    [InlineData(new[] {1, 2, 3, 5}, new int[] {}, 2.5)]
    [InlineData(new[] {1, 2, 3}, new int[] {}, 2)]
    [InlineData(new[] {0,0,0,0,0}, new [] {-1,0,0,0,0,0,1}, 0)]
    public void FindTwosArraysMedianTest(int[] a, int[] b, double expected)
    {
        var actual = MedianFinder.FindMedianSortedArrays(a, b);
        actual.Should().Be(expected);
    }

    [Theory]
    [InlineData(new[] {1, 2, 3}, 2, 0, 2, 2, 0)]
    [InlineData(new[] {1, 2, 3}, 4, 0, 2, 3, 0)]
    [InlineData(new[] {1, 2, 3}, 0, 0, 2, 0, 0)]
    [InlineData(new[] {1, 3, 5}, 2, 0, 2, 1, 0)]
    [InlineData(new[] {1, 2, 3, 5}, 4, 0, 2, 3, 0)]
    [InlineData(new[] {1}, 4, 0, 0, 1, 0)]
    [InlineData(new[] {2}, 1, 0, 0, 0, 0)]
    [InlineData(new[] {1, 2, 3, 5, 8, 12, 15}, 9, 3, 6, 5, 0)]
    [InlineData(new[] {1, 2, 3, 5, 8, 12, 15}, 9, 2, 4, 5, 0)]
    [InlineData(new[] {1, 2}, 9, 0, 1, 2, 0)]
    [InlineData(new[] {1, 3}, 2, 0, 1, 1, 0)]
    [InlineData(new[] {1, 3}, 0, 0, 1, 0, 0)]
    [InlineData(new[] {1, 3}, 0, 0, 0, 0, 0)]
    [InlineData(new[] {1, 3}, 1.5, 0, 1, 1, 0)]
    [InlineData(new[] {1, 2}, 3, 1, 1, 2, 0)]
    [InlineData(new[] {1, 2}, 2, 1, 1, 2, 0)]
    [InlineData(new[] {1, 2, 3, 5}, 2, 0, 3, 2, 0)]
    [InlineData(new[] {1, 2, 2, 2, 3, 5}, 2, 0, 5, 4, 0)]
    [InlineData(new[] {1, 2, 2, 2, 2, 3, 5}, 2, 0, 6, 4, 4)]
    [InlineData(new[] {1, 2, 2, 2, 2, 3, 5}, 2, 0, 6, 5, 5)]
    public void CountLesserElementsTest(int[] a, int x, int start, int end, int expected, int goal)
    {
        var actual = MedianFinder.CountLesserElements(a, x, start, end, goal);
        actual.Should().Be(expected);
    }
    
    [Theory]
    [InlineData(new[] {1, 2, 3}, 2, 0, 2, 2)]
    [InlineData(new[] {1, 2, 3}, 4, 0, 2, 0)]
    [InlineData(new[] {1, 2, 3}, 0, 0, 2, 3)]
    [InlineData(new[] {1, 3, 5}, 2, 0, 2, 2)]
    [InlineData(new[] {1, 2, 3, 5}, 4, 0, 2, 0)]
    [InlineData(new[] {1}, 4, 0, 0, 0)]
    [InlineData(new[] {2}, 1, 0, 0, 1)]
    [InlineData(new[] {1, 2, 3, 5, 8, 12, 15}, 9, 3, 6, 2)]
    [InlineData(new[] {1, 2, 3, 5, 8, 12, 15}, 9, 2, 4, 0)]
    [InlineData(new[] {1, 2}, 9, 0, 1, 0)]
    [InlineData(new[] {1, 3}, 2, 0, 1, 1)]
    [InlineData(new[] {1, 3}, 0, 0, 1, 2)]
    [InlineData(new[] {1, 3}, 0, 0, 0, 2)]
    [InlineData(new[] {1, 3}, 1.5, 0, 1, 1)]
    [InlineData(new[] {1, 3}, 4, 1, 1, 0)]
    [InlineData(new[] {1, 3}, 2, 1, 1, 1)]
    [InlineData(new[] {1, 3, 3, 3}, 3, 0, 3, 3)]
    public void CountBiggerElementsTest(int[] a, int x, int start, int end, int expected)
    {
        var actual = MedianFinder.CountBiggerElements(a, x, start, end);
        actual.Should().Be(expected);
    }
}