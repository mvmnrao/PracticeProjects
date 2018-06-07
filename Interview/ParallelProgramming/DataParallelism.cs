using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParallelProgramming
{
    public class DataParallelism
    {
        private int total = 0;

        public int Total
        {
            get
            {
                return total;
            }
            set
            {
                total = value;
            }
        }

        public int ReturnRandomNumber(int minValue, int maxValue)
        {
            Random random = new Random();
            int randomNum = random.Next(minValue, maxValue);

            total += randomNum;

            Console.WriteLine($"Min Value: {minValue}; Max Value: {maxValue}; Random Number: {randomNum}");

            return randomNum;
        }
    }
}
