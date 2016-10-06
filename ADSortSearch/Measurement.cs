using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace ADSortSearch {
    public abstract class Measurement {
        protected Measurement(ICollection<int> collection, bool sorted) {
            Collection = collection;
            Sorted = sorted;
        }

        public void CollectionLength(int length) {
            Collection.Clear();
            foreach (var i in Enumerable.Range(0, length))
                Collection.Add(Sorted ? i : Random.Next(length));
        }

        private const int Seed = 5;
        private Random Random { get; } = new Random(Seed);
        protected ICollection<int> Collection { get; }
        private bool Sorted { get; }
        protected abstract void Measure(int repeats, Stopwatch watch);
        protected int[] NumbersToFind { get; private set; }

        public void Start(int repeats) {
            NumbersToFind = Enumerable.Range(0, repeats).Select(i => Random.Next(Collection.Count)).ToArray();
            Measure(repeats, Watch);
            Results.Enqueue(Watch.ElapsedMilliseconds);
            Watch.Reset();
        }

        public Queue<long> Results { get; } = new Queue<long>();

        private Stopwatch Watch { get; } = new Stopwatch();

        public static Measurement CreateNew(Measurement measurement) => measurement;
    }
}