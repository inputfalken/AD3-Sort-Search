using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace ADSortSearch {
    public class Linear : Measurement {
        public override int[] Search(int repeats) {
            var keys = Enumerable.Range(0, repeats).Select(i => Random.Next(Ints.Length)).ToArray();
            Watch.Start();
                foreach (var key in keys) {
                    foreach (var number in Ints) {
                        if (number == key) {
                            break;
                        }
                    }
                }
            StopWatchResult = Watch.Elapsed;
            Watch.Reset();
            return keys;
        }

        public Linear(int length, bool sorted) : base(length, sorted) {}
        public Linear(IEnumerable<int> enumerable) : base(enumerable) {}
    }
}