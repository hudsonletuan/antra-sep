namespace _Exercise03;

public class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("Choose an option:");
            Console.WriteLine("1: FizzBuzz");
            Console.WriteLine("2: Print A Pyramid");
            Console.WriteLine("3: Random Number Guessing");
            Console.WriteLine("4: Birth Date");
            Console.WriteLine("5: Greeting");
            Console.WriteLine("6: Counting Up To 24");
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
                        FizzBuzz.Play();
                        break;
                    case 2:
                        PrintAPyramid.PrintPyramid();
                        break;
                    case 3:
                        RandomNumberGuessing.Play();
                        break;
                    case 4:
                        BirthDate.Calculate();
                        break;
                    case 5:
                        Greeting.Greet();
                        break;
                    case 6:
                        CountingUpTo24.Count();
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please enter 1, 2, 3, 4, 5, or 6.");
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