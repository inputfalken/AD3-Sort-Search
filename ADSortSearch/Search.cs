using System;
using System.Diagnostics;
using System.Linq;

namespace ADSortSearch {
    internal abstract class Search {
        protected Search(int length, bool sorted) {
            Ints = sorted ? Enumerable.Range(0, length).ToArray() : Enumerable.Range(0, length).Select(i => Random.Next(length)).ToArray();
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
}