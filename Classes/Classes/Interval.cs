using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public struct Interval
    {
        private int min;
        private int max;

        private static Random random = new Random();

        public Interval(int minValue, int maxValue)
        {
            if (minValue < 0)
            {
                minValue = 0;
                Console.WriteLine("Incorrect input data: minValue was set to 0.");
            }
            if (maxValue < 0)
            {
                maxValue = 0;
                Console.WriteLine("Incorrect input data: maxValue was set to 0.");
            }
            if (minValue < maxValue)
            {
                Console.WriteLine("Invalid input data: minValue is greater than maxValue. The values have been reversed");
                (minValue, maxValue) = (maxValue, minValue);
            }
            if (minValue == maxValue)
            {
                maxValue += 10;
                Console.WriteLine("Incorrect input data: minValue is equal to maxValue. maxValue has been increased by 10.");
            }
            min = minValue;
            max = maxValue;
        }

        public int Min => min;
        public int Max => max;

        public double Get()
        {
            return min + (random.NextDouble() * (max - min));
        }
    }
}