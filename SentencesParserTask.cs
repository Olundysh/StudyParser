using System;
using System.Collections.Generic;
using System.Text;

namespace TextAnalysis
{
    static class SentencesParserTask
    {
        public static List<string> ParseWords(string sentence)
        {
            var word = new StringBuilder();
            var wordList = new List<string>();

            for (var i = 0; i < sentence.Length; i++)
            {
                if (char.IsLetter(sentence[i]) || sentence[i] == '\'')
                {
                    word.Append(sentence[i]);
                    if (i == sentence.Length - 1)
                    {
                        wordList.Add(word.ToString().ToLower());
                    }
                }
                else if (word.Length > 0)
                {
                    wordList.Add(word.ToString().ToLower());
                    word.Clear();
                }
            }

            return wordList;
        }

        public static List<List<string>> ParseSentences(string text)
        {

            var separators = new[] { '.', '!', '?', ';', ':', '(', ')' };
            var sentences = text.Split(separators, StringSplitOptions.RemoveEmptyEntries);

            var sentencesList = new List<List<string>>();

            foreach (var t in sentences)
            {
                sentencesList.Add(ParseWords(t));
            }

            return sentencesList;
        }
    }
}
