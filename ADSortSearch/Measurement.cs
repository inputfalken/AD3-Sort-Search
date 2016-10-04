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
        private Random Random { get; } = new Random(Seed);
        protected int[] Ints { get; }
        protected abstract void Measure(int repeats, Stopwatch watch);
        protected int[] NumbersToFind { get; private set; }

        public void Start(int repeats) {
            NumbersToFind = Enumerable.Range(0, repeats).Select(i => Random.Next(Ints.Length)).ToArray();
            Measure(repeats, Watch);
            StopWatchResult = Watch.Elapsed;
            Watch.Reset();
        }

        private Stopwatch Watch { get; } = new Stopwatch();
        public TimeSpan StopWatchResult { get; private set; }

        public static Measurement CreateNew(Measurement measurement) => measurement;
    }
}