namespace Arrays;

using System.Text.RegularExpressions;
public class WordReverser
{
    public static void Reverse()
    {
        Console.WriteLine("Enter a sentence:");
        string input = Console.ReadLine();

        string reversedSentence = ReverseWords(input);
        
        Console.WriteLine(reversedSentence);
    }

    static string ReverseWords(string sentence)
    {
        string separators = @"[. ,:;=()&[\]""'\\/!?\s]";

        List<string> parts = new List<string>();
        Regex regex = new Regex(separators);
        int lastIndex = 0;

        foreach (Match match in regex.Matches(sentence))
        {
            if (match.Index > lastIndex)
            {
                parts.Add(sentence.Substring(lastIndex, match.Index - lastIndex));
            }
            parts.Add(match.Value);
            lastIndex = match.Index + match.Length;
        }

        if (lastIndex < sentence.Length)
        {
            parts.Add(sentence.Substring(lastIndex));
        }

        List<string> words = new List<string>();
        List<string> separatorsList = new List<string>();

        foreach (string part in parts)
        {
            if (regex.IsMatch(part))
            {
                separatorsList.Add(part);
            }
            else
            {
                words.Add(part);
            }
        }

        words.Reverse();

        List<string> result = new List<string>();
        int wordIndex = 0;
        int separatorIndex = 0;

        foreach (string part in parts)
        {
            if (regex.IsMatch(part))
            {
                result.Add(separatorsList[separatorIndex]);
                separatorIndex++;
            }
            else
            {
                result.Add(words[wordIndex]);
                wordIndex++;
            }
        }

        return string.Join("", result);
    }
}