using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace ADSortSearch {
    public class Binary : Measurement {
        public Binary(ICollection<int> collection, bool sorted) : base(collection, sorted) {}


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
            IntArray = Collection.ToArray();
            if (!Collection.Zip(Collection.Skip(1), (a, b) => new {a, b}).All(p => p.a <= p.b))
                throw new Exception("Collection must be sorted");
            watch.Start();
            for (var i = 0; i < NumbersToFind.Length; i++) {
                BinarySearch(NumbersToFind[i]);
            }
        }

        private int[] IntArray { get; set; }

        private int BinarySearch(int key) {
            var lo = 0;
            var hi = Collection.Count - 1;
            while (lo <= hi) {
                var mid = lo + (hi - lo)/2;
                if (key < IntArray[mid]) hi = mid - 1;
                else if (key > IntArray[mid]) lo = mid + 1;
                else return mid;
            }
            throw new Exception("No Result found");
        }
    }
}