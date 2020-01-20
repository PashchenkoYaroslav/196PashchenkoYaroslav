using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    static class StaticTempConverters
    {
        public static double CelsiusToKelvin(double x) => x + 273.15;
        public static double KelvinToCelsius(double x) => x - 273.15;
        public static double CelsiusToRankine(double x) => (x + 273.15) * 9 / 5;
        public static double RankineToCelsius(double x) => (x - 491.67) * 5 / 9;
        public static double CelsiusToRoemer(double x) => (x * 21 / 40 + 7.5);
        public static double RoemerToCelsius(double x) => (x - 7.5) * 40 / 21;
    }
    class TemperatureConverterImp
    {
        public double CelsiusToFahrenheit(double x) => Math.Round(x * 9 / 5 + 32, 1);
        public double FahrenheitToCelsius(double x) => Math.Round((x - 32) * 5 / 9, 1);
    }
    class Program
    {
        const double testCelsium = 36.6;
        const double testFahrenheit = 97.9;
        public delegate double delegateConvertTemperature(double x);
        /// <summary>
        /// Метод проверяет вводимое значение на соответствие условиям.
        /// </summary>
        /// <returns></returns>
        static double GetTemperature()
        {
            Console.ResetColor();
            Console.WriteLine("Введите значение температуры в Цельсиях:");
            double result;
            while (!double.TryParse(Console.ReadLine(), out result))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Введенные данные некорректны." +
                    "Пожалуйста, введите целочисленное число");
            }
            return result;
        }
        static void Main(string[] args)
        {
            Testing();
            #region repeatTask
            do
            {
                TemperatureConverterImp termometer = new TemperatureConverterImp();
                delegateConvertTemperature[] scaleTranslator = { termometer.CelsiusToFahrenheit,
                StaticTempConverters.CelsiusToKelvin,StaticTempConverters.CelsiusToRankine,
                StaticTempConverters.CelsiusToRoemer};
                CelsiusToEverything(scaleTranslator);
                Console.WriteLine("Нажмите Escape чтобы выйти" + Environment.NewLine
                   + "Нажмите на Enter чтобы продолжить");
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
            #endregion

        }
        /// <summary>
        /// Метод переводит введенное значение в заданные шкалы
        /// </summary>
        /// <param name="scaleTranslator"></param>
        private static void CelsiusToEverything(delegateConvertTemperature[] scaleTranslator)
        {
            double celsiumTemp = GetTemperature();
            string[] message = { "Фаренгейты", "Кельвины", "Ранкины", "Реомюры" };
            for (int i = 0; i < 4; i++)
            {
                Console.ResetColor();
                Console.WriteLine("Перевод из Цельсия в {0}:", message[i]);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("{0} примерно равно {1}", celsiumTemp, scaleTranslator[i](celsiumTemp));
            }
        }

        /// <summary>
        /// Метод сравнивает переведенныет градусы
        /// на соответствие правильным значениям.
        /// </summary>
        private static void Testing()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Начинаем тестирование!");
            Console.ResetColor();
            TemperatureConverterImp termometer = new TemperatureConverterImp();
            delegateConvertTemperature[] scaleTranslator =
                { termometer.CelsiusToFahrenheit, termometer.FahrenheitToCelsius };
            Console.WriteLine("Переведем из Цельсия в Фаренгейты и из Фаренгейтов в Цельсий");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("{0} по Цельсию примерно равен {1} по Фаренгейту",
                testCelsium, scaleTranslator[0](testCelsium));
            Console.WriteLine("{0} по Фаренгейту примерно равен {1} по Цельсию",
                testFahrenheit, scaleTranslator[1](testFahrenheit));
            if (Equals((scaleTranslator[0](testCelsium)), testFahrenheit) &&
                Equals(scaleTranslator[1](testFahrenheit), testCelsium))
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Тест пройден!");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Тест не пройден!");
            }
        }
    }
}
