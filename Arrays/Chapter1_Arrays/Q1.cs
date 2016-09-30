using System;
using System.Collections.Generic;
using System.Diagnostics;

///Implement an algorithm to determine if a string has all unique characters.
///What if you can not use additional data structures
namespace CrackingTheCodeInterview {
    class Ch1_Q1 {
        public static readonly int ASCII_CHAR_COUNT = 255;

        private static Stopwatch timer;

        public static void Run() {
            string arg = null;

            while (string.IsNullOrWhiteSpace(arg)) {
                Console.WriteLine("Implement an algorithm to determine if a string has all unique characters.");
                arg = Console.ReadLine();
                //arg = @"asdfjkl;qwertyguhiopzxvcbnm,./?><MNBVCXZASDFGHJKL:}{ POIUYTREWQasdfjkl; qwertyguhiopzxvcbnm,./?>< MNBVCXZASDFGHJKL : }{POIUYTREWQasdfjkl;qwertyguhiopzxvcbnm,./?><MNBVCXZASDFGHJKL:}{ POIUYTREWQasdfjkl; qwertyguhiopzxvcbnm,./?>< MNBVCXZASDFGHJKL : }{POIUYTREWQasdfjkl;qwertyguhiopzxvcbnm,./?><MNBVCXZASDFGHJKL:}{ POIUYTREWQasdfjkl; qwertyguhiopzxvcbnm,./?>< MNBVCXZASDFGHJKL : }{POIUYTREWQasdfjkl;qwertyguhiopzxvcbnm,./?><MNBVCXZASDFGHJKL:}{ POIUYTREWQasdfjkl; qwertyguhiopzxvcbnm,./?>< MNBVCXZASDFGHJKL : }{POIUYTREWQasdfjkl;qwertyguhiopzxvcbnm,./?><MNBVCXZASDFGHJKL:}{ POIUYTREWQasdfjkl; qwertyguhiopzxvcbnm,./?>< MNBVCXZASDFGHJKL : }{POIUYTREWQasdfjkl;qwertyguhiopzxvcbnm,./?><MNBVCXZASDFGHJKL:}{ POIUYTREWQasdfjkl; qwertyguhiopzxvcbnm,./?>< MNBVCXZASDFGHJKL : }{POIUYTREWQasdfjkl;qwertyguhiopzxvcbnm,./?><MNBVCXZASDFGHJKL:}{ POIUYTREWQasdfjkl; qwertyguhiopzxvcbnm,./?>< MNBVCXZASDFGHJKL : }{POIUYTREWQasdfjkl;qwertyguhiopzxvcbnm,./?><MNBVCXZASDFGHJKL:}{ POIUYTREWQasdfjkl; qwertyguhiopzxvcbnm,./?>< MNBVCXZASDFGHJKL : }{POIUYTREWQasdfjkl;qwertyguhiopzxvcbnm,./?><MNBVCXZASDFGHJKL:}{ POIUYTREWQasdfjkl; qwertyguhiopzxvcbnm,./?>< MNBVCXZASDFGHJKL : }{POIUYTREWQasdfjkl;qwertyguhiopzxvcbnm,./?><MNBVCXZASDFGHJKL:}{POIUYTREWQ";
                //StringBuilder sb = new StringBuilder();
                //for (int i = 0; i < 100; i++)
                //{
                //    sb.Append(arg);
                //}
                //arg = sb.ToString();
            }

            StartTimer();
            Algo1(arg);
            StopTimer();
            Console.WriteLine(GetPrettyTimeLapse("Algo1"));

            StartTimer();
            Algo2(arg);
            StopTimer();
            Console.WriteLine(GetPrettyTimeLapse("Algo2"));

            StartTimer();
            Algo3(arg);
            StopTimer();
            Console.WriteLine(GetPrettyTimeLapse("Algo3"));

            //Console.WriteLine("All characters were unique: {0}.",  ? "true" : "false");
            Console.Beep();
            Console.Read();
        }

        /// <summary>
        /// O(n) + List<char> storage
        /// </summary>
        public static bool Algo1(string source) {
            List<char> characterList = new List<char>();

            //Loop through each character
            foreach (char c in source) {
                //If exists return false;
                if (characterList.Contains(c)) {
                    return false;
                }
                //Insert into array
                else {
                    characterList.Add(c);
                }
            }
            return true;
        }

        /// <summary>
        /// O(n) + bool[]
        /// </summary>
        public static bool Algo2(string source) {
            bool[] usedChars = new bool[ASCII_CHAR_COUNT];

            //Loop through each character
            foreach (char c in source) {
                //if true return false;
                if (usedChars[c]) {
                    return false;
                }
                //else update to true;
                else {
                    usedChars[c] = true;
                }
            }
            return true;
        }

        /// <summary>
        /// O(n*n) + No additional Data Structs
        /// </summary>
        public static bool Algo3(string source) {
            char check;

            for (int i = 0; i < source.Length; i++) {
                check = source[i];
                for (int j = i + 1; j < source.Length; j++) {
                    if (check == source[j]) {
                        return false;
                    }
                }
            }

            return true;
        }

        private static void StartTimer() {
            timer = new Stopwatch();
            timer.Start();
        }

        private static void StopTimer() {
            timer.Stop();
        }

        private static string GetPrettyTimeLapse(string id = "") {
            return string.Format("Object \"{0}\" timed: {1}", id, timer.Elapsed.ToString());
        }


    }
}
