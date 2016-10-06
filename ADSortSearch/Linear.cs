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
            foreach (var number in Collection) {
                if (number == key) {
                    return key;
                }
            }
            throw new Exception("Could not find an element.");
        }

        public Linear(int length, bool sorted) : base(length, sorted) {}
        public Linear(ICollection<int> collection, int lenght, bool sorted) : base(collection, lenght, sorted) {}
    }
}