using System;
using System.Collections.Generic;
using System.Text;

namespace TextAnalysis
{
    static class SentencesParserTask
    {
        public static List<string> ParseWords(string sentence)
        {
            var wordList = new List<string>();
            var word = new StringBuilder();
           

            for (var i = 0; i < sentence.Length; i++)
            {
                if (char.IsLetter(sentence[i]) || sentence[i] == '\'')
                {
                    word.Append(sentence[i].ToString().ToLower());
                   
                }
                else 
                {
                    word.Append(' ');
                }
            }
            
            string[] stringsOfWords = word.ToString().Split(new char[] {' '}, System.StringSplitOptions.RemoveEmptyEntries);
            
            foreach (string item in stringsOfWords)
            {
                wordList.Add(item);
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
