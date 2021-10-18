using System;
using System.Collections.Generic;
using System.Linq;

namespace SigmaHT_7_1
{
    class TextChanger
    {
        Dictionary<string, string> dictionary;

        public TextChanger()
        {
            dictionary = new Dictionary<string, string>();

            dictionary.Add("I", "Boy");

            dictionary.Add("go", "run");

            dictionary.Add("to", "to");

            dictionary.Add("school", "cinema");
        }

        public TextChanger(Dictionary<string, string> dictionary)
        {
            this.dictionary = dictionary;
        }

        public string GetChangedText(string text)
        {
            string[] sentences = text.Split(new char[] { '.',',','?','!',':'}, StringSplitOptions.RemoveEmptyEntries);

            List<string> words = new List<string>();

            for (int i = 0; i < sentences.Length; i++)
            {
                words.AddRange(sentences[i].Split());
            }

            for (int i = 0; i < words.Count;i++)
            {
                if(!(dictionary.Keys.ToArray().Contains(words[i])
                    || dictionary.Values.ToArray().Contains(words[i])))
                {
                    if (words[i] == String.Empty || words[i] == " ")
                        continue;
                    dictionary.Add(words[i], GetNewPair(words[i]));
                }
            }

            foreach (var item in dictionary)
            {
               text = text.Replace(item.Key, item.Value);
            }


            return text;
        }

        private string GetNewPair(string word)
        {
            Console.WriteLine($"Enter pair for {word}");
            return Console.ReadLine();
        }
    }
}
