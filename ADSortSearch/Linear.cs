using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace ADSortSearch {
    public class Linear : Measurement {
        public Linear(ICollection<int> collection, bool sorted) : base(collection, sorted) {}

        private int[] IntArr { get; set; }

        protected override void Measure(Stopwatch watch) {
            IntArr = Collection.ToArray();
            watch.Start();
            for (var i = 0; i < NumbersToFind.Length; i++) LinearSearch(NumbersToFind[i]);
        }

        private int LinearSearch(int key) {
            for (var i = 0; i < IntArr.Length; i++) if (key == IntArr[i]) return key;
            throw new Exception("Could not find an element.");
        }
    }
}