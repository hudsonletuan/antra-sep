namespace Arrays;

public class StringReverser
{
    public static void Reverse()
    {
        Console.WriteLine("Enter a string:");
        string input = Console.ReadLine();

        string reversedUsingArray = ReverseUsingArray(input);
        Console.WriteLine(reversedUsingArray);

        ReverseUsingForLoop(input);
    }

    static string ReverseUsingArray(string str)
    {
        char[] charArray = str.ToCharArray();
        Array.Reverse(charArray);
        return new string(charArray);
    }

    static void ReverseUsingForLoop(string str)
    {
        Console.Write("Reversed using for-loop: ");
        for (int i = str.Length - 1; i >= 0; i--)
        {
            Console.Write(str[i]);
        }
        Console.WriteLine();
    }
}