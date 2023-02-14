using System;
using System.Collections.Generic;


namespace TextAnalysis
{
    static class FrequencyAnalysisTask
    {
        //Создаю словарь, в который буду складывать би-граммы. Сама би-грамма лежит в ключе, value считает, сколько раз она встречается.
        public static Dictionary<Tuple<string, string>, int> BiGramDictionary(List<List<string>> text)
        {
            var sentenceDividedToNgrams = new Dictionary<Tuple<string, string>, int>();

            //Разворачиваю цикл, в котором буду проходиться по каждому предложению и записывать из него биграммы
            foreach (var t in text)
            {
                for (var j = 0; j < t.Count - 1; j++)
                {
                    var biKey = new Tuple<string, string>(t[j], t[j + 1]);

                    if (!sentenceDividedToNgrams.ContainsKey(biKey)) sentenceDividedToNgrams.Add(biKey, 1);
                    sentenceDividedToNgrams[biKey] += 1;
                }
            }

            return sentenceDividedToNgrams;
        }

        //Создаю словарь, в который буду складывать три-граммы. Сама три-грамма лежит в ключе, value считает, сколько раз она встречается.
        public static Dictionary<Tuple<string, string, string>, int> TriGramDictionary(List<List<string>> text)
        {
            var sentenceDividedToNgrams = new Dictionary<Tuple<string, string, string>, int>();
            //Разворачиваю цикл, в котором буду проходиться по каждому предложению и записывать из него триграммы
            foreach (var t in text)
            {
                for (var j = 0; j < t.Count - 2; j++)
                {
                    var triKey = new Tuple<string, string, string>(t[j], t[j + 1], t[j + 2]);

                    if (!sentenceDividedToNgrams.ContainsKey(triKey)) sentenceDividedToNgrams.Add(triKey, 1);  sentenceDividedToNgrams[triKey] += 1;
                }
            }

            return sentenceDividedToNgrams;
        }

        //Надо взять все начала ключей. У совпадающих проверить продолжения. У продолжений проверить value. Чье value больше, тот ключ и оставляем

        public static List<string[]> FrequentBiGrams(Dictionary<Tuple<string, string>, int> dictionary)

        {
            var listOfKeys = new List<string[]>();

            foreach (var d in dictionary)
            {
                listOfKeys.Add(new[] { d.Key.Item1, d.Key.Item2 });
            }

            var refinedListOfKeys = new List<string[]>();

            for (var j = 0; j < listOfKeys.Count; j++)
            {
                for (var i = j + 1; i < listOfKeys.Count; i++)
                {
                    if (!listOfKeys[j][0].Equals(listOfKeys[i][0])) continue;
                    
                    var keyJ = new Tuple<string, string>(listOfKeys[j][0], listOfKeys[j][1]);
                    var keyI = new Tuple<string, string>(listOfKeys[i][0], listOfKeys[i][1]);

                    var keyJValue = dictionary[keyJ];
                    var keyIValue = dictionary[keyI];

                    if (keyJValue > keyIValue)
                    {
                        refinedListOfKeys.Add(listOfKeys[j]);
                    }

                    if (keyJValue < keyIValue)
                    {
                        refinedListOfKeys.Add(listOfKeys[i]);
                    }

                    if (keyJValue != keyIValue) continue;
                    if (string.CompareOrdinal(listOfKeys[j][1], listOfKeys[i][1]) < 0)
                        refinedListOfKeys.Add(listOfKeys[j]);
                    refinedListOfKeys.Add(listOfKeys[i]);
                }

                refinedListOfKeys.Add(listOfKeys[j]);
            }

            return refinedListOfKeys;
        }

        public static List<string[]> FrequentTriGrams(Dictionary<Tuple<string, string, string>, int> dictionary)

        {
            var listOfKeys = new List<string[]>();

            foreach (var d in dictionary)
            {
                listOfKeys.Add(new[] { d.Key.Item1, d.Key.Item2, d.Key.Item3 });
            }

            var refinedListOfKeys = new List<string[]>();

            for (var j = 0; j < listOfKeys.Count; j++)
            {
                for (var i = j + 1; i < listOfKeys.Count; i++)
                {
                    if (!listOfKeys[j][0].Equals(listOfKeys[i][0]) ||
                        !listOfKeys[j][1].Equals(listOfKeys[i][1])) continue;

                    var keyJ = new Tuple<string, string, string>(listOfKeys[j][0], listOfKeys[j][1], listOfKeys[j][2]);
                    var keyI = new Tuple<string, string, string>(listOfKeys[i][0], listOfKeys[i][1], listOfKeys[i][2]);

                    var keyJValue = dictionary[keyJ];
                    var keyIValue = dictionary[keyI];

                    if (keyJValue > keyIValue)
                    {
                        refinedListOfKeys.Add(listOfKeys[j]);
                    }

                    if (keyJValue < keyIValue)
                    {
                        refinedListOfKeys.Add(listOfKeys[i]);
                    }

                    if (keyJValue != keyIValue) continue;
                    if (string.CompareOrdinal(listOfKeys[j][2], listOfKeys[i][2]) < 0)
                        refinedListOfKeys.Add(listOfKeys[j]);
                    refinedListOfKeys.Add(listOfKeys[i]);
                }
                refinedListOfKeys.Add(listOfKeys[j]);
            }

            return refinedListOfKeys;
        }


        //Надо начало триграм соединить в одну строку и записать ключом. Потом собрать словарь.
        public static List<string[]> FrequentJoinedTriGram(List<string[]> triGramToJoin)
        {
            var joinedTriGramList = new List<string[]>();

            for (var i = 0; i < triGramToJoin.Count; i++)
            {
                joinedTriGramList.Add(new string[2]);
                joinedTriGramList[i][0] = triGramToJoin[i][0] + " " + triGramToJoin[i][1];
                joinedTriGramList[i][1] = triGramToJoin[i][2];
            }

            return joinedTriGramList;
        }                                                                        

        //Метод по сборке словаря из List<string[]>
        public static Dictionary<string, string> ComposeDictionaryFromList(List<string[]> list)
        {
            var result = new Dictionary<string, string>();
            for (var i = 0; i < list.Count; i++)
            {
                if (result.ContainsKey(list[i][0])) continue;

                result[list[i][0]] = list[i][1];
            }

            return result;
        }

        public static Dictionary<string, string> GetMostFrequentNextWords(List<List<string>> text)
        {
            var refinedBiGramDictionary = FrequentBiGrams(BiGramDictionary(text));
            
            var result = ComposeDictionaryFromList(FrequentJoinedTriGram(FrequentTriGrams(TriGramDictionary(text))));
            
            foreach (var item in ComposeDictionaryFromList(refinedBiGramDictionary))
            {
                result.Add(item.Key, item.Value);
            }

            return result;
        }
    }
}