using System.Collections.Generic;

namespace ADSortSearch {
    class Bubble : Measurement {
        public override int[] Measure(int repeats) {
            Watch.Start();
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
            StopWatchResult = Watch.Elapsed;
            Watch.Reset();
            return Ints;
        }


        public Bubble(int length, bool sorted) : base(length, sorted) {}
        public Bubble(IEnumerable<int> enumerable) : base(enumerable) {}
    }
}