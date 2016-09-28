using System;
using System.Diagnostics;

namespace ADSortSearch {
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