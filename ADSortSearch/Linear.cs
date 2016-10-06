using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace ADSortSearch {
    public class Linear : Measurement {
        protected override void Measure(int repeats, Stopwatch watch) {
            IntArr = Collection.ToArray();
            watch.Start();
            for (int i = 0; i < NumbersToFind.Length; i++) {
                LinearSearch(NumbersToFind[i]);
            }
        }

        private int LinearSearch(int key) {
            for (var i = 0; i < IntArr.Length; i++) {
                if (key == IntArr[i]) {
                    return key;
                }
            }
            throw new Exception("Could not find an element.");
        }

        private int[] IntArr { get; set; }


        public Linear(ICollection<int> collection, bool sorted) : base(collection, sorted) {}
    }
}