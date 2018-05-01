using System;

namespace fundamentals1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            // Print 1-255
            for (int i = 1; i <= 255; i++) {
                Console.WriteLine(i);
            }

            // Print multiples of 3 and 5 from 1-100 with modulus
            for (int i = 1; i <= 100; i++) {
                if (i % 3 == 0 && i % 5 == 0) {
                    Console.WriteLine("FizzBuzz");
                }

                else if (i % 3 == 0) {
                    Console.WriteLine("Fizz");
                }

                else if (i % 5 == 0) {
                    Console.WriteLine("Buzz");
                }
            }

            // Modulus without modulus
            int i = 1;
            while (i <= 100) {
                // like this
                if (i/15 == i/15.0) {
                    Console.WriteLine("FizzBuzz");
                    i = i + 1;
                }
                // or this
                if (i/3 == (double)i/3) {
                    Console.WriteLine("Fizz");
                    i = i + 1;
                }
                if (i/5 == (double)i/5) {
                    Console.WriteLine("Buzz");
                    i = i + 1;
                }
                Console.WriteLine(i);
                i = i + 1;
            }

            // Generate 10 random 'FizzBuzz' values
            Random rand = new Random();
            int x = 1;
            while (x <= 10) {
                int word = rand.Next(1,100);
                if (word % 15 == 0) {
                    Console.WriteLine("FizzBuzz");
                    x++;
                }
                else if (word % 5 == 0) {
                    Console.WriteLine("Buzz");
                    x++;
                }
                else if (word % 3 == 0) {
                    Console.WriteLine("Fizz");
                    x++;
                }              
                Console.WriteLine(word);
                x++;
            }

        }
    }
}
