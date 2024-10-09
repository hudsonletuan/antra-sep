namespace Arrays;

public class MostFrequentNumber
{
    public static void Find()
    {
        Console.WriteLine("Enter space-separated integers:");
        string[] input = Console.ReadLine().Split(' ');
        int n = input.Length;
        int[] numbers = new int[n];

        for (int i = 0; i < n; i++)
        {
            numbers[i] = Convert.ToInt32(input[i]);
        }

        FindMostFrequentNumber(numbers);
    }

    static void FindMostFrequentNumber(int[] numbers)
    {
        Dictionary<int, int> frequencyMap = new Dictionary<int, int>();
        
        foreach (var number in numbers)
        {
            if (frequencyMap.ContainsKey(number))
            {
                frequencyMap[number]++;
            }
            else
            {
                frequencyMap[number] = 1;
            }
        }

        int maxFrequency = 0;
        int mostFrequentNumber = numbers[0];
        
        foreach (var number in numbers)
        {
            if (frequencyMap[number] > maxFrequency)
            {
                maxFrequency = frequencyMap[number];
                mostFrequentNumber = number;
            }
            else if (frequencyMap[number] == maxFrequency && number == mostFrequentNumber)
            {
                // Do nothing
            }
        }

        Console.WriteLine($"The number {mostFrequentNumber} is the most frequent (occurs {maxFrequency} times)");
    }
}