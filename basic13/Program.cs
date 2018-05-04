using System;

namespace basic13
{
    class Program
    {
        public static void to255() {
            for (int i = 1; i < 256; i++) {
                Console.WriteLine(i);
            }
        }

        public static void oddto255() {
            for (int i = 1; i < 256; i = i + 2) {
                Console.WriteLine(i);
            }
        }

        public static void printSum() {
            int sum = 0;
            for (int i = 0; i < 256; i++) {
                sum += i;
                Console.WriteLine("new number: " + i + " " + "sum: " + sum);
            }
        }

        public static void iterate() {
            
        }

        static void Main(string[] args)
        {
            // to255();
            // oddto255();
            // printSum();
        }
    }
}
