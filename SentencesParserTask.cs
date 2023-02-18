using System;
using System.Collections.Generic;
using System.Text;

namespace TextAnalysis
{
    static class SentencesParserTask
    {
        public static List<string> ParseWords(string sentence)
        {
            List<string> wordList = null;
            var word = new StringBuilder();

            foreach (char ch in sentence)
            {
                if (char.IsLetter(ch) || ch == '\'')
                {
                    word.Append(char.ToLower(ch));
                }
                else if (word.Length > 0)
                {
                    wordList = wordList ?? new List<string>();
                    wordList.Add(word.ToString());
                    word.Clear();
                }
            }

            if (word.Length > 0)
            {
                wordList = wordList ?? new List<string>();
                wordList.Add(word.ToString());
            }

            return wordList;
        }

        private static readonly IReadOnlyList<char> _separators = new[] { '.', '!', '?', ';', ':', '(', ')' };
        
        public static List<List<string>> ParseSentences(string text)
        {
            if (text is null)
                throw new ArgumentNullException(nameof(text));
            if (string.IsNullOrWhiteSpace(text))
                return new List<List<string>>();
            
            string[] sentences = text.Split((char[]) _separators, StringSplitOptions.RemoveEmptyEntries);

            var sentencesList = new List<List<string>>(sentences.Length);

            foreach (var t in sentences)
            {
                var sentence = ParseWords(t);
                if (sentence?.Count > 0)
                    sentencesList.Add(sentence);
            }

            return sentencesList;
        }
    }
}
