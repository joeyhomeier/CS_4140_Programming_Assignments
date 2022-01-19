using System;
using System.Collections.Generic;

namespace PS1_ProgrammingTask
{
    /// <summary>
    /// Simple class made for solving the required task of 
    /// </summary>
    public class AnagramChecker
    {
        /// <summary>
        /// Main method for setting up console application to interface between user and program.
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            //Inform user on what the program does and how to use it.
            Console.WriteLine("This program returns the number of groups of anagrams there are in a provided list.");
            Console.WriteLine("To enter in a list of words, first enter two digits seperated by a space: the first" +
                " being how many words you are going to enter, and the second being the number of characters in " +
                "each word. Finally, enter in the words you want to check one at a time until you reach the amount " +
                "you selected in the beginning.");

            //Collect necessary start up data.
            string startupInfo = Console.ReadLine();
            string[] nums = startupInfo.Split(" ");
            int listSize = Int32.Parse(nums[0]);
            int wordSize = Int32.Parse(nums[1]);

            //Read in words from conole until the user has entered all the words
            string[] words = new string[listSize];
            for(int i = 0; i < listSize; i++)
            {
                words.SetValue(Console.ReadLine(), i);
            }

            //find and print the number of groups of anagrams 
            Console.WriteLine(AnagramCheck(words));
        }

        /// <summary>
        /// Algorithm for finding all anagrams in a list of words. This is accomplished by sorting each word and then 
        /// adding them to a dictionary. Since words are sorted then all anagrams will be paired together.
        /// </summary>
        /// <param name="list"></param> The list of words to find all anagrams within.
        /// <returns></returns> The number of groups of anagrams in the list.
        public static int AnagramCheck(string[] list)
        {
            //create a dictionary to store the growing number of anagrams
            Dictionary<String, List<String>> anagrams = new Dictionary<String, List<String>>();

            //create a storage list for the instances where we need to retrieve a list from the dictionary
            List<String> storage = new List<String>();

            //loop through all the provided words
            for (int i = 0; i <list.Length; i++)
            {
                //create a list of strings to add to the dictionary for a new anagram
                

                //sort the string by each character 
                char[] chars = list[i].ToCharArray();
                Array.Sort(chars);
                string sorted = new string(chars);

                //check if the sorted word already exists in the dictionary
                if (anagrams.TryGetValue(sorted, out storage))
                {
                    //add unsorted value to the existing list
                    storage.Add(list[i]);
                }
                else
                {
                    //create a new index in dictionary to represent a potential new anagram group;
                    List<String> values = new List<String>();
                    values.Add(list[i]);
                    anagrams.Add(sorted, values);
                }
            }
            //loop through all values in anagram dictionary counting each value that has at least 2 words
            //as this defines it as a group or not.
            int count = 0;
            foreach(List<string> group in anagrams.Values)
            {
                if (group.Count > 1)
                    count++;
            }
            return count;
        }
    }
}
