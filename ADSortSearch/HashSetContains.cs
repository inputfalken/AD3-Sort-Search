using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace ADSortSearch {
    internal class HashSetContains : Measurement {
        public HashSetContains(ICollection<int> collection, bool sorted) : base(collection, sorted) {}

        protected override void Measure(Stopwatch watch) {
            watch.Start();
            for (var i = 0; i < NumbersToFind.Length; i++) {
                if (!Collection.Contains(NumbersToFind[i])) throw new Exception("Could not find element");
            }
        }
    }
}