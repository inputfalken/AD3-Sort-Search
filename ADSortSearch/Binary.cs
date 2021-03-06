﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace ADSortSearch {
    public class Binary : Measurement {
        public Binary(ICollection<int> collection) : base(collection, true) {}


        protected override void Measure(Stopwatch watch) {
            // Checks that the collection is ordered.
            if (!Collection.Zip(Collection.Skip(1), (a, b) => new {a, b}).All(p => p.a <= p.b))
                throw new Exception("Collection must be sorted");
            watch.Start();
            foreach (var randomNumber in RandomIntegers)
                BinarySearch(randomNumber, Collection.ToArray());
        }

        private static int BinarySearch(int key, IList<int> list) {
            var lo = 0;
            var hi = list.Count - 1;
            while (lo <= hi) {
                var mid = lo + (hi - lo)/2;
                if (key < list[mid]) hi = mid - 1;
                else if (key > list[mid]) lo = mid + 1;
                else return mid;
            }
            throw new Exception("No Result found");
        }
    }
}