using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace ADSortSearch {
    internal class Bubble : Measurement {
        public Bubble(ICollection<int> collection, bool sorted) : base(collection, sorted) {}

        private int[] IntArr { get; set; }

        protected override void Measure(Stopwatch watch) {
            IntArr = Collection.ToArray();
            watch.Start();
            var res = BubbleSort(IntArr);
        }

        private static IEnumerable<int> BubbleSort(IList<int> list) {
            var stillGoing = true;
            while (stillGoing) {
                stillGoing = false;
                for (var i = 0; i < list.Count - 1; i++) {
                    var x = list[i];
                    var y = list[i + 1];
                    if (x > y) {
                        list[i] = y;
                        list[i + 1] = x;
                        stillGoing = true;
                    }
                }
            }
            return list;
        }
    }
}