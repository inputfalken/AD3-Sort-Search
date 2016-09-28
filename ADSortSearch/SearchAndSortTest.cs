using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace ADSortSearch {
    public abstract class SearchAndSortTest {
        protected SearchAndSortTest(int length, bool sorted) {
            Ints = sorted
                ? Enumerable.Range(0, length).ToArray()
                : Enumerable.Range(0, length).Select(i => Random.Next(length)).ToArray();
        }

        protected SearchAndSortTest(IEnumerable<int> enumerable) {
            Ints = enumerable.ToArray();
        }

        private const int Seed = 5;
        protected Random Random { get; } = new Random(Seed);
        protected int[] Ints { get; }
        public abstract int[] Search(int repeats);
        protected Stopwatch Watch { get; } = new Stopwatch();
        public TimeSpan StopWatchResult { get; protected set; }

        public int[] BubbleSort() {
            Watch.Start();
            for (var i = 0; i < Ints.Length - 1; i++) {
                for (var j = 0; j < Ints.Length - 1; j++) {
                    if (Ints[j] > Ints[j + 1]) {
                        var temp = Ints[j];
                        Ints[j] = Ints[j + 1];
                        Ints[j + 1] = temp;
                    }
                }
            }
            StopWatchResult = Watch.Elapsed;
            Watch.Reset();
            return Ints;
        }

        public static SearchAndSortTest CreateSearch(SearchAndSortTest searchAndSortTest) => searchAndSortTest;
    }
}