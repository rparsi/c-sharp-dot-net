using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyConsoleApp.NumberProcessing
{
    public class NumberElement: Object
    {
        public int Number { get; set; }
        public int Index { get; set; }

        public NumberElement(int number, int index)
        {
            this.Number = number;
            this.Index = index;
        }
    }

    public class FindShortestNeighboursResult: Object
    {
        public NumberElement[] Numbers { get; set; }
        public bool Found { get; set; }

        public FindShortestNeighboursResult(bool found, NumberElement[] numbers = null)
        {
            this.Numbers = numbers;
            this.Found = found;
        }
    }

    public class ShortestNeighbourProcessor
    {
        public int[] NumberCollection { get; set; }

        public ShortestNeighbourProcessor(int[] numbers)
        {
            this.NumberCollection = numbers;
        }

        public FindShortestNeighboursResult FindShortestNeighbours()
        {
            FindShortestNeighboursResult result = new FindShortestNeighboursResult(false);

            if (this.NumberCollection.Length <= 1)
            {
                if (this.NumberCollection.Length == 1)
                {
                    result.Numbers = new NumberElement[] { new NumberElement(this.NumberCollection[0], 0) };
                    result.Found = true;
                }
                return result;
            }

            List<NumberElement> shortest = new List<NumberElement>();
            for (int i = 0; i < this.NumberCollection.Length; i++)
            {
                int previousIndex = this.GetPreviousIndex(i);
                int nextIndex = this.GetNextIndex(i);

                bool isLessThanPrevious = this.NumberCollection[i] < this.NumberCollection[previousIndex];
                bool isLessThanNext = this.NumberCollection[i] < this.NumberCollection[nextIndex];

                if (isLessThanPrevious && isLessThanNext)
                {
                    shortest.Add(new NumberElement(this.NumberCollection[i], i));
                    result.Found = true;
                }
            }

            if (!result.Found)
            {
                throw new NoShortestNeighbourException(this.NumberCollection);
            }

            result.Numbers = shortest.ToArray();

            return result;
        }

        public int GetPreviousIndex(int index)
        {
            if (index <= 0)
            {
                return 0;
            }
            return index - 1;
        }

        public int GetNextIndex(int index)
        {
            if (index >= this.NumberCollection.Length - 1)
            {
                return this.NumberCollection.Length - 1;
            }
            return index + 1;
        }
    }
}
