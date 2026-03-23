using System;

namespace Lab4CSharp;

public class VectorShort
{
    protected short[] ShortArray;
    protected uint n;
    protected uint codeError;
    protected static uint num_v = 0;

    public VectorShort()
    {
        n = 1;
        ShortArray = new short[n];
        ShortArray[0] = 0;
        codeError = 0;
        num_v++;
    }

    public VectorShort(uint size)
    {
        n = size;
        ShortArray = new short[n];
        for (int i = 0; i < n; i++) ShortArray[i] = 0;
        codeError = 0;
        num_v++;
    }

    public VectorShort(uint size, short initValue)
    {
        n = size;
        ShortArray = new short[n];
        for (int i = 0; i < n; i++) ShortArray[i] = initValue;
        codeError = 0;
        num_v++;
    }

    ~VectorShort()
    {
        Console.WriteLine("Деструктор: об'єкт VectorShort видалено.");
    }

    public void Input()
    {
        for (int i = 0; i < n; i++)
        {
            Console.Write($"v[{i}] = ");
            if (short.TryParse(Console.ReadLine(), out short val))
                ShortArray[i] = val;
            else
                i--;
        }
    }

    public void Display()
    {
        for (int i = 0; i < n; i++) Console.Write($"{ShortArray[i]} ");
        Console.WriteLine();
    }

    public void SetValue(short value)
    {
        for (int i = 0; i < n; i++) ShortArray[i] = value;
    }

    public static uint GetNumVectors() => num_v;

    public uint Size => n;

    public uint CodeError
    {
        get => codeError;
        set => codeError = value;
    }

    public short this[int index]
    {
        get
        {
            if (index < 0 || index >= n)
            {
                codeError = 10;
                return 0;
            }
            return ShortArray[index];
        }
        set
        {
            if (index < 0 || index >= n)
            {
                codeError = 10;
            }
            else
            {
                ShortArray[index] = value;
            }
        }
    }

    public static VectorShort operator ++(VectorShort v)
    {
        for (int i = 0; i < v.n; i++) v.ShortArray[i]++;
        return v;
    }

    public static VectorShort operator --(VectorShort v)
    {
        for (int i = 0; i < v.n; i++) v.ShortArray[i]--;
        return v;
    }

    public static bool operator true(VectorShort v)
    {
        if (v.n == 0) return false;
        foreach (var x in v.ShortArray) if (x != 0) return true;
        return false;
    }

    public static bool operator false(VectorShort v)
    {
        if (v.n == 0) return true;
        foreach (var x in v.ShortArray) if (x != 0) return false;
        return true;
    }

    public static bool operator !(VectorShort v) => v.n != 0;

    public static VectorShort operator ~(VectorShort v)
    {
        VectorShort res = new VectorShort(v.n);
        for (int i = 0; i < v.n; i++) res.ShortArray[i] = (short)~v.ShortArray[i];
        return res;
    }

    public static VectorShort operator +(VectorShort v1, VectorShort v2)
    {
        uint size = Math.Min(v1.n, v2.n);
        VectorShort res = new VectorShort(size);
        for (int i = 0; i < size; i++) res[i] = (short)(v1[i] + v2[i]);
        return res;
    }

    public static VectorShort operator +(VectorShort v, short s)
    {
        VectorShort res = new VectorShort(v.n);
        for (int i = 0; i < v.n; i++) res[i] = (short)(v[i] + s);
        return res;
    }

    public static VectorShort operator -(VectorShort v1, VectorShort v2)
    {
        uint size = Math.Min(v1.n, v2.n);
        VectorShort res = new VectorShort(size);
        for (int i = 0; i < size; i++) res[i] = (short)(v1[i] - v2[i]);
        return res;
    }

    public static VectorShort operator -(VectorShort v, short s)
    {
        VectorShort res = new VectorShort(v.n);
        for (int i = 0; i < v.n; i++) res[i] = (short)(v[i] - s);
        return res;
    }

    public static VectorShort operator *(VectorShort v1, VectorShort v2)
    {
        uint size = Math.Min(v1.n, v2.n);
        VectorShort res = new VectorShort(size);
        for (int i = 0; i < size; i++) res[i] = (short)(v1[i] * v2[i]);
        return res;
    }

    public static VectorShort operator *(VectorShort v, short s)
    {
        VectorShort res = new VectorShort(v.n);
        for (int i = 0; i < v.n; i++) res[i] = (short)(v[i] * s);
        return res;
    }

