using System.Collections.Generic;
using System;

namespace WordUnscramble
{
    public class WordMatcher
    {
        public List<MatchedWord> Match(string[] scrambledWords, string[] wordlist)
        {
            var matchedWords = new List<MatchedWord>();
            foreach (var scrambledWord in scrambledWords)
            {
                foreach (string word in wordlist)
                {
                    if (scrambledWord.Equals(word, StringComparison.OrdinalIgnoreCase))
                    {
                        matchedWords.Add(new MatchedWord()
                        {
                            matchScrambledWord = scrambledWord,
                            matchWord = word
                        });
                    }
                    else
                    {
                        var scrambledWordArray = scrambledWord.ToCharArray();
                        var wordArray = word.ToCharArray();

                        Array.Sort(scrambledWordArray);
                        Array.Sort(wordArray);

                        var sortedScrambledWord = new string(scrambledWordArray);
                        var sortedWord = new string(wordArray);

                        if (sortedScrambledWord.Equals(sortedWord, StringComparison.OrdinalIgnoreCase))
                        {
                            matchedWords.Add(new MatchedWord()
                            {
                                matchScrambledWord = sortedScrambledWord,
                                matchWord= sortedWord

                            }) ;

                        }
                    }
                }
            }

            return matchedWords;
        }
    }
}