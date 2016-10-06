using System.Collections.Generic;
using System.Diagnostics;

namespace ADSortSearch {
    internal class HashSetContains : Measurement {
        public HashSetContains(ICollection<int> collection, bool sorted) : base(collection, sorted) {}

        protected override void Measure(int repeats, Stopwatch watch) {
            watch.Start();
            for (int i = 0; i < NumbersToFind.Length; i++) {
                Collection.Contains(NumbersToFind[i]);
            }
        }
    }
}