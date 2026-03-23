using Xunit;
using Lab4CSharp;

namespace Lab4CSharp.Tests;

public class RectangleTests
{
    [Fact]
    public void TestAreaAndPerimeter()
    {
        var rect = new Rectangle(5, 10, 1);
        Assert.Equal(50, rect.GetArea());
        Assert.Equal(30, rect.GetPerimeter());
    }

    [Fact]
    public void TestIndexerAndOperators()
    {
        var rect = new Rectangle(5, 5, 1);
        Assert.True(true, rect);

        rect[0] = 10;
        Assert.Equal(10, rect.SideA);
        Assert.False(false, rect);
    }

    [Fact]
    public void TestImplicitStringConversion()
    {
        var rect = new Rectangle(2, 3, 0);
        string s = rect;
        Assert.Contains("[Прямокутник] 2x3", s);
    }
}