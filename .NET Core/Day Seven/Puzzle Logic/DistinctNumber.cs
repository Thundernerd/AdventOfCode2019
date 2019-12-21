using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace TNRD.AdventOfCode.DaySeven.Shared
{
    public class DistinctNumber : IEnumerable<int>, IEnumerator<int>
    {
        private readonly int min;
        private readonly int max;
        private readonly int digits;
        private readonly int length;

        private int current;

        public int Current => current;
        object IEnumerator.Current => Current;

        public DistinctNumber(int min, int max, int digits)
        {
            this.min = min;
            this.max = max;
            this.digits = digits;

            length = max;
            for (int i = 0; i < digits - 1; i++)
            {
                length = length * 10 + max;
            }

            for (int i = 0; i < digits; i++)
            {
                current = current * 10 + min;
            }
        }

        public bool MoveNext()
        {
            while (current < length)
            {
                ++current;
                bool distinct = current.ToString($"D{digits}").Distinct().Count() == digits;
                if (!distinct)
                    continue;

                if (!GetDigits(current).All(x => x >= min && x <= max))
                    continue;

                break;
            }

            return current < length;
        }

        public void Reset()
        {
            current = min;
        }

        public void Dispose()
        {
        }

        IEnumerator<int> IEnumerable<int>.GetEnumerator()
        {
            return this;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this;
        }

        // https://stackoverflow.com/a/45508660/2112835
        private static IEnumerable<int> GetDigits(int source)
        {
            int individualFactor = 0;
            int tennerFactor = Convert.ToInt32(Math.Pow(10, source.ToString().Length));
            do
            {
                source -= tennerFactor * individualFactor;
                tennerFactor /= 10;
                individualFactor = source / tennerFactor;

                yield return individualFactor;
            } while (tennerFactor > 1);
        }
    }
}
