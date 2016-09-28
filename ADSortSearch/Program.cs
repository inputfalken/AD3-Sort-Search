using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using static System.Linq.Enumerable;

namespace ADSortSearch {
    internal static class Program {
        private static void Main(string[] args) {}

        private static Search CreateSearch(Search search) => search;
    }

    internal abstract class Search {
        protected Search(int length, bool sorted) {
            Ints = sorted ? Range(0, length).ToArray() : Range(0, length).Select(i => 2).ToArray();
        }

        private const int Seed = 5;
        protected Random Random { get; } = new Random(Seed);
        protected int[] Ints { get; }
        public abstract TimeSpan Sort(int repeats);

        public TimeSpan BubbleSort() {
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

    internal class Linear : Search {
        public override TimeSpan Sort(int repeats) {
            var startNew = Stopwatch.StartNew();
            for (var i = 0; i < repeats; i++) {
                var next = Random.Next(Ints.Length);
                foreach (var number in Ints) {
                    if (number == next) {
                        startNew.Stop();
                        break;
                    }
                }
            }
            return startNew.Elapsed;
        }

        public Linear(int length, bool sorted) : base(length, sorted) {}
    }
}