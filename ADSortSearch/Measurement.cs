using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace ADSortSearch {
    public abstract class Measurement {
        private const int Seed = 5;

        protected Measurement(ICollection<int> collection, bool sorted) {
            Collection = collection;
            Sorted = sorted;
        }

        private Random Random { get; } = new Random(Seed);

        protected ICollection<int> Collection { get; }

        private bool Sorted { get; }

        protected int[] NumbersToFind { get; private set; }

        public Queue<long> Results { get; } = new Queue<long>();

        private Stopwatch Watch { get; } = new Stopwatch();

        public void CollectionLength(int length) {
            Collection.Clear();
            foreach (var i in Enumerable.Range(0, length))
                Collection.Add(Sorted ? i : Random.Next(length));
        }

        protected abstract void Measure(Stopwatch watch);

        public void Start(int repeats) {
            NumbersToFind = Enumerable.Range(0, repeats).Select(i => Random.Next(Collection.Count)).ToArray();
            Measure(Watch);
            Results.Enqueue(Watch.ElapsedMilliseconds);
            Watch.Reset();
        }

        public static Measurement CreateNew(Measurement measurement) => measurement;
    }
}