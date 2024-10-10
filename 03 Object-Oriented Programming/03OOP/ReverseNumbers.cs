namespace _03OOP;

public class ReverseNumbers
{
    public static void Active(string[] args)
    {
        int length = 10;
        int[] numbers = GenerateNumbers(length);

        Reverse(numbers);

        PrintNumbers(numbers);
    }

    static int[] GenerateNumbers(int length)
    {
        int[] numbers = new int[length];
        for (int i = 0; i < length; i++)
        {
            numbers[i] = i + 1;
        }
        return numbers;
    }

    static void Reverse(int[] arr)
    {
        int length = arr.Length;
        for (int i = 0; i < length / 2; i++)
        {
            int temp = arr[i];
            arr[i] = arr[length - i - 1];
            arr[length - i - 1] = temp;
        }
    }

    static void PrintNumbers(int[] arr)
    {
        foreach (int number in arr)
        {
            Console.Write(number + " ");
        }
        Console.WriteLine();
    }
}