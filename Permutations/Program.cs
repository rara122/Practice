using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Permutations
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine(":::::::::::::::::::::::::::::::::::::::::::::::::::::::::\n:: Please enter a word that you want Permutated: \n:: ");
                string word = Console.ReadLine();

                while (string.IsNullOrWhiteSpace(word))
                {
                    Console.WriteLine("You just gave me a bunch of white space fool! Give me a real word: ");
                    word = Console.ReadLine();
                }

                List<string> perms = Permutate(word);
                string message = string.Format("\n:: Here is the list of Permutations: {0}\n:::::::::::::::::::::::::::::::::::::::::::::::::::::::::\n\n", string.Join(", ", perms));

                Console.WriteLine(message);
            }
        }

        static List<string> Permutate(string word) {
            List<string> permutationList = new List<string>();

            if (word.Length == 0)
            {
                return permutationList;
            }

            if (word.Length == 1)
            {
                permutationList.Add(word);
            }
            else
            {
                string wordMinusLastCharacter = word.Substring(0, word.Length - 1);
                string lastCharacter = word[word.Length-1].ToString();

                foreach (var innerPermutation in Permutate(wordMinusLastCharacter)) {
                    for (int i = 0; i <= innerPermutation.Length; i++)
                    {
                        permutationList.Add(    innerPermutation.Insert(i, lastCharacter)    );
                    }
                }
            }

            return permutationList;

        }
    }
}
