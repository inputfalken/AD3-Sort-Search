using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace ADSortSearch {
    public class Binary : Measurement {
        public Binary(int length, bool sorted) : base(length, sorted) {}
        public Binary(IEnumerable<int> enumerable) : base(enumerable) {}


        /// <summary>
        ///     First checks if collection is sorted, if not it will throw an exception.
        ///     Then it perform a for loop up till repeats arg. 
        ///     Each iteration in the for loop will perform a binary search.
        /// </summary>
        /// <param name="repeats"></param>
        /// <param name="watch"></param>
        /// <returns>The elapsed time for all attempts</returns>
        protected override void Measure(int repeats, Stopwatch watch) {
            // Checks that the collection is ordered.
            if (!Ints.Zip(Ints.Skip(1), (a, b) => new {a, b}).All(p => p.a <= p.b))
                throw new Exception("Collection must be sorted");
            watch.Start();
            foreach (var number in NumbersToFind) {
                BinarySearch(number);
            }
        }

        private int BinarySearch(int key) {
            var lo = 0;
            var hi = Ints.Length - 1;
            while (lo <= hi) {
                var mid = lo + (hi - lo)/2;
                if (key < Ints[mid]) hi = mid - 1;
                else if (key > Ints[mid]) lo = mid + 1;
                else return mid;
            }
            throw new Exception("No Result found");
        }
    }
}