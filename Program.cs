using System;
using System.Collections.Generic;

namespace BadNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> badNumbers = new List<int>();

            int listSize;

            Console.WriteLine("Enter Size of Bad Numbers:");

            listSize = Int32.Parse(Console.ReadLine());

            Console.WriteLine("Enter the Bad Numbers: \n");

            for(int i = 0; i< listSize; i++)
            {
                badNumbers.Add(Int32.Parse(Console.ReadLine()));
            }

            Console.WriteLine("Enter upper limit");

            int upper = Int32.Parse(Console.ReadLine());

            Console.WriteLine("Enter lower limit");

            int lower = Int32.Parse(Console.ReadLine());

            Console.WriteLine("The longest is: ");

            Console.WriteLine(GoodSegment(badNumbers, upper, lower));          
        }

        public static int GoodSegment(List<int> badNumbers, int upper, int lower)
        {
            int longest = 0;
            int low = lower, up;
            int tmp;

            for (int i = 0; i<badNumbers.Count; i++)
            {
                for(int j = 0; j<badNumbers.Count - 1; j++)
                {
                    if(badNumbers[j] > badNumbers[j + 1])
                    {
                        tmp = badNumbers[j];
                        badNumbers[j] = badNumbers[j + 1];
                        badNumbers[j + 1] = tmp;
                    }
                }
            }

            bool move = false;
            up = lower;
            int k = 0;
            while (up <= upper)
            {
               if(badNumbers[k] == up)
                {
                    longest = (up - 1) - lower;
                    move = true;
                    lower = up;
                }

                if(move)
                {
                    k++;
                    move = false;
                }

                up++;
            }

            return longest;
        }
    }
}
