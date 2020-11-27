using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace DistinctYear.Tools
{
    public class Generate
    {
        public int[] GenerateRandomExamples(int numberOfExaples, out long executionTime)
        {
            Stopwatch watch = new Stopwatch();
            Random random = new Random();
            int[] examples = new int[numberOfExaples];

            //check if the watch is running
            if (watch.IsRunning)
            {
                watch.Restart();
            }
            else
            {
                watch.Start();
            }

            //Generate examples
            for (int i = 0; i < numberOfExaples; i++)
            {
                examples[i] = random.Next(1000, 9800);
            }
            watch.Stop();
            executionTime = watch.ElapsedMilliseconds;

            return examples;
        }
    }
}
