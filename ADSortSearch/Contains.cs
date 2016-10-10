using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace ADSortSearch {
    internal class Contains : Measurement {
        public Contains(ICollection<int> collection, bool sorted = true) : base(collection, sorted) {}

        protected override void Measure(Stopwatch watch) {
            watch.Start();
            foreach (int t in RandomIntegers) {
                if (!Collection.Contains(t)) throw new Exception("Could not find element");
            }
        }
    }
}