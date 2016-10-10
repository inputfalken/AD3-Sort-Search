using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace ADSortSearch {
    internal class Contains : Measurement {
        public Contains(ICollection<int> collection, bool sorted = true) : base(collection, sorted) {}

        protected override void Measure(Stopwatch watch) {
            watch.Start();
            for (var i = 0; i < RandomIntegers.Count; i++) {
                if (!Collection.Contains(RandomIntegers[i])) throw new Exception("Could not find element");
            }
        }
    }
}