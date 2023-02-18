using System;
using System.Collections.Generic;

namespace TextAnalysis
{
    static class FrequencyAnalysisTask
    {
        private static void AddOrInc(this Dictionary<ValueTuple<string, string>, int> dict, ValueTuple<string, string> key)
        {
            if (dict.TryGetValue(key, out int counter))
                dict[key] = counter + 1;
            else
                dict[key] = 1;
        }
        
        public static Dictionary<ValueTuple<string, string>, int> GetGrams(List<List<string>> text)
        {
            var result = new Dictionary<ValueTuple<string, string>, int>(32);

            foreach (var sentence in text)
            {
                for (var j = 0; j < sentence.Count - 1; j++)
                {
                    result.AddOrInc(ValueTuple.Create(sentence[j], sentence[j + 1]));

                    if (j < sentence.Count - 2)
                    {
                        result.AddOrInc(ValueTuple.Create($"{sentence[j]} {sentence[j + 1]}", sentence[j + 2]));
                    }
                }
            }

            return result;
        }

        public static Dictionary<string, ValueTuple<string, int>> GetMostFrequentWithFrequencies(Dictionary<ValueTuple<string, string>, int> source)
        {
            var result = new Dictionary<string, (string Word, int Frequency)>(source.Count / 2);

            foreach (var nGram in source)
            {
                if (result.TryGetValue(nGram.Key.Item1, out var mostFrequent))
                {
                    if (nGram.Value > mostFrequent.Frequency)
                    {
                        result[nGram.Key.Item1] = ValueTuple.Create(nGram.Key.Item2, nGram.Value);
                    }
                    else if (nGram.Value == mostFrequent.Frequency && string.CompareOrdinal(nGram.Key.Item2, mostFrequent.Word) < 0)
                    {
                        result[nGram.Key.Item1] = ValueTuple.Create(nGram.Key.Item2, nGram.Value);
                    }
                }
                else
                {
                    result.Add(nGram.Key.Item1, ValueTuple.Create(nGram.Key.Item2, nGram.Value));
                }
            }

            return result;
        }

        public static Dictionary<string, string> GetMostFrequentWords(Dictionary<string, ValueTuple<string, int>> source)
        {
            var result = new Dictionary<string, string>(source.Count);

            foreach (var kv in source)
            {
                result.Add(kv.Key, kv.Value.Item1);
            }

            return result;
        }
        
        public static Dictionary<string, string> GetMostFrequentNextWords(List<List<string>> source)
        {
            return GetMostFrequentWords(GetMostFrequentWithFrequencies(GetGrams(source)));
        }
    }
}
