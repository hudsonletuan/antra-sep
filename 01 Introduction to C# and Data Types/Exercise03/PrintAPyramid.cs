namespace _Exercise03;

public class PrintAPyramid
{
    public static void PrintPyramid()
    {
        Console.WriteLine("Enter the number of rows for the pyramid:");
        if (int.TryParse(Console.ReadLine(), out int rows))
        {
            for (int i = 1; i <= rows; i++)
            {
                for (int j = 1; j <= rows - i; j++)
                {
                    Console.Write(" ");
                }

                for (int k = 1; k <= 2 * i - 1; k++)
                {
                    Console.Write("*");
                }

                Console.WriteLine();
            }
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a valid integer.");
        }
    }
}