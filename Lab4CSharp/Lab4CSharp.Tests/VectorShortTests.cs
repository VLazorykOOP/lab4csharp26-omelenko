using Lab4CSharp;
using Xunit;

namespace Lab4CSharp.Tests;

public class VectorShortTests
{
    [Fact]
    public void TestVectorAddition()
    {
        var v1 = new VectorShort(2, 10);
        var v2 = new VectorShort(2, 5);
        var res = v1 + v2;

        Assert.Equal(15, res[0]);
        Assert.Equal(15, res[1]);
    }

    [Fact]
    public void TestIndexErrorHandling()
    {
        var v = new VectorShort(2, 0);
        var val = v[10];

        Assert.Equal(0, val);
        Assert.Equal((uint)10, v.CodeError);
    }

    [Fact]
    public void TestUnaryOperators()
    {
        var v = new VectorShort(1, 5);
        v++;
        Assert.Equal(6, v[0]);

        var vNot = ~v;
        Assert.Equal((short)~6, vNot[0]);
    }
}