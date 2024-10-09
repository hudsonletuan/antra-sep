namespace _Exercise03;

public class RandomNumberGuessing
{
    public static void Play()
    {
        int correctNumber = new Random().Next(3) + 1;
        Console.WriteLine("\nGuess a number between 1 and 3:");

        int guessedNumber = int.Parse(Console.ReadLine());

        if (guessedNumber < 1 || guessedNumber > 3)
        {
            Console.WriteLine("Your guess is outside of the valid range.");
        }
        else if (guessedNumber < correctNumber)
        {
            Console.WriteLine("Your guess is too low.");
        }
        else if (guessedNumber > correctNumber)
        {
            Console.WriteLine("Your guess is too high.");
        }
        else
        {
            Console.WriteLine("Congratulations! You guessed correctly.");
        }
    }
}