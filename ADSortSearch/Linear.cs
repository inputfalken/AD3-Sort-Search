using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace ADSortSearch {
    public class Linear : Measurement {
        public Linear(ICollection<int> collection, bool sorted = true) : base(collection, sorted) {}


        protected override void Measure(Stopwatch watch) {
            watch.Start();
            foreach (var randomNumber in RandomIntegers)
                LinearSearch(randomNumber, Collection.ToArray());
        }

        private static int LinearSearch(int key, IEnumerable<int> list) {
            foreach (var t in list)
                if (key == t) return key;
            throw new Exception("Could not find an element.");
        }
    }
}