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
            var ints = new List<int>().BinarySearch(2);

            Console.WriteLine(collectionSort.PerformBinarySearch(10));
            Console.WriteLine(collectionSort.PerformLinearSearch(10));
        }
    }

    internal class CollectionSort {
        private int[] Ints { get; }
        private Random Random { get; } = new Random();

        public CollectionSort(int length) {
            Ints = Range(0, length).ToArray();
        }

        public TimeSpan PerformBinarySearch(int repeats) {
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
    }
}