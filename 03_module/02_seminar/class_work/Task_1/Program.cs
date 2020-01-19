using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public delegate int Cast(double x);
    class Program
    {
        const double singleTestValue = -13.53;
        const int singleTestOneAns = -14;
        const int singleTestTwoAns = 2;
        static void SingleTest(Cast caster, string delegatename, int testAns, double testValue)
        {
            Console.ResetColor();
            Console.WriteLine("Тестирование {0} делегата:", delegatename);
            if (Equals(caster(testValue), testAns))
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Первый тест пройден");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Первый тест провален");
            }
        }
        static void MultiplyTest(Cast caster, string delegatename, int[] testAns, double[] testValue)
        {
            bool testResult = true;
            Console.ResetColor();
            Console.WriteLine("Тестирование {0} делегата:", delegatename);
            for (int i = 0; i < testValue.Length; i++)
            {
                if (!Equals(caster(testValue[i]), testAns[i]))
                    testResult = false;
            }
            if (testResult)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Множественный тест пройден");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Множественный тест провален");
            }
        }
        static void Main(string[] args)
        {
            do
            {
                double[] multipleTestValues = { 24.4, -1111.1, 1293.0, 340, -11.6, 33.5, 0 };
                int[] multiplyTestOneAns = { 24, -1112, 1294, 340, -12, 34, 0 };
                int[] multiplyTestTwoAns = { 2, 4, 4, 3, 2, 2, 0 };
                Cast firstCast = x =>
                {
                    int e;
                    e = x < 0 ? -1 : 1;
                    x = Math.Round(x, MidpointRounding.ToEven);
                    x = x % 2 == 0 ? x : x + e;
                    return (int)x;
                };
                Cast secondCast = x =>
                {
                    int counter = 0;
                    x = Math.Abs(x);
                    while (x - x % 1 > 0)
                    {
                        x /= 10;
                        counter++;
                    }
                    return counter;
                };

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Начинаем тестирование!");
                // Можно было использовать модульное тестирование.
                SingleTest(firstCast, "первого", singleTestOneAns, singleTestValue);
                SingleTest(secondCast, "второго", singleTestTwoAns, singleTestValue);
                MultiplyTest(firstCast, "первого", multiplyTestOneAns, multipleTestValues);
                MultiplyTest(secondCast, "первого", multiplyTestTwoAns, multipleTestValues);
                Console.ResetColor();
                Console.WriteLine("Нажмите Escape чтобы выйти" + Environment.NewLine + "Нажмите на Enter чтобы продолжить");
            }
            while (Console.ReadKey().Key != ConsoleKey.Escape);
        }
    }
}

