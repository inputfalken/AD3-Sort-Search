﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace ADSortSearch {
    public abstract class Measurement {
        private const int Seed = 5;
        private const int PowBase = 2;

        private static IEnumerable<int> CollectionLengths { get; } =
            Enumerable.Range(10, 5).Select(i => (int) Math.Pow(PowBase, i));

        protected Measurement(ICollection<int> collection, bool sorted) {
            Collection = collection;
            Sorted = sorted;
        }

        private Random Random { get; } = new Random(Seed);

        protected ICollection<int> Collection { get; }

        private bool Sorted { get; }

        protected IList<int> NumbersToFind { get; private set; }

        public Queue<long> Results { get; } = new Queue<long>();

        private Stopwatch Watch { get; } = new Stopwatch();

        private void SetCollectionLength(int length) {
            Collection.Clear();
            foreach (var i in Enumerable.Range(0, length))
                Collection.Add(Sorted ? i : Random.Next(length));
        }

        protected abstract void Measure(Stopwatch watch);

        public void Start(int repeats) {
            foreach (var length in CollectionLengths) {
                SetCollectionLength(length);
                NumbersToFind = Enumerable.Range(0, repeats).Select(i => Random.Next(Collection.Count)).ToArray();
                Measure(Watch);
                Results.Enqueue(Watch.ElapsedMilliseconds);
                Watch.Reset();
            }
        }

        public static Measurement CreateNew(Measurement measurement) => measurement;
    }
}