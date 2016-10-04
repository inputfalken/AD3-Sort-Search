using System.Collections.Generic;
using System.Diagnostics;

namespace ADSortSearch {
    class Bubble : Measurement {
        protected override int[] StartMeasurment(int repeats, Stopwatch watch) {
            watch.Start();
            for (var repeat = 0; repeat < repeats; repeat++) {
                for (var i = 0; i < Ints.Length - 1; i++) {
                    for (var j = 0; j < Ints.Length - 1; j++) {
                        if (Ints[j] > Ints[j + 1]) {
                            var temp = Ints[j];
                            Ints[j] = Ints[j + 1];
                            Ints[j + 1] = temp;
                        }
                    }
                }
            }
            return Ints;
        }


        public Bubble(int length, bool sorted) : base(length, sorted) {}
        public Bubble(IEnumerable<int> enumerable) : base(enumerable) {}
    }
}