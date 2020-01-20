using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_2_Library;
using Separated_Task2_Library;

namespace Task_2
{
    class Program
    {
        static public int n = 20916;
        static public int[] arr = { 31, 24, 58, 23, 99, 44, 64, 20, 79, 41 };
        static void Main(string[] args)
        {

            do
            {
                SecondTaskDelegate.CreateArray arrayCreator = Methods.CreateArray;
                SecondTaskDelegate.ShowArray arrayShow = Methods.ShowArray;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Начинаем тестирование!");
                FirstTesting(arrayCreator, arrayShow);
                SecondTesting(arrayCreator, arrayShow);
                Console.WriteLine("Нажмите Escape чтобы выйти" + Environment.NewLine
                    + "Нажмите на Enter чтобы продолжить");
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }
        /// <summary>
        /// Метод позволяет визульно сравнить результаты применения делегата и 
        /// метода заданного в классе Program
        /// к заданному числу
        /// </summary>
        /// <param name="arrayCreator">Первый делегат</param>
        /// <param name="arrayShow">Второй делегат</param>

        private static void SecondTesting(SecondTaskDelegate.CreateArray arrayCreator, SecondTaskDelegate.ShowArray arrayShow)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            foreach (var el in arr)
            {
                arrayShow(arrayCreator(el));
            }
            Console.WriteLine();
            for (int i = 0; i < arr.Length; i++)
            {
                string temp = arr[i].ToString();
                Console.Write(temp[0] + " ");
                Console.Write(temp[1] + " ");
            }
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(Environment.NewLine + "Если две верхние строчки одинаковы, вторая проверка пройдена!");
        }
        /// <summary>
        /// Метод позволяет визульно сравнить результаты применения делегата и 
        /// метода заданного в классе Program
        /// к заданному массиву 
        /// </summary>
        /// <param name="arrayCreator">Первый делегат</param>
        /// <param name="arrayShow">Второй делегат</param>
        private static void FirstTesting(SecondTaskDelegate.CreateArray arrayCreator, SecondTaskDelegate.ShowArray arrayShow)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            foreach (int el in arrayCreator(n))
            {
                Console.Write(el + " ");
            }
            Console.WriteLine();
            arrayShow(arrayCreator(n));
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(Environment.NewLine + "Если две верхние строчки одинаковы, первый проверка пройдена!");
            Console.ResetColor();
        }
    }
}
