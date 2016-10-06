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
            var bubbleResult = new Queue<string>();
            var hashResult = new Queue<string>();
            var stringBuilder = new StringBuilder();
            const int repeats = 100000;
            const bool sorted = true;
            const int powBase = 2;
            var measureBinary = Measurement.CreateNew(new Binary(new List<int>(), sorted));
            var measureLinear = Measurement.CreateNew(new Linear(new List<int>(), sorted));
            var measureBubble = Measurement.CreateNew(new Bubble(new List<int>(), !sorted));
            var measureHash =
                Measurement.CreateNew(new HashSetContains(new HashSet<int>(), sorted));

            for (var i = 10; i <= 15; i++) {
                measureLinear.CollectionLength((int) Math.Pow(powBase, i));
                measureLinear.Start(repeats);
                measureBinary.CollectionLength((int) Math.Pow(powBase, i));
                measureBinary.Start(repeats);
                measureBubble.CollectionLength((int) Math.Pow(powBase, i));
                measureBubble.Start(1);
                measureHash.CollectionLength((int) Math.Pow(powBase, i));
                measureHash.Start(repeats);
                binaryResults.Enqueue(measureBinary.Watch.ElapsedMilliseconds.ToString());
                linearResults.Enqueue(measureLinear.Watch.ElapsedMilliseconds.ToString());
                bubbleResult.Enqueue(measureBubble.Watch.ElapsedMilliseconds.ToString());
                hashResult.Enqueue(measureHash.Watch.ElapsedMilliseconds.ToString());
            }

            stringBuilder.AppendLine("Binary Result: ");
            while (binaryResults.Any()) stringBuilder.AppendLine(binaryResults.Dequeue());
            stringBuilder.AppendLine("\nLinear Result: ");
            while (linearResults.Any()) stringBuilder.AppendLine(linearResults.Dequeue());
            stringBuilder.AppendLine("\nBubble Sort Result: ");
            while (bubbleResult.Any()) stringBuilder.AppendLine(bubbleResult.Dequeue());
            while (hashResult.Any()) stringBuilder.AppendLine(hashResult.Dequeue());
            return stringBuilder.ToString();
        }
    }
}