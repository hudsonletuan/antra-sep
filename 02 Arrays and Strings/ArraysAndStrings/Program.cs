using Arrays;

namespace _ArraysAndStrings;

public class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("Choose an option:");
            Console.WriteLine("1: Copying An Array");
            Console.WriteLine("2: Manage A List");
            Console.WriteLine("3: Prime Numbers");
            Console.WriteLine("4: Rotating Array");
            Console.WriteLine("5: Longest Equal Sequence");
            Console.WriteLine("6: Most Frequent Number");
            Console.WriteLine("7: Reversing String");
            Console.WriteLine("8: Reversing Word");
            Console.WriteLine("9: Extracting Palindrome");
            Console.WriteLine("10: Parsing URL");
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
                        CopyingAnArray.Copy();
                        break;
                    case 2:
                        ManageAList.Manage();
                        break;
                    case 3:
                        PrimeNumbers.Calculate();
                        break;
                    case 4:
                        ArrayRotation.RotateArray();
                        break;
                    case 5:
                        LongestEqualSequence.Find();
                        break;
                    case 6:
                        MostFrequentNumber.Find();
                        break;
                    case 7:
                        StringReverser.Reverse();
                        break;
                    case 8:
                        WordReverser.Reverse();
                        break;
                    case 9:
                        PalindromeExtractor.Extract();
                        break;
                    case 10:
                        UrlParser.Parse();
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please enter a number in the range of 1-10.");
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