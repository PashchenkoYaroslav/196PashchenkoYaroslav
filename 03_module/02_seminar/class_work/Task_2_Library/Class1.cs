using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_2_Library
{
    /// <summary>
    /// Заданные делегаты
    /// </summary>
    public static class SecondTaskDelegate
    {
        public delegate int[] CreateArray(int x);
        public delegate void ShowArray(int[] arr);
    }
}
