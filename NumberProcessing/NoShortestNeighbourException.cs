using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyConsoleApp.NumberProcessing
{
    public class NoShortestNeighbourException: Exception
    {
        public int[] NumberCollection { get; set; }

        public NoShortestNeighbourException(int[] numbers) : base("no shortest neighbour found")
        {
            this.NumberCollection = numbers;
        }

        public override string ToString()
        {
            return String.Format("no shortest neighbour found in {0}", this.NumberCollection);
        }
    }
}
