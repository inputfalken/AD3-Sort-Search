using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace ADSortSearch {
    internal class Bubble : Measurement {
        protected override void Measure(int repeats, Stopwatch watch) {
            watch.Start();
            var res = BubbleSort(repeats);
        }

        private int[] IntArr { get; }

        private IEnumerable<int> BubbleSort(int repeats) {
            for (var repeat = 0; repeat < repeats; repeat++) {
                for (var i = 0; i < IntArr.Length - 1; i++) {
                    for (var j = 0; j < IntArr.Length - 1; j++) {
                        if (IntArr[j] > IntArr[j + 1]) {
                            var temp = IntArr[j];
                            IntArr[j] = IntArr[j + 1];
                            IntArr[j + 1] = temp;
                        }
                    }
                }
            }
            return Collection;
        }


        public Bubble(int length, bool sorted) : base(length, sorted) {
            IntArr = Collection.ToArray();
        }

        public Bubble(ICollection<int> collection, int length, bool sorted) : base(collection, length, sorted) {
            IntArr = Collection.ToArray();
        }
    }
}