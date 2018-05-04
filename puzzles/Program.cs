using System;
using System.Collections.Generic;

namespace puzzles
{
    class Program
    {

        public static int[] randomArray() {
            Random rand = new Random();
            int[] arr = new int[10];
            int min = 0;
            int max = 0;
            int sum = 0;
            for (int i = 0; i < arr.Length; i++) {
                arr[i] = rand.Next(5,25);
                if (arr[i] < min || i == 0) {
                    min = arr[i];
                }
                if (arr[i] > max) {
                    max = arr[i];
                }
                sum += arr[i];
            }
            // for (int i = 0; i < arr.Length; i++) {
            //     if (arr[i] < )
            // }
            Console.WriteLine("minimum: " + min);
            Console.WriteLine("maximum: " + max);
            Console.WriteLine("sum: " + sum);

            return arr;
        }

        public static string TossCoin() {
            string toss = "";
            Random rand = new Random();
            int result = rand.Next(0,2);
            int heads = 0;
            if (result == 0) {
                toss = "tails";
                // Console.WriteLine(result);
            }
            else {
                toss = "heads";
                heads++;
                // Console.WriteLine(result);
            }
            Console.WriteLine("tossing a coin.");
            Console.WriteLine(toss);

            return toss;
        }

        public static double TossMultipleCoins(int num) {
            double heads = 0;
            double tosses = num;
            while (num > 0) {
                if (TossCoin() == "heads") {
                    heads++;
                }
                num--;
            }
            double ratio = heads/tosses;
            Console.WriteLine(ratio*100 + "% heads");
            return ratio;
        }

        public static string[] Names() {
            string[] names = {"Todd", "Tiffany", "Charlie", "Geneva", "Sydney"};
            List<string> name5 = new List<string>();
            Random rand = new Random();
            for (int i = 0; i < names.Length; i++) {
                int randIndex = rand.Next(0,5);
                string temp = names[i];
                names[i] = names[randIndex];
                names[randIndex] = temp;
            }
            for (int i = 0; i < names.Length; i++) {
                if (names[i].Length > 5) {
                    name5.Add(names[i]);
                }
            }
        
            names = name5.ToArray();
            return names;
        }

        static void Main(string[] args)
        {
            // int[] arr = randomArray();
            // string coinflip = TossCoin();
            // TossMultipleCoins(10);
            string[] names = Names();
        }
    }
}
