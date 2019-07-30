using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SummartiveSums
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array1 = new int[] { 1, 90, -33, -55, 67, -16, 28, -55, 15 };
            int[] array2 = new int[] { 999, -60, -77, 14, 160, 301 };
            int[] array3 = new int[] { 10, 20, 30, 40, 50, 60, 70, 80, 90, 100, 110, 120, 130, 140, 150, 160, 170, 180, 190, 200, -99 };

           Console.WriteLine($"#1 Array Sum: {SumArray(array1)}");
           Console.WriteLine($"#2 Array Sum: {SumArray(array2)}");
           Console.WriteLine($"#3 Array Sum: {SumArray(array3)}");

            Console.ReadLine();
            

        }

        public static int SumArray(int [] Array)
        {
            int sum = 0;
            foreach (int element in Array)
                sum += element;
            return sum;


        }
    }
}
