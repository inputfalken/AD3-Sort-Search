using System;
using System.Collections.Generic;

namespace ADSortSearch {
    internal static class Program {
        private static void Main(string[] args) {
            var measureTime = Measurement.CreateSearch(new Binary(200, true));
        }
    }
}