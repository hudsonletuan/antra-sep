namespace Arrays;

public class PrimeNumbers
{
    public static void Calculate()
    {
        Console.WriteLine("Enter the start number:");
        int startNum = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Enter the end number:");
        int endNum = Convert.ToInt32(Console.ReadLine());

        int[] primes = FindPrimesInRange(startNum, endNum);

        Console.WriteLine($"Prime numbers between {startNum} and {endNum}:");
        if (primes.Length == 0)
        {
            Console.WriteLine("No prime numbers found in this range.");
        }
        else
        {
            foreach (var prime in primes)
            {
                Console.Write(prime + " ");
            }
            Console.WriteLine();
        }
    }

    static int[] FindPrimesInRange(int startNum, int endNum)
    {
        List<int> primes = new List<int>();

        for (int num = startNum; num <= endNum; num++)
        {
            if (IsPrime(num))
            {
                primes.Add(num);
            }
        }

        return primes.ToArray();
    }

    static bool IsPrime(int number)
    {
        if (number < 2) return false;

        for (int i = 2; i <= Math.Sqrt(number); i++)
        {
            if (number % i == 0) return false;
        }

        return true;
    }
}