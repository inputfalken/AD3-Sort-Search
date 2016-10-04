using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace ADSortSearch {
    public class Linear : Measurement {
        protected override void Measure(int repeats, Stopwatch watch) {
            watch.Start();
            foreach (var number in NumbersToFind) {
                LinearSearch(number);
            }
        }

        private int LinearSearch(int key) {
            foreach (var number in Ints) {
                if (number == key) {
                    return key;
                }
            }
            return -1;
        }

        public Linear(int length, bool sorted) : base(length, sorted) {}
        public Linear(IEnumerable<int> enumerable) : base(enumerable) {}
    }
}