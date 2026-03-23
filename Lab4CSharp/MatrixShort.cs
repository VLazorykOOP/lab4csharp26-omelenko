using System;

namespace Lab4CSharp;

public class MatrixShort
{
    protected short[,] ShortArray;
    protected int n, m;
    protected int codeError;
    protected static int num_m = 0;

    public MatrixShort()
    {
        n = 1; m = 1;
        ShortArray = new short[n, m];
        ShortArray[0, 0] = 0;
        codeError = 0;
        num_m++;
    }

    public MatrixShort(int rows, int cols)
    {
        n = rows; m = cols;
        ShortArray = new short[n, m];
        for (int i = 0; i < n; i++)
            for (int j = 0; j < m; j++)
                ShortArray[i, j] = 0;
        codeError = 0;
        num_m++;
    }

    public MatrixShort(int rows, int cols, short initValue)
    {
        n = rows; m = cols;
        ShortArray = new short[n, m];
        for (int i = 0; i < n; i++)
            for (int j = 0; j < m; j++)
                ShortArray[i, j] = initValue;
        codeError = 0;
        num_m++;
    }

    ~MatrixShort()
    {
        Console.WriteLine("Деструктор: об'єкт MatrixShort видалено.");
    }

    public void Input()
    {
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                Console.Write($"M[{i},{j}] = ");
                if (short.TryParse(Console.ReadLine(), out short val))
                    ShortArray[i, j] = val;
                else
                    j--;
            }
        }
    }

    public void Display()
    {
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++) Console.Write($"{ShortArray[i, j]} \t");
            Console.WriteLine();
        }
    }

    public void SetValue(short value)
    {
        for (int i = 0; i < n; i++)
            for (int j = 0; j < m; j++)
                ShortArray[i, j] = value;
    }

    public static int GetNumMatrices() => num_m;

    public int Rows => n;
    public int Cols => m;
    public int CodeError { get => codeError; set => codeError = value; }

    public short this[int i, int j]
    {
        get
        {
            if (i < 0 || i >= n || j < 0 || j >= m) { codeError = -1; return 0; }
            return ShortArray[i, j];
        }
        set
        {
            if (i < 0 || i >= n || j < 0 || j >= m) codeError = -1;
            else ShortArray[i, j] = value;
        }
    }

    public short this[int k]
    {
        get
        {
            int i = k / m;
            int j = k % m;
            if (i < 0 || i >= n || j < 0 || j >= m) { codeError = -1; return 0; }
            return ShortArray[i, j];
        }
        set
        {
            int i = k / m;
            int j = k % m;
            if (i < 0 || i >= n || j < 0 || j >= m) codeError = -1;
            else ShortArray[i, j] = value;
        }
    }

    public static MatrixShort operator ++(MatrixShort mat)
    {
        for (int i = 0; i < mat.n; i++)
            for (int j = 0; j < mat.m; j++) mat.ShortArray[i, j]++;
        return mat;
    }

    public static MatrixShort operator --(MatrixShort mat)
    {
        for (int i = 0; i < mat.n; i++)
            for (int j = 0; j < mat.m; j++) mat.ShortArray[i, j]--;
        return mat;
    }

    public static bool operator true(MatrixShort mat)
    {
        if (mat.n == 0 || mat.m == 0) return false;
        foreach (var x in mat.ShortArray) if (x != 0) return true;
        return false;
    }

    public static bool operator false(MatrixShort mat)
    {
        if (mat.n == 0 || mat.m == 0) return true;
        foreach (var x in mat.ShortArray) if (x != 0) return false;
        return true;
    }

    public static bool operator !(MatrixShort mat) => mat.n != 0 && mat.m != 0;

    public static MatrixShort operator ~(MatrixShort mat)
    {
        MatrixShort res = new MatrixShort(mat.n, mat.m);
        for (int i = 0; i < mat.n; i++)
            for (int j = 0; j < mat.m; j++) res.ShortArray[i, j] = (short)~mat.ShortArray[i, j];
        return res;
    }

    public static MatrixShort operator +(MatrixShort a, MatrixShort b)
    {
        MatrixShort res = new MatrixShort(Math.Min(a.n, b.n), Math.Min(a.m, b.m));
        for (int i = 0; i < res.n; i++)
            for (int j = 0; j < res.m; j++) res[i, j] = (short)(a[i, j] + b[i, j]);
        return res;
    }

    public static MatrixShort operator +(MatrixShort a, short s)
    {
        MatrixShort res = new MatrixShort(a.n, a.m);
        for (int i = 0; i < a.n; i++)
            for (int j = 0; j < a.m; j++) res[i, j] = (short)(a[i, j] + s);
        return res;
    }

    public static MatrixShort operator -(MatrixShort a, MatrixShort b)
    {
        MatrixShort res = new MatrixShort(Math.Min(a.n, b.n), Math.Min(a.m, b.m));
        for (int i = 0; i < res.n; i++)
            for (int j = 0; j < res.m; j++) res[i, j] = (short)(a[i, j] - b[i, j]);
        return res;
    }

    public static MatrixShort operator -(MatrixShort a, short s)
    {
        MatrixShort res = new MatrixShort(a.n, a.m);
        for (int i = 0; i < a.n; i++)
            for (int j = 0; j < a.m; j++) res[i, j] = (short)(a[i, j] - s);
        return res;
    }

    public static MatrixShort operator *(MatrixShort a, MatrixShort b)
    {
        MatrixShort res = new MatrixShort(Math.Min(a.n, b.n), Math.Min(a.m, b.m));
        for (int i = 0; i < res.n; i++)
            for (int j = 0; j < res.m; j++) res[i, j] = (short)(a[i, j] * b[i, j]);
        return res;
    }

    public static VectorShort operator *(MatrixShort a, VectorShort v)
    {
        int common = Math.Min(a.m, (int)v.Size);
        VectorShort res = new VectorShort((uint)a.n);
        for (int i = 0; i < a.n; i++)
        {
            short sum = 0;
            for (int j = 0; j < common; j++) sum += (short)(a[i, j] * v[j]);
            res[i] = sum;
        }
        return res;
    }

    public static MatrixShort operator *(MatrixShort a, short s)
    {
        MatrixShort res = new MatrixShort(a.n, a.m);
        for (int i = 0; i < a.n; i++)
            for (int j = 0; j < a.m; j++) res[i, j] = (short)(a[i, j] * s);
        return res;
    }

    public static MatrixShort operator /(MatrixShort a, MatrixShort b)
    {
        MatrixShort res = new MatrixShort(Math.Min(a.n, b.n), Math.Min(a.m, b.m));
        for (int i = 0; i < res.n; i++)
            for (int j = 0; j < res.m; j++) res[i, j] = b[i, j] != 0 ? (short)(a[i, j] / b[i, j]) : (short)0;
        return res;
    }

    public static MatrixShort operator /(MatrixShort a, short s)
    {
        MatrixShort res = new MatrixShort(a.n, a.m);
        if (s == 0) return res;
        for (int i = 0; i < a.n; i++)
            for (int j = 0; j < a.m; j++) res[i, j] = (short)(a[i, j] / s);
        return res;
    }

    public static MatrixShort operator %(MatrixShort a, MatrixShort b)
    {
        MatrixShort res = new MatrixShort(Math.Min(a.n, b.n), Math.Min(a.m, b.m));
        for (int i = 0; i < res.n; i++)
            for (int j = 0; j < res.m; j++) res[i, j] = b[i, j] != 0 ? (short)(a[i, j] % b[i, j]) : (short)0;
        return res;
    }

    public static MatrixShort operator %(MatrixShort a, short s)
    {
        MatrixShort res = new MatrixShort(a.n, a.m);
        if (s == 0) return res;
        for (int i = 0; i < a.n; i++)
            for (int j = 0; j < a.m; j++) res[i, j] = (short)(a[i, j] % s);
        return res;
    }

    public static MatrixShort operator |(MatrixShort a, MatrixShort b)
    {
        MatrixShort res = new MatrixShort(Math.Min(a.n, b.n), Math.Min(a.m, b.m));
        for (int i = 0; i < res.n; i++)
            for (int j = 0; j < res.m; j++) res[i, j] = (short)(a[i, j] | b[i, j]);
        return res;
    }

    public static MatrixShort operator |(MatrixShort a, ushort s)
    {
        MatrixShort res = new MatrixShort(a.n, a.m);
        for (int i = 0; i < a.n; i++)
            for (int j = 0; j < a.m; j++) res[i, j] = (short)(a[i, j] | (short)s);
        return res;
    }

    public static MatrixShort operator ^(MatrixShort a, MatrixShort b)
    {
        MatrixShort res = new MatrixShort(Math.Min(a.n, b.n), Math.Min(a.m, b.m));
        for (int i = 0; i < res.n; i++)
            for (int j = 0; j < res.m; j++) res[i, j] = (short)(a[i, j] ^ b[i, j]);
        return res;
    }

    public static MatrixShort operator ^(MatrixShort a, ushort s)
    {
        MatrixShort res = new MatrixShort(a.n, a.m);
        for (int i = 0; i < a.n; i++)
            for (int j = 0; j < a.m; j++) res[i, j] = (short)(a[i, j] ^ (short)s);
        return res;
    }

    public static MatrixShort operator &(MatrixShort a, MatrixShort b)
    {
        MatrixShort res = new MatrixShort(Math.Min(a.n, b.n), Math.Min(a.m, b.m));
        for (int i = 0; i < res.n; i++)
            for (int j = 0; j < res.m; j++) res[i, j] = (short)(a[i, j] & b[i, j]);
        return res;
    }

    public static MatrixShort operator &(MatrixShort a, ushort s)
    {
        MatrixShort res = new MatrixShort(a.n, a.m);
        for (int i = 0; i < a.n; i++)
            for (int j = 0; j < a.m; j++) res[i, j] = (short)(a[i, j] & (short)s);
        return res;
    }

    public static MatrixShort operator >>(MatrixShort a, uint s)
    {
        MatrixShort res = new MatrixShort(a.n, a.m);
        for (int i = 0; i < a.n; i++)
            for (int j = 0; j < a.m; j++) res[i, j] = (short)(a[i, j] >> (int)s);
        return res;
    }

    public static MatrixShort operator <<(MatrixShort a, uint s)
    {
        MatrixShort res = new MatrixShort(a.n, a.m);
        for (int i = 0; i < a.n; i++)
            for (int j = 0; j < a.m; j++) res[i, j] = (short)(a[i, j] << (int)s);
        return res;
    }

    public static bool operator ==(MatrixShort a, MatrixShort b)
    {
        if (a.n != b.n || a.m != b.m) return false;
        for (int i = 0; i < a.n; i++)
            for (int j = 0; j < a.m; j++) if (a[i, j] != b[i, j]) return false;
        return true;
    }

    public static bool operator !=(MatrixShort a, MatrixShort b) => !(a == b);

    public static bool operator >(MatrixShort a, MatrixShort b)
    {
        for (int i = 0; i < Math.Min(a.n, b.n); i++)
            for (int j = 0; j < Math.Min(a.m, b.m); j++) if (!(a[i, j] > b[i, j])) return false;
        return true;
    }

    public static bool operator <(MatrixShort a, MatrixShort b)
    {
        for (int i = 0; i < Math.Min(a.n, b.n); i++)
            for (int j = 0; j < Math.Min(a.m, b.m); j++) if (!(a[i, j] < b[i, j])) return false;
        return true;
    }

    public static bool operator >=(MatrixShort a, MatrixShort b)
    {
        for (int i = 0; i < Math.Min(a.n, b.n); i++)
            for (int j = 0; j < Math.Min(a.m, b.m); j++) if (!(a[i, j] >= b[i, j])) return false;
        return true;
    }

    public static bool operator <=(MatrixShort a, MatrixShort b)
    {
        for (int i = 0; i < Math.Min(a.n, b.n); i++)
            for (int j = 0; j < Math.Min(a.m, b.m); j++) if (!(a[i, j] <= b[i, j])) return false;
        return true;
    }

    public override bool Equals(object obj) => obj is MatrixShort m && this == m;
    public override int GetHashCode() => ShortArray.GetHashCode();
}