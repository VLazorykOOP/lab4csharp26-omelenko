using Lab4CSharp;
using Xunit;

namespace Lab4CSharp.Tests;

public class MatrixShortTests
{
    [Fact]
    public void TestMatrixMultiplicationByVector()
    {
        // 2x2 з одиницями
        var mat = new MatrixShort(2, 2, 1);
        // вектор [5, 5]
        var vec = new VectorShort(2, 5);

        // має бути [1*5 + 1*5, 1*5 + 1*5] = [10, 10]
        VectorShort res = mat * vec;

        Assert.Equal(10, res[0]);
        Assert.Equal(10, res[1]);
    }

    [Fact]
    public void TestMatrixIndexer()
    {
        var mat = new MatrixShort(3, 3, 0);
        mat[1, 1] = 7; // двовимірний індексатор

        // k = i * m + j = 1 * 3 + 1 = 4
        Assert.Equal(7, (int)mat[4]); // одновимірний індексатор
    }

    [Fact]
    public void TestMatrixComparison()
    {
        var m1 = new MatrixShort(2, 2, 10);
        var m2 = new MatrixShort(2, 2, 5);

        Assert.True(m1 > m2);
        Assert.False(m1 == m2);
    }
}