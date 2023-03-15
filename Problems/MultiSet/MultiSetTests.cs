using FluentAssertions;
using Xunit;

namespace MultiSet.Tests;

public class MultiSetTests
{
    [Fact]
    public void MultiSetTest1()
    {
        var set = new MultiSet();

        set.Add(1).Should().BeTrue();
        set.Add(2).Should().BeTrue();
        set.Add(1).Should().BeFalse();

        
        set.Remove(1).Should().BeTrue();
        set.Remove(1).Should().BeTrue();
        set.Remove(2).Should().BeTrue();

        set.Remove(1).Should().BeFalse();
    }
    
    [Fact]
    public void MultiSetTest2()
    {
        var set = new MultiSet();

        set.Add(1).Should().BeTrue();
        set.Add(10).Should().BeTrue();
        set.Add(10).Should().BeFalse();
        set.Add(100).Should().BeTrue();

        var a = new int[10];
        for (int i = 0; i < 10; i++)
        {
            a[i] = set.GetRandom();
        }
    }
}