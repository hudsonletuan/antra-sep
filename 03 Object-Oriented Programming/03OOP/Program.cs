namespace _03OOP;

public class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("Choose an option:");
            Console.WriteLine("1: Reversing Numbers");
            Console.WriteLine("2: Fibonacci");
            Console.WriteLine("3: Design and Build Classes");
            Console.WriteLine("4: Color and Ball");
            Console.WriteLine("0: Exit");
            Console.Write("Enter your choice (enter one number only): ");
            
            if (int.TryParse(Console.ReadLine(), out int choice))
            {
                switch (choice)
                {
                    case 0:
                        Environment.Exit(0);
                        break;
                    case 1:
                        ReverseNumbers.Active(args);
                        break;
                    case 2:
                        Fibonacci.Run(args);
                        break;
                    case 3:
                        BuildingClasses.Build(args);
                        break;
                    case 4:
                        ColorBall.Run(args);
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please enter 1, 2, 3, or 4.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid integer.");
            }
            
            Console.WriteLine("----------------------------------------");
        }
    }
}