namespace _02UnderstandingTypes;

public class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Choose an option:");
        Console.WriteLine("1: Number of Bytes");
        Console.WriteLine("2: Centuries Converter");
        Console.Write("Enter your choice (1 or 2): ");
            
        if (int.TryParse(Console.ReadLine(), out int choice))
        {
            switch (choice)
            {
                case 1:
                    NumberOfBytes.DisplayTypeInfo();
                    break;
                case 2:
                    CenturiesConverter.ConvertCenturies();
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please enter 1 or 2.");
                    break;
            }
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a valid integer.");
        }
    }
}