using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogGenetics
{
    class Program
    {
        static void Main(string[] args)
        {
            int number1 = 0;
            int number2 = 0;
            int number3 = 0;
            int number4 = 0;
            int number5 = 0;
            int temp1;
            int temp2;
            int temp3;
            int temp4;
            string dogName;
            Random rnd = new Random();

            number1 = rnd.Next(1, 101);
            temp1 = (100 - number1);
            number2 = rnd.Next(1, temp1 + 1);
            temp2 = (100 - (number1 + number2));
            number3 = rnd.Next(1, temp2 + 1);
            temp3 = (100 - (number1 + number2 + number3));
            number4 = rnd.Next(1, temp3 + 1);
            temp4 = (100 - (number1 + number2 + number3 + number4));
            number5 = rnd.Next(1, temp4 + 1);

            Console.WriteLine("What is your dog's name? ");
            dogName = Console.ReadLine();

            Console.WriteLine($"Well then, I have this highly reliable report on {dogName}'s prestigious background right here. ");
            Console.Write(Environment.NewLine);

            Console.WriteLine($"{dogName} is: ");

            Console.Write(Environment.NewLine);

            Console.WriteLine($"{number1}% St. Bernard");
            Console.WriteLine($"{number2}% Chihuahua");
            Console.WriteLine($"{number3}% Dramamtic Red Nosed Asian Pug");
            Console.WriteLine($"{number4}% Common Cur");
            Console.WriteLine($"{number5}% King Doberman");

            Console.Write(Environment.NewLine);

            Console.WriteLine("Wow, that's QUITE the dog!");
            Console.ReadLine();
        }
    }
}
