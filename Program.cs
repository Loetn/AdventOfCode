using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode
{
    class Program
    {
        static void Main(string[] args)
        {
            int day = 0;

            Console.WriteLine("Gimme number of exercise to execute... Press any non-number key to quit.");
            string input = Console.ReadLine();
            while (int.TryParse(input, out day))
            {
                Type type = Type.GetType("AdventOfCode.Day" + day);
                if (type != null)
                {
                    ISolveable s = (ISolveable)Activator.CreateInstance(type);
                    Console.WriteLine("Part 1: " + s.SolvePart1());
                    Console.WriteLine("Part 2: " + s.SolvePart2());
                }
                else
                {
                    Console.WriteLine("Exercise not found");
                }

                Console.WriteLine("----------------");
                input = Console.ReadLine();
            }
        }
    }
}
