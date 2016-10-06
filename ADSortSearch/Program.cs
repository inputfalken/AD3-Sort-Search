using System;
using System.Collections.Generic;
using System.Text;

namespace ADSortSearch {
    internal static class Program {
        private const int Repeats = 100000;
        private const bool Sorted = true;
        private const int PowBase = 2;

        private static void Main(string[] args) {
            Console.WriteLine(Measure());
        }

        private static string Measure() {
            var stringBuilder = new StringBuilder();
            var measureBinary = Measurement.CreateNew(new Binary(new List<int>(), Sorted));
            var measureLinear = Measurement.CreateNew(new Linear(new List<int>(), Sorted));
            var measureBubble = Measurement.CreateNew(new Bubble(new List<int>(), !Sorted));
            var measureHash =
                Measurement.CreateNew(new HashSetContains(new HashSet<int>(), Sorted));

            for (var i = 10; i <= 15; i++) {
                measureLinear.CollectionLength((int) Math.Pow(PowBase, i));
                measureLinear.Start(Repeats);
                measureBinary.CollectionLength((int) Math.Pow(PowBase, i));
                measureBinary.Start(Repeats);
                measureBubble.CollectionLength((int) Math.Pow(PowBase, i));
                measureBubble.Start(1);
                measureHash.CollectionLength((int) Math.Pow(PowBase, i));
                measureHash.Start(Repeats);
            }

            stringBuilder.AppendLine("\nHashSet result: ");
            foreach (var result in measureHash.Results)
                stringBuilder.AppendLine(result.ToString());
            stringBuilder.AppendLine("Binary Result: ");
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