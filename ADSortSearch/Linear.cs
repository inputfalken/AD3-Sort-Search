using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace ADSortSearch {
    public class Linear : SearchAndSortTest {
        public override TimeSpan Search(int repeats) {
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
        public Linear(IEnumerable<int>  enumerable) : base(enumerable) {}
    }
}