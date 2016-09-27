using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using static System.Linq.Enumerable;

namespace ADSortSearch {
    internal static class Program {
        private static void Main(string[] args) {
            var collectionSort = new CollectionSort((int) Math.Pow(5, 10));

            //collectionSort.PerformBinarySearch(20);

            Console.WriteLine(collectionSort.PerformBinarySearch(10));
            Console.WriteLine(collectionSort.PerformLinearSearch(10));
        }
    }

    internal class CollectionSort {
        private int[] Ints { get; }
        private Random Random { get; }

        private const int DefaultSeedValue = -1;

        public CollectionSort(int length, int seed = DefaultSeedValue, bool ordered = true) {
            Random = SetRandom(seed);
            Ints = ordered
                ? Range(0, length).ToArray()
                : Range(0, length).Select(i => Random.Next(length)).ToArray();
        }

        public CollectionSort(IEnumerable<int> collection, int seed = DefaultSeedValue) {
            Ints = collection.ToArray();
            Random = SetRandom(seed);
        }

        private static Random SetRandom(int seed = -1) => seed == DefaultSeedValue ? new Random() : new Random(seed);

        /// <summary>
        ///     First checks if collection is sorted, if not it will throw an exception.
        ///     Then it perform a for loop up till repeats arg. 
        ///     Each iteration in the for loop will perform a binary search.
        /// </summary>
        /// <param name="repeats"></param>
        /// <returns>The elapsed time for all attempts</returns>
        public TimeSpan PerformBinarySearch(int repeats) {
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

        public TimeSpan PerformLinearSearch(int repeats) {
            var startNew = Stopwatch.StartNew();
            for (var i = 0; i < repeats; i++) {
                var next = Random.Next(Ints.Length);
                if (Ints.Any(number => number == next))
                    startNew.Stop();
            }
            return startNew.Elapsed;
        }

        public TimeSpan PerformBubbleSort() {
            var next = 0;
            var startNew = Stopwatch.StartNew();
            for (var i = 0; i < Ints.Length; i++) {
                for (var j = 0; j < Ints.Length; j++) {
                    var current = Ints[j];
                    if (j != Ints.Length)
                        next = Ints[j];
                    if (current <= next) continue;
                    Ints[current] = next;
                    Ints[next] = current;
                }
            }

            startNew.Stop();
            return startNew.Elapsed;
        }
    }
}