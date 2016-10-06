using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace ADSortSearch {
    public abstract class Measurement {
        protected Measurement(int length, bool sorted) {
            Collection = sorted
                ? Enumerable.Range(0, length).ToArray()
                : Enumerable.Range(0, length).Select(i => Random.Next(length)).ToArray();
        }

        protected Measurement(ICollection<int> collection, int length, bool sorted) {
            Collection = collection;
            foreach (var i in Enumerable.Range(0, length))
                Collection.Add(sorted ? i : Random.Next(length));
        }


        private const int Seed = 5;
        private Random Random { get; } = new Random(Seed);
        protected ICollection<int> Collection { get; }
        protected abstract void Measure(int repeats, Stopwatch watch);
        protected int[] NumbersToFind { get; private set; }

        public void Start(int repeats) {
            Watch.Reset();
            NumbersToFind = Enumerable.Range(0, repeats).Select(i => Random.Next(Collection.Count)).ToArray();
            Measure(repeats, Watch);
        }

        public Stopwatch Watch { get; } = new Stopwatch();

        public static Measurement CreateNew(Measurement measurement) => measurement;
    }
}