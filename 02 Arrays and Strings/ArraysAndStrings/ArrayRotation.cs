namespace Arrays;

public class ArrayRotation
{
    public static void RotateArray()
    {
        Console.WriteLine("Enter space-separated integers:");
        string[] input = Console.ReadLine().Split(' ');
        int n = input.Length;
        int[] array = new int[n];

        for (int i = 0; i < n; i++)
        {
            array[i] = Convert.ToInt32(input[i]);
        }

        Console.WriteLine("Enter the number of rotations:");
        int k = Convert.ToInt32(Console.ReadLine());

        int[] sumArray = new int[n];

        for (int r = 1; r <= k; r++)
        {
            int[] rotatedArray = new int[n];

            for (int i = 0; i < n; i++)
            {
                rotatedArray[(i + r) % n] = array[i];
            }

            Console.WriteLine($"rotated{r}[] = {string.Join(" ", rotatedArray)}");

            for (int i = 0; i < n; i++)
            {
                sumArray[i] += rotatedArray[i];
            }
        }

        Console.WriteLine($"sum[] = {string.Join(" ", sumArray)}");
    }
}