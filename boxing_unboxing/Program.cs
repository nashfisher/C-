using System;
using System.Collections.Generic;

namespace boxing_unboxing
{
    class Program
    {
        static void Main(string[] args)
        {
            List<object> newlist = new List<object>();

            newlist.Add(7);
            newlist.Add(28);
            newlist.Add(-1);
            newlist.Add(true);
            newlist.Add("chair");

            int sum = 0;

            for (int i = 0; i < newlist.Count; i++) {
                // if (newlist[i] is int) {
                //     Console.WriteLine(newlist[i]);
                // }
                // if (newlist[i] is bool) {
                //     Console.WriteLine(newlist[i]);
                // }
                if (newlist[i] is string) {
                    Console.WriteLine(newlist[i] as string);
                }
                else if (newlist[i] is int) {
                    sum += (int)newlist[i];
                }
                else if (newlist[i] is bool) {
                    Console.WriteLine(newlist[i]);
                }
            }
            Console.WriteLine(sum);

        }
    }
}
