using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab4CSharp;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        while (true)
        {
            Console.WriteLine("\n--- Оберіть завдання ---");
            Console.WriteLine("1. Тестування Rectangle");
            Console.WriteLine("2. Тестування VectorShort");
            Console.WriteLine("3. Тестування SportTeam (Структури)");
            Console.WriteLine("4. Тестування MatrixShort");
            Console.WriteLine("0. Вихід");
            Console.Write("Ваш вибір: ");

            string choice = Console.ReadLine();
            if (choice == "0") break;

            switch (choice)
            {
                case "1": TestRectangle(); break;
                case "2": TestVectorShort(); break;
                case "3": TestSportTeams(); break;
                case "4": TestMatrixShort(); break;
                default: Console.WriteLine("Невірний вибір."); break;
            }
        }
    }

    static void TestRectangle()
    {
        Rectangle rect = new Rectangle(5, 10, 1);
        Console.WriteLine($"Початковий стан: {rect}");
        Console.WriteLine($"Індексатор [0]: {rect[0]}, [1]: {rect[1]}");
        rect++;
        Console.WriteLine($"Після rect++: {rect}");
        Console.WriteLine($"Перетворення в string (неявне): {(string)rect}");
    }

    static void TestVectorShort()
    {
        VectorShort v1 = new VectorShort(3, 10);
        VectorShort v2 = new VectorShort(3, 5);
        Console.WriteLine("Вектор 1:"); v1.Display();
        Console.WriteLine("Вектор 2:"); v2.Display();

        VectorShort v3 = v1 + v2;
        Console.Write("v1 + v2 = "); v3.Display();

        v1++;
        Console.Write("v1 після ++: "); v1.Display();

        Console.WriteLine($"Перевірка на true (не нульовий): {(v1 ? "True" : "False")}");

        v1[10] = 5; // Виклик помилки індексу
        Console.WriteLine($"Код помилки після v1[10]: {v1.CodeError}");
    }

    static void TestSportTeams()
    {
        List<SportTeamStruct> teams = new List<SportTeamStruct>
        {
            new SportTeamStruct { Name = "Динамо", City = "Київ", PlayersCount = 25, Points = 50 },
            new SportTeamStruct { Name = "Шахтар", City = "Донецьк", PlayersCount = 24, Points = 48 },
            new SportTeamStruct { Name = "Ворскла", City = "Полтава", PlayersCount = 22, Points = 30 }
        };

        Console.Write("Введіть мінімальну кількість очок: ");
        if (int.TryParse(Console.ReadLine(), out int minPoints))
        {
            teams.RemoveAll(t => t.Points < minPoints);
            teams.Insert(0, new SportTeamStruct { Name = "Зоря", City = "Луганськ", PlayersCount = 23, Points = 40 });
            teams.Insert(0, new SportTeamStruct { Name = "Дніпро-1", City = "Дніпро", PlayersCount = 22, Points = 45 });
            Console.WriteLine("\nРезультат:");
            teams.ForEach(t => Console.WriteLine(t));
        }
    }

    static void TestMatrixShort()
    {
        MatrixShort m1 = new MatrixShort(2, 2, 10);
        MatrixShort m2 = new MatrixShort(2, 2, 2);
        VectorShort v = new VectorShort(2, 3);

        Console.WriteLine("Матриця M1:"); m1.Display();
        Console.WriteLine("Вектор V:"); v.Display();

        VectorShort resV = m1 * v;
        Console.Write("Результат M1 * V (Вектор): "); resV.Display();

        MatrixShort m3 = m1 + m2;
        Console.WriteLine("M1 + M2:"); m3.Display();

        m1[0, 0] = 99;
        Console.WriteLine("M1 після M1[0,0]=99:"); m1.Display();

        Console.WriteLine($"Кількість створених матриць: {MatrixShort.GetNumMatrices()}");
    }
}