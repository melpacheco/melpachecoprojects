using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyHearts
{
    class Program
    {
        static void Main(string[] args)
        {
            string input;
            int age;
            int heartRate;
            int targetRangeLower;
            int targetRangeHigher;

            Console.Write("What is your age? ");
            input = Console.ReadLine();
            int.TryParse(input, out age);
            heartRate = 220 - age;
            Console.WriteLine($"Your maximum heart rate should be {heartRate} beats per minute.");

            Console.Write(Environment.NewLine);

            targetRangeLower = Convert.ToInt32(heartRate * .50);
            targetRangeHigher = Convert.ToInt32(heartRate * .85);

            Console.WriteLine($"Your target HR Zone is {targetRangeLower} - {targetRangeHigher} beats per minute.");
            Console.ReadLine();

          
            
        }
    }
}
