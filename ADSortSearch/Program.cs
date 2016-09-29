using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace ADSortSearch {
    internal static class Program {
        private static void Main(string[] args) {
            Console.WriteLine(Measure());
        }

        private static string Measure() {
            var binaryResults = new Queue<string>();
            var linearResults = new Queue<string>();
            var stringBuilder = new StringBuilder();
            const int repeats = 100000;
            const bool sorted = true;
            const int powBase = 2;
            for (var i = 10; i < 15; i++) {
                var measureBinary = Measurement.CreateSearch(new Binary((int) Math.Pow(powBase, i), sorted));
                var measureLinear = Measurement.CreateSearch(new Linear((int) Math.Pow(powBase, i), sorted));
                measureLinear.Search(repeats);
                measureBinary.Search(repeats);
                binaryResults.Enqueue(
                    measureBinary.StopWatchResult.TotalMilliseconds.ToString(CultureInfo.InvariantCulture)
                );
                linearResults.Enqueue(
                    measureLinear.StopWatchResult.TotalMilliseconds.ToString(CultureInfo.InvariantCulture)
                );
            }

            stringBuilder.AppendLine("Binary Search: ");
            while (binaryResults.Any()) stringBuilder.AppendLine(binaryResults.Dequeue());
            stringBuilder.AppendLine("\nLinear Search: ");
            while (linearResults.Any()) stringBuilder.AppendLine(linearResults.Dequeue());
            return stringBuilder.ToString();
        }
    }
}