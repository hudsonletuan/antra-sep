namespace _Exercise03;

public class CountingUpTo24
{
    public static void Count()
    {
        for (int increment = 1; increment <= 4; increment++)
        {
            for (int i = 0; i <= 24; i += increment)
            {
                Console.Write(i);

                if (i + increment <= 24)
                {
                    Console.Write(",");
                }
            }

            Console.WriteLine();
        }
    }
}