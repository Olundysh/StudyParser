
using System.Collections.Generic;
using System.Linq;

namespace TextAnalysis
{
    static class TextGeneratorTask
    {
        public static string ContinuePhrase(Dictionary<string, string> nextWords, string phraseBeginning, int wordsCount)
        {
            var splittedPhrase = phraseBeginning.Split(' ').ToList();
            for (var i = 0; i < wordsCount; i++)
            {
                if (splittedPhrase.Count >=2 && nextWords.TryGetValue($"{splittedPhrase[splittedPhrase.Count - 2]} {splittedPhrase[splittedPhrase.Count - 1]}", out var value2))
                {
                    splittedPhrase.Add(value2);
                    continue;
                }
                if (splittedPhrase.Count >=1 && nextWords.TryGetValue(splittedPhrase[splittedPhrase.Count - 1], out var value1))
                {
                    splittedPhrase.Add(value1);
                }
            }
            return string.Join(" ", splittedPhrase);
        }
    }
}