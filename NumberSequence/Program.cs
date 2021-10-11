﻿using System;
using System.Linq;

namespace NumberSequence
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var generator = new NumberSequenceGenerator();

                if (args.Any())
                {
                    Console.WriteLine($"Output: { generator.FirstLongestIncreasingSequence(args.ToString())}");
                }
                else
                {
                    Console.WriteLine("Please enter single white space separated numbers string:");
                    while (true)
                    {
                        var input = Console.ReadLine();
                        var output = generator.FirstLongestIncreasingSequence(input);
                        Console.WriteLine($"Output: { output }");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: { ex.Message }");
            }
            Console.Read();
        }
    }
}
