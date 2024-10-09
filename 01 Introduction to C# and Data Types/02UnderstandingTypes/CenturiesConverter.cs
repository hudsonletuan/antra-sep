namespace _02UnderstandingTypes;

public class CenturiesConverter
{
    public static void ConvertCenturies()
    {
        Console.Write("Enter the number of centuries: ");
        if (int.TryParse(Console.ReadLine(), out int centuries))
        {
            long years = centuries * 100L; 
            long days = years * 365 + (centuries / 4); 
            long hours = days * 24;
            long minutes = hours * 60;
            long seconds = minutes * 60;
            long milliseconds = seconds * 1000;
            long microseconds = milliseconds * 1000;
            long nanoseconds = microseconds * 1000;

            Console.WriteLine($"{centuries} centuries = {years} years = " +
                              $"{days} days = {hours} hours = " +
                              $"{minutes} minutes = " +
                              $"{seconds} seconds = " +
                              $"{milliseconds} milliseconds = " +
                              $"{microseconds} microseconds = " +
                              $"{nanoseconds} nanoseconds");
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a valid integer.");
        }
    }
}