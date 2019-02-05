using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace _03.Word_Count
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader wordsReader = new StreamReader("../../../Resorces/words.txt");
            StreamReader textReader = new StreamReader("../../../Resorces/text.txt");

            Regex wordRegex = new Regex(@"\w+");

            Dictionary<string, int> result = new Dictionary<string, int>();

            using (wordsReader)
            {
                using (textReader)
                {
                    MatchCollection words = wordRegex.Matches(wordsReader.ReadToEnd());

                    string text = textReader.ReadToEnd().ToLower();

                    foreach (var word in words)
                    {
                        Regex textRegex = new Regex("\\b" + word.ToString() + "\\b");

                        MatchCollection textMatches = textRegex.Matches(text);

                        foreach (var match in textMatches)
                        {
                            if(result.ContainsKey(match.ToString()))
                            {
                                result[match.ToString()]++;
                            }
                            else
                            {
                                result.Add(match.ToString(), 1);
                            }
                        }
                    }
                }
            }

            result = result.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);

            StreamWriter resultWriter = new StreamWriter("../../result.txt");

            using (resultWriter)
            {
                foreach (var word in result)
                {
                    resultWriter.Write($"{word.Key} - {word.Value}");
                    resultWriter.WriteLine();
                }
            }
        }
    }
}
