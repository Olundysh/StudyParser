using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using NUnitLite;

namespace TextAnalysis
{
    internal static class Program
    {
        //Я себя тестировала, отрабатывает ли парсер на названиях. По моим результатам - отрабатывает, по тесту в курсе - нет.
        public static void Main(string[] args)
        
        {
             var sentence = @" 1. THE BOY WHO LIVED
   

            Mr. and Mrs. Dursley, of number four, Privet Drive, were proud to say that they were perfectly normal,   ";

             SentencesParserTask.ParseSentences(sentence);

             foreach (var item in SentencesParserTask.ParseSentences(sentence))
             {
                 foreach (var i in item)
                 {
                     Console.WriteLine(i);
                 }
                 // Console.WriteLine("Предложение кончилось");
             }
            
            //  List<List<string>> ParseText(string text)
            // {
            //     return text.Split('.')
            //         .Select(sentence => sentence.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList())
            //         .ToList();
            // }
            //  
            // var textI = "x y z";
            // var parsedText = ParseText(textI);
            // FrequencyAnalysisTask.GetMostFrequentNextWords(parsedText);
            
            // Запуск автоматических тестов. Ниже список тестовых наборов, который нужно запустить.
            // Закомментируйте тесты на те задачи, к которым ещё не приступали, чтобы они не мешались в консоли.
            // Все непрошедшие тесты 
            // var testsToRun = new string[]
            // {
            //     "TextAnalysis.SentencesParser_Tests",
            //     "TextAnalysis.FrequencyAnalysis_Tests",
            //     "TextAnalysis.TextGenerator_Tests",
            // };
            // new AutoRun().Execute(new[]
            // {
            //     "--stoponerror", // Останавливать после первого же непрошедшего теста. Закомментируйте, чтобы увидеть все падающие тесты
            //     "--noresult",
            //     "--test=" + string.Join(",", testsToRun)
            // });
            //
            // var text = File.ReadAllText("HarryPotterText.txt");
            // var sentences = SentencesParserTask.ParseSentences(text);
            // var frequency = FrequencyAnalysisTask.GetMostFrequentNextWords(sentences);
            // //Расскомментируйте этот блок, если хотите выполнить последнюю задачу до первых двух.
            // /*
            // frequency = new Dictionary<string, string>
            // {
            //     {"harry", "potter"},
            //     {"potter", "boy" },
            //     {"boy", "who" },
            //     {"who", "likes" },
            //     {"boy who", "survived" },
            //     {"survived", "attack" },
            //     {"he", "likes" },
            //     {"likes", "harry" },
            //     {"ron", "likes" },
            //     {"wizard", "harry" },
            // };
            // */
            // while (true)
            // {
            //     Console.Write("Введите первое слово (например, harry): ");
            //     var beginning = Console.ReadLine();
            //     if (string.IsNullOrEmpty(beginning)) return;
            //     var phrase = TextGeneratorTask.ContinuePhrase(frequency, beginning.ToLower(), 10);
            //     Console.WriteLine(phrase);
            // }
        }
    }
}