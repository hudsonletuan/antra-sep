namespace Arrays;

using System.Text.RegularExpressions;

public class PalindromeExtractor
{
    public static void Extract()
    {
        Console.WriteLine("Enter a text:");
        string input = Console.ReadLine();

        var uniquePalindromes = ExtractPalindromes(input);
        Console.WriteLine(string.Join(", ", uniquePalindromes));
    }

    static string[] ExtractPalindromes(string input)
    {
        string pattern = @"\b\w+\b";
        MatchCollection matches = Regex.Matches(input, pattern);

        HashSet<string> palindromes = new HashSet<string>();

        foreach (Match match in matches)
        {
            string word = match.Value;
            if (IsPalindrome(word))
            {
                palindromes.Add(word);
            }
        }

        string[] sortedPalindromes = palindromes.OrderBy(p => p).ToArray();
        return sortedPalindromes;
    }

    static bool IsPalindrome(string word)
    {
        int left = 0;
        int right = word.Length - 1;

        while (left < right)
        {
            if ((word[left]) != (word[right]))
            {
                return false;
            }
            left++;
            right--;
        }

        return true;
    }
}