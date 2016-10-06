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
            var stringBuilder = new StringBuilder();
            const int repeats = 100000;
            const bool sorted = true;
            const int powBase = 2;
            for (var i = 10; i <= 15; i++) {
                var measureBinary = Measurement.CreateNew(new Binary((int) Math.Pow(powBase, i), sorted));
                var measureLinear = Measurement.CreateNew(new Linear((int) Math.Pow(powBase, i), sorted));
                var measureBubble = Measurement.CreateNew(new Bubble((int) Math.Pow(powBase, i), !sorted));
                measureLinear.Start(repeats);
                measureBinary.Start(repeats);
                measureBubble.Start(1);
                binaryResults.Enqueue(measureBinary.Watch.ElapsedMilliseconds.ToString());
                linearResults.Enqueue(measureLinear.Watch.ElapsedMilliseconds.ToString());
                bubbleResult.Enqueue(measureBubble.Watch.ElapsedMilliseconds.ToString());
            }

            stringBuilder.AppendLine("Binary Result: ");
            while (binaryResults.Any()) stringBuilder.AppendLine(binaryResults.Dequeue());
            stringBuilder.AppendLine("\nLinear Result: ");
            while (linearResults.Any()) stringBuilder.AppendLine(linearResults.Dequeue());
            stringBuilder.AppendLine("\nBubble Sort Result: ");
            while (bubbleResult.Any()) stringBuilder.AppendLine(bubbleResult.Dequeue());
            return stringBuilder.ToString();
        }
    }
}