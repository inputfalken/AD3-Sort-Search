using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace ADSortSearch {
    internal class Contains : Measurement {
        public Contains(ICollection<int> collection, bool sorted = true) : base(collection, sorted) {}

        protected override void Measure(Stopwatch watch) {
            watch.Start();
            foreach (var randomNumber in RandomIntegers) {
                if (Collection.Contains(randomNumber))
                    break;
                throw new Exception("Could not find element");
            }
        }
    }
}