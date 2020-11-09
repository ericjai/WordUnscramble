using System;
using System.Collections.Generic;
using System.Linq;

namespace WordUnscramble
{
    class Program
    {
        private static readonly FileReader _filereader = new FileReader();
        private static readonly WordMatcher _wordmatcher = new WordMatcher();
        private const string wordListFileName = "wordlist.txt";
        static void Main(string[] args)
        {
            try
            {
                bool continueWordUnscramble = true;
                do
                {
                    Console.WriteLine("Please enter the option- F for file and M for Manual");
                    var option = Console.ReadLine();
                    switch (option.ToUpper())
                    {
                        case "F":
                            Console.WriteLine("Enter scrambled words file name");
                            ExecuteScrambleWordsInFileScenario();
                            break;
                        case "M":
                            Console.WriteLine("Enter scrambled words seperated by comma");
                            ExecuteScrambleWordsInManualScenario();
                            break;
                        default:
                            Console.WriteLine("Option was not recognized");
                            break;
                    }

                    var continueWordUnscrambleDecision = string.Empty;
                    do
                    {
                        Console.WriteLine("Do you want to Continue -Y for yes and N for no");
                        continueWordUnscrambleDecision = Console.ReadLine();

                    }
                    while (!continueWordUnscrambleDecision.Equals("Y", StringComparison.OrdinalIgnoreCase)
                           && !continueWordUnscrambleDecision.Equals("N", StringComparison.OrdinalIgnoreCase));

                    continueWordUnscramble = continueWordUnscrambleDecision.Equals("Y", StringComparison.OrdinalIgnoreCase);
                }
                while (continueWordUnscramble);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }

        private static void ExecuteScrambleWordsInManualScenario()
        {
            var manualInput = Console.ReadLine();
            string[] scrambledwords = manualInput.Split(',');
            DisplayMatchedUnscrambledWords(scrambledwords);

        }
        private static void ExecuteScrambleWordsInFileScenario()
        {
            try
            {
                var filename = Console.ReadLine();
                string[] scrambledwords = _filereader.Read(filename);
                DisplayMatchedUnscrambledWords(scrambledwords);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }
        private static void DisplayMatchedUnscrambledWords(string[] scrambledwords)
        {
            string[] wordList = _filereader.Read(wordListFileName);
            List<MatchedWord> matchedWords = _wordmatcher.Match(scrambledwords, wordList);
            if (matchedWords.Any())
            {
                foreach(var matchedword in matchedWords)
                {
                    Console.WriteLine("MatchFound for {0} : {1}",matchedword.matchScrambledWord,matchedword.matchWord);
                }
            }
            else
            {
                Console.WriteLine("NO Matches Have Been Found");
            }
        }
    }
}
