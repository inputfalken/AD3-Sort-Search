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
        /// <returns>The elapsed time for all attempts</returns>
        public override int[] Search(int repeats) {
            // Checks that the collection is ordered.
            if (!Ints.Zip(Ints.Skip(1), (a, b) => new {a, b}).All(p => p.a <= p.b))
                throw new Exception("Collection must be sorted");
            var arr = Enumerable.Range(0, repeats).Select(i => Random.Next(Ints.Length)).ToArray();
            Watch.Start();
            var lo = 0;
            var hi = Ints.Length - 1;
            foreach (var key in arr) {
                while (lo <= hi) {
                    var mid = lo + (hi - lo)/2;
                    if (key < Ints[mid]) hi = mid - 1;
                    else if (key > Ints[mid]) lo = mid + 1;
                    else break;
                }
            }
            StopWatchResult = Watch.Elapsed;
            Watch.Reset();
            return arr;
        }
    }
}