using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace ADSortSearch {
    public class Linear : Measurement {
        public Linear(ICollection<int> collection, bool sorted = true) : base(collection, sorted) {}


        protected override void Measure(Stopwatch watch) {
            watch.Start();
            for (var i = 0; i < RandomIntegers.Count; i++) LinearSearch(RandomIntegers[i], Collection.ToArray());
        }

        private static int LinearSearch(int key, IList<int> list) {
            for (var i = 0; i < list.Count; i++) if (key == list[i]) return key;
            throw new Exception("Could not find an element.");
        }
    }
}