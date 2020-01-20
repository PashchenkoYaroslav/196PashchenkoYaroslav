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
        /// <summary>
        /// Метод тестирует делегат, сравнивая выдаванное им значение
        /// с заданным правильным ответом.
        /// </summary>
        /// <param name="caster"></param>
        /// <param name="delegatename"></param>
        /// <param name="testAns"></param>
        /// <param name="testValue"></param>
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
        /// <summary>
        /// Метод тестирует делегат, сравнивая выдаваемые им значения 
        /// с заданными правильными ответами.
        /// </summary>
        /// <param name="caster"></param>
        /// <param name="delegatename"></param>
        /// <param name="testAns"></param>
        /// <param name="testValue"></param>
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
        /// <summary>
        /// Метод создает многоадресный делегат, 
        /// связывает его с 2 методами
        /// и вызывает его от заданного числа.
        /// </summary>
        /// <param name="firstCast"></param>
        /// <param name="secondCast"></param>
        /// <param name="x"></param>
        static void ThirdCast(Cast firstCast, Cast secondCast, double x)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Вызовем третий делегат");
            Console.ResetColor();
            Cast thirdCast = firstCast;
            thirdCast += secondCast;
            Console.WriteLine(thirdCast(x));
        }

        static void Main(string[] args)
        {
            // Можно было использовать модульное тестирование.
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
                SingleTest(firstCast, "первого", singleTestOneAns, singleTestValue);
                SingleTest(secondCast, "второго", singleTestTwoAns, singleTestValue);
                MultiplyTest(firstCast, "первого", multiplyTestOneAns, multipleTestValues);
                MultiplyTest(secondCast, "первого", multiplyTestTwoAns, multipleTestValues);
                ThirdCast(firstCast, secondCast, 23.7);
                Console.WriteLine("Нажмите Escape чтобы выйти" + Environment.NewLine 
                    + "Нажмите на Enter чтобы продолжить");
            }
            while (Console.ReadKey().Key != ConsoleKey.Escape);
        }
    }
}

