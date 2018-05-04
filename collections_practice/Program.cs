using System;
using System.Collections.Generic;

namespace collections_practice
{
    class Program
    {
        static void Main(string[] args)
        {
            // Console.WriteLine("Hello World!");

            // create array to hold values 0-9
            int[] arr = new int[10];
            for (int i = 0; i <= 9; i++) {
                arr[i] = i;
                Console.WriteLine(arr[i]);
            }
            string[] arrNames = {"Tim", "Martin", "Nikki", "Sara"};
            // for (int i = 0; i < arrNames.Length; i++) {
            //     Console.WriteLine(arrNames[i]);
            // }
            bool[] arrBoo = new bool[10];
            for (int i = 0; i < arrBoo.Length; i++) {
                if (i % 2 == 0) {
                    arrBoo[i] = true;
                    Console.WriteLine(arrBoo[i]);
                }
                else {
                    arrBoo[i] = false;
                    Console.WriteLine(arrBoo[i]);
                }
            }

            // Create a multiplication table
            int[,] multiTable = new int[10,10];
            for (int y = 0; y <= 9; y++) {
                for (int x = 0; x <= 9; x++) {
                    if (y == 0) {
                        multiTable[0,x] = x+1;
                        Console.WriteLine(y);
                    }
                    else if (x == 0) {
                        multiTable[y,0] = y+1;
                    }
                    else {
                        multiTable[y,x] = (y+1)*(x+1);
                    }
                }
            }

            // Store ice cream flavors in a list
            List<string> ice_cream = new List<string>();
            ice_cream.Add("chocolate");
            ice_cream.Add("sdfas");
            ice_cream.Add("slksdfp");
            ice_cream.Add("she at least pretended to appreciate it");

            // Console.WriteLine(ice_cream.Count);
            // Console.WriteLine(ice_cream[2]);
            // ice_cream.RemoveAt(2);

            // dictionary for User Info
            Dictionary<string,string> user = new Dictionary<string,string>();

            int j = 0;
            while (j < 4) {
                user.Add(arrNames[j], null);
                j++;
            }
            

            Random rand = new Random();

            for (var i = 0; i < arrNames.Length; i++){
                user[arrNames[i]] = ice_cream[rand.Next(0,3)];
            }       

            foreach (var person in user) {
                Console.WriteLine(person.Key + " likes " + person.Value);
            }
        }
    }
}
