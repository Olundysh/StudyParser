using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace TextAnalysis
{
    [TestFixture]
    public class MyParser_MyTests
    {
        [Test]
        [Order(00)]
        public static void ReturnCorrectResult_DifficultSentenceParsing(
            [Values('^', '#', '$', '-', '+', '1', '=', ' ', '\t', '\n', '\r', '.', '!', '?', ';', ':', '(', ')')]
            char separator)
        {
            var sentence = "Harry" + separator + "Potter";
            var expected = new List<string>
            {
                "harry", "potter"
            };
            var actual = SentencesParserTask.ParseWords(sentence);

            Assert.AreEqual(expected, actual, "Something went wrong with separators.");
        }
        
        [Test]
        [Order(10)]
        public static void ReturnCorrectResult_TitleParsing()
        {
            var text = @" 1. THE BOY WHO LIVED
   

   Mr. and Mrs. Dursley, of number four, Privet Drive,          were perfectly normal, ";
            var expected = new List<List<string>>
            {
                new List<string> { "the", "boy", "who", "lived", "mr" },
                new List<string> { "and", "mrs" },
                new List<string> { "dursley", "of", "number", "four", "privet", "drive", "were", "perfectly", "normal" }
            };
            var actual = SentencesParserTask.ParseSentences(text);
            
            Assert.AreEqual(expected, actual, "Something went wrong with sentences division.");
        }
    }
    
    
}