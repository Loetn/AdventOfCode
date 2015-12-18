using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode
{
    public class Day2 : ISolveable
    {
        IEnumerable<string> input = File.ReadAllLines("Input/DayTwo.txt");

        public string SolvePart1()
        {
            /* Old version
            int paper = 0;
            foreach (string line in input)
            {
                var dimensions = line.Split('x').ToList().ConvertAll(x => int.Parse(x)).ToList();
                int lw = dimensions[0] * dimensions[1];
                int wh = dimensions[1] * dimensions[2];
                int hl = dimensions[2] * dimensions[0];
                paper += 2 * lw + 2 * wh + 2 * hl;
                // slack
                paper += new int[] { lw, wh, hl }.Min();
            }

            Console.WriteLine("2.1: {0} m²", paper);*/
            return input.Select(x => x.Split('x').Select(y => int.Parse(y)).ToList())
                                                 .Select(x => new int[]
                                                 {
                                                     x[0] * x[1], // lenght * width
                                                     x[1] * x[2], // width * height
                                                     x[2] * x[0]  // height * leingt
                                                 })
                                                 .Select(x => 2 * x[0] + 2 * x[1] + 2 * x[2] + x.Min()).Sum().ToString();
        }

        public string SolvePart2()
        {
            /* Old version
            var paper = 0;
            foreach (string line in input)
            {
                var dimensions = line.Split('x').ToList().ConvertAll(x => int.Parse(x)).OrderBy(x => x).ToList();
                paper += dimensions[0] + dimensions[0] + dimensions[1] + dimensions[1];
                // ribbon
               paper += dimensions[0] * dimensions[1] * dimensions[2];
            }

            Console.WriteLine("2.2: {0} m²", paper);*/

            return input.Select(x => x.Split('x').Select(y => int.Parse(y)).OrderBy(y => y).ToList())
                                                 .Select(x =>
                                                 {
                                                     return x[0] + x[0] + x[1] + x[1] + x[0] * x[1] * x[2];
                                                 }).Sum().ToString();
        }
    }
}
