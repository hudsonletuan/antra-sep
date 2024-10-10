namespace _03OOP;

public class Fibonacci
{
    public static void Run(string[] args)
    {
        for (int i = 1; i <= 10; i++)
        {
            Console.WriteLine($"Fibonacci({i}) = {CalculateFibonacci(i)}");
        }
    }

    static int CalculateFibonacci(int n)
    {
        if (n == 1 || n == 2)
        {
            return 1;
        }
        
        return CalculateFibonacci(n - 1) + CalculateFibonacci(n - 2);
    }
}