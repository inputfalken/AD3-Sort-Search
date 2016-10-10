using System;
using System.Collections.Generic;
using System.Text;

namespace ADSortSearch {
    internal static class Program {
        private const int Repeats = 100000;
        private const bool Sorted = true;

        private static void Main(string[] args) {
            Console.WriteLine(Measure());
        }

        private static string Measure() {
            var stringBuilder = new StringBuilder();
            var measureBinary = Measurement.CreateNew(new Binary(new List<int>()));
            var measureLinear = Measurement.CreateNew(new Linear(new List<int>()));
            var measureBubble = Measurement.CreateNew(new Bubble(new List<int>()));
            var measureHash = Measurement.CreateNew(new Contains(new HashSet<int>()));

            measureLinear.Start(Repeats);
            measureBinary.Start(Repeats);
            measureHash.Start(Repeats);
            measureBubble.Start(Repeats);

            stringBuilder.AppendLine("\nHashSet result: ");
            foreach (var result in measureHash.Results)
                stringBuilder.AppendLine(result.ToString());
            stringBuilder.AppendLine("\nBinary Result: ");
            foreach (var result in measureBinary.Results)
                stringBuilder.AppendLine(result.ToString());
            stringBuilder.AppendLine("\nLinear Result: ");
            foreach (var result in measureLinear.Results)
                stringBuilder.AppendLine(result.ToString());
            stringBuilder.AppendLine("\nBubble Sort Result: ");
            foreach (var result in measureBubble.Results)
                stringBuilder.AppendLine(result.ToString());
            return stringBuilder.ToString();
        }
    }
}