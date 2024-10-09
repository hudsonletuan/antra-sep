namespace _Exercise03;

public class Greeting
{
    public static void Greet()
    {
        DateTime currentTime = DateTime.Now;

        int hour = currentTime.Hour;

        if (hour >= 5 && hour < 12)
        {
            Console.WriteLine("Good Morning");
        }
        
        if (hour >= 12 && hour < 17)
        {
            Console.WriteLine("Good Afternoon");
        }
        
        if (hour >= 17 && hour < 21)
        {
            Console.WriteLine("Good Evening");
        }
        
        if ((hour >= 21 && hour < 24) || (hour >= 0 && hour < 5))
        {
            Console.WriteLine("Good Night");
        }
    }
}