using System.Collections.Generic;
using System.Diagnostics;

namespace ADSortSearch {
    internal class HashSetContains : Measurement {
        public HashSetContains(int length, bool sorted) : base(length, sorted) {}
        public HashSetContains(ICollection<int> collection, int length, bool sorted) : base(collection, length, sorted) {}

        protected override void Measure(int repeats, Stopwatch watch) {
            watch.Start();
            for (int i = 0; i < NumbersToFind.Length; i++) {
                Collection.Contains(NumbersToFind[i]);
            }
        }
    }
}