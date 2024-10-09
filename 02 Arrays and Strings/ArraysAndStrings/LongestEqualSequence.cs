namespace Arrays;

public class LongestEqualSequence
{
    public static void Find()
    {
        Console.WriteLine("Enter space-separated integers:");
        string[] input = Console.ReadLine().Split(' ');
        int n = input.Length;
        int[] array = new int[n];

        for (int i = 0; i < n; i++)
        {
            array[i] = Convert.ToInt32(input[i]);
        }

        FindLongestEqualSequence(array);
    }

    static void FindLongestEqualSequence(int[] array)
    {
        int maxLength = 1;
        int currentLength = 1;
        int startIndex = 0;
        int longestStartIndex = 0;

        for (int i = 1; i < array.Length; i++)
        {
            if (array[i] == array[i - 1])
            {
                currentLength++;
            }
            else
            {
                if (currentLength > maxLength)
                {
                    maxLength = currentLength;
                    longestStartIndex = startIndex;
                }
                currentLength = 1;
                startIndex = i;
            }
        }

        if (currentLength > maxLength)
        {
            maxLength = currentLength;
            longestStartIndex = startIndex;
        }

        Console.WriteLine($"Longest sequence: {string.Join(" ", GetLongestSequence(array, longestStartIndex, maxLength))}");
    }

    static int[] GetLongestSequence(int[] array, int startIndex, int length)
    {
        int[] result = new int[length];
        Array.Copy(array, startIndex, result, 0, length);
        return result;
    }
}