using System;
using System.Collections.Generic;

namespace ADSortSearch {
    internal static class Program {
        private static void Main(string[] args) {
            var searchAndSortTest = SearchAndSortTest.CreateSearch(new Linear(30000,true));

            foreach (var i in searchAndSortTest.Search(30)) {
                Console.WriteLine(i);
            }
            Console.WriteLine(searchAndSortTest.StopWatchResult);
        }
    }
}