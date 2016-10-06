using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace ADSortSearch {
    internal class Bubble : Measurement {
        protected override void Measure(Stopwatch watch) {
            IntArr = Collection.ToArray();
            watch.Start();
            var res = BubbleSort();
        }

        private int[] IntArr { get; set; }

        private IEnumerable<int> BubbleSort() {
            var stillGoing = true;
            while (stillGoing) {
                stillGoing = false;
                for (var i = 0; i < IntArr.Length - 1; i++) {
                    var x = IntArr[i];
                    var y = IntArr[i + 1];
                    if (x > y) {
                        IntArr[i] = y;
                        IntArr[i + 1] = x;
                        stillGoing = true;
                    }
                }
            }
            return Collection;
        }


        public Bubble(ICollection<int> collection, bool sorted) : base(collection, sorted) {}
    }
}