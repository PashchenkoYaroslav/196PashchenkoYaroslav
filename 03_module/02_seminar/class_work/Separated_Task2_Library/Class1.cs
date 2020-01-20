using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Separated_Task2_Library
{
    /// <summary>
    /// Заданные методы
    /// </summary>
    public class Methods
    {
        //Можно было сделать через ToCharArray
        public static int[] CreateArray(int x)
        {
            string str = x.ToString();
            int[] arr = new int[str.Length];
            for (int i = 0; i < str.Length; i++)
            {
                int.TryParse(str[i].ToString(),out int res);
                arr[i] = res;
            }
            return arr;
        }
        public static void ShowArray(int[] x)
        {
            foreach (var el in x)
            {
                Console.Write(el+" ");
            }
        }
    }
}
