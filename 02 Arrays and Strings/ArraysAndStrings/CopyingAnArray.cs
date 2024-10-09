namespace Arrays;

public class CopyingAnArray
{
    public static void Copy()
    {
        int[] originalArray = new int[10] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

        int[] copiedArray = new int[originalArray.Length];

        for (int i = 0; i < originalArray.Length; i++)
        {
            copiedArray[i] = originalArray[i];
        }

        Console.WriteLine("Original Array:");
        foreach (var item in originalArray)
        {
            Console.Write(item + " ");
        }
        
        Console.WriteLine("\nCopied Array:");
        foreach (var item in copiedArray)
        {
            Console.Write(item + " ");
        }
        Console.WriteLine();
    }
}