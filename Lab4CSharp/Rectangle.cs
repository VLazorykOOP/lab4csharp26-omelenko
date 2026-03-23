using System;

namespace Lab4CSharp;

public class Rectangle
{
    protected int a, b;
    protected int c;

    public Rectangle(int sideA, int sideB, int color)
    {
        a = sideA;
        b = sideB;
        c = color;
    }

    public int SideA
    {
        get => a;
        set => a = value;
    }

    public int SideB
    {
        get => b;
        set => b = value;
    }

    public int Color => c;

    public void ShowSides() => Console.WriteLine($"Сторони: {a}, {b}");

    public int GetPerimeter() => 2 * (a + b);

    public int GetArea() => a * b;

    public bool IsSquare() => a == b;

    public int this[int index]
    {
        get
        {
            return index switch
            {
                0 => a,
                1 => b,
                2 => c,
                _ => throw new IndexOutOfRangeException("Invalid index")
            };
        }
        set
        {
            switch (index)
            {
                case 0: a = value; break;
                case 1: b = value; break;
                case 2: c = value; break;
                default: Console.WriteLine("Invalid index"); break;
            }
        }
    }

    public static Rectangle operator ++(Rectangle r)
    {
        r.a++;
        r.b++;
        return r;
    }

    public static Rectangle operator --(Rectangle r)
    {
        r.a--;
        r.b--;
        return r;
    }

    public static bool operator true(Rectangle r) => r.IsSquare();

    public static bool operator false(Rectangle r) => !r.IsSquare();

    public static Rectangle operator *(Rectangle r, int scalar)
    {
        return new Rectangle(r.a * scalar, r.b * scalar, r.c);
    }

    public static implicit operator string(Rectangle r) => r.ToString();

    public static explicit operator Rectangle(string s)
    {
        var parts = s.Split(',');
        return new Rectangle(int.Parse(parts[0]), int.Parse(parts[1]), int.Parse(parts[2]));
    }

    public override string ToString()
    {
        return $"[Прямокутник] {a}x{b}, Колір: {c}, Пл: {GetArea()}, Пер: {GetPerimeter()}, Квадрат: {(IsSquare() ? "Так" : "Ні")}";
    }
}