    public static VectorShort operator /(VectorShort v1, VectorShort v2)
    {
        uint size = Math.Min(v1.n, v2.n);
        VectorShort res = new VectorShort(size);
        for (int i = 0; i < size; i++)
            res[i] = v2[i] != 0 ? (short)(v1[i] / v2[i]) : (short)0;
        return res;
    }

    public static VectorShort operator /(VectorShort v, ushort s)
    {
        VectorShort res = new VectorShort(v.n);
        if (s == 0) return res;
        for (int i = 0; i < v.n; i++) res[i] = (short)(v[i] / s);
        return res;
    }

    public static VectorShort operator %(VectorShort v1, VectorShort v2)
    {
        uint size = Math.Min(v1.n, v2.n);
        VectorShort res = new VectorShort(size);
        for (int i = 0; i < size; i++)
            res[i] = v2[i] != 0 ? (short)(v1[i] % v2[i]) : (short)0;
        return res;
    }

    public static VectorShort operator %(VectorShort v, short s)
    {
        VectorShort res = new VectorShort(v.n);
        if (s == 0) return res;
        for (int i = 0; i < v.n; i++) res[i] = (short)(v[i] % s);
        return res;
    }

    public static VectorShort operator |(VectorShort v1, VectorShort v2)
    {
        uint size = Math.Min(v1.n, v2.n);
        VectorShort res = new VectorShort(size);
        for (int i = 0; i < size; i++) res[i] = (short)(v1[i] | v2[i]);
        return res;
    }

    public static VectorShort operator |(VectorShort v, short s)
    {
        VectorShort res = new VectorShort(v.n);
        for (int i = 0; i < v.n; i++) res[i] = (short)(v[i] | s);
        return res;
    }

    public static VectorShort operator ^(VectorShort v1, VectorShort v2)
    {
        uint size = Math.Min(v1.n, v2.n);
        VectorShort res = new VectorShort(size);
        for (int i = 0; i < size; i++) res[i] = (short)(v1[i] ^ v2[i]);
        return res;
    }

    public static VectorShort operator ^(VectorShort v, short s)
    {
        VectorShort res = new VectorShort(v.n);
        for (int i = 0; i < v.n; i++) res[i] = (short)(v[i] ^ s);
        return res;
    }

    public static VectorShort operator &(VectorShort v1, VectorShort v2)
    {
        uint size = Math.Min(v1.n, v2.n);
        VectorShort res = new VectorShort(size);
        for (int i = 0; i < size; i++) res[i] = (short)(v1[i] & v2[i]);
        return res;
    }

    public static VectorShort operator &(VectorShort v, short s)
    {
        VectorShort res = new VectorShort(v.n);
        for (int i = 0; i < v.n; i++) res[i] = (short)(v[i] & s);
        return res;
    }

    public static VectorShort operator >>(VectorShort v, ushort s)
    {
        VectorShort res = new VectorShort(v.n);
        for (int i = 0; i < v.n; i++) res[i] = (short)(v[i] >> s);
        return res;
    }

    public static VectorShort operator <<(VectorShort v, ushort s)
    {
        VectorShort res = new VectorShort(v.n);
        for (int i = 0; i < v.n; i++) res[i] = (short)(v[i] << s);
        return res;
    }

    public static bool operator ==(VectorShort v1, VectorShort v2)
    {
        if (v1.n != v2.n) return false;
        for (int i = 0; i < v1.n; i++) if (v1[i] != v2[i]) return false;
        return true;
    }

    public static bool operator !=(VectorShort v1, VectorShort v2) => !(v1 == v2);

    public static bool operator >(VectorShort v1, VectorShort v2)
    {
        for (int i = 0; i < Math.Min(v1.n, v2.n); i++) if (!(v1[i] > v2[i])) return false;
        return true;
    }

    public static bool operator <(VectorShort v1, VectorShort v2)
    {
        for (int i = 0; i < Math.Min(v1.n, v2.n); i++) if (!(v1[i] < v2[i])) return false;
        return true;
    }

    public static bool operator >=(VectorShort v1, VectorShort v2)
    {
        for (int i = 0; i < Math.Min(v1.n, v2.n); i++) if (!(v1[i] >= v2[i])) return false;
        return true;
    }

    public static bool operator <=(VectorShort v1, VectorShort v2)
    {
        for (int i = 0; i < Math.Min(v1.n, v2.n); i++) if (!(v1[i] <= v2[i])) return false;
        return true;
    }

    public override bool Equals(object obj) => obj is VectorShort v && this == v;
    public override int GetHashCode() => ShortArray.GetHashCode();
}