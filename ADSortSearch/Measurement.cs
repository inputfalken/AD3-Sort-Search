using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace ADSortSearch {
    public abstract class Measurement {
        protected Measurement(int length, bool sorted) {
            Ints = sorted
                ? Enumerable.Range(0, length).ToArray()
                : Enumerable.Range(0, length).Select(i => Random.Next(length)).ToArray();
        }

        protected Measurement(IEnumerable<int> enumerable) {
            Ints = enumerable.ToArray();
        }

        private const int Seed = 5;
        protected Random Random { get; } = new Random(Seed);
        protected int[] Ints { get; }
        protected abstract int[] StartMeasurment(int repeats);

        public int[] Start(int repeats) {
            Watch.Restart();
            var arr = StartMeasurment(repeats);
            StopWatchResult = Watch.Elapsed;
            return arr;
        }

        private Stopwatch Watch { get; } = new Stopwatch();
        public TimeSpan StopWatchResult { get; private set; }

        public static Measurement CreateNew(Measurement measurement) => measurement;
    }
}