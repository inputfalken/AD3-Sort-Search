using System;
using System.Diagnostics;
using System.Linq;

namespace ADSortSearch {
    internal class Binary : Search {
        public Binary(int length, bool sorted) : base(length, sorted) {}


        /// <summary>
        ///     First checks if collection is sorted, if not it will throw an exception.
        ///     Then it perform a for loop up till repeats arg. 
        ///     Each iteration in the for loop will perform a binary search.
        /// </summary>
        /// <param name="repeats"></param>
        /// <returns>The elapsed time for all attempts</returns>
        public override TimeSpan Sort(int repeats) {
            // Checks that the collection is ordered.
            if (!Ints.Zip(Ints.Skip(1), (a, b) => new {a, b}).All(p => p.a < p.b))
                throw new Exception("Collection must be sorted");
            var startNew = Stopwatch.StartNew();
            for (var i = 0; i < repeats; i++) {
                var lo = 0;
                var hi = Ints.Length - 1;
                var key = Random.Next(Ints.Length);
                while (lo <= hi) {
                    var mid = lo + (hi - lo)/2;
                    if (key < Ints[mid]) hi = mid - 1;
                    else if (key > Ints[mid]) lo = mid + 1;
                    else break;
                }
            }
            return startNew.Elapsed;
        }
    }
}