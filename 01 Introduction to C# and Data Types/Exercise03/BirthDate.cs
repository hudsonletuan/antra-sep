namespace _Exercise03;

public class BirthDate
{
    public static void Calculate()
    {
        DateTime birthDate = new DateTime(1993, 09, 03);
        
        TimeSpan ageInDays = DateTime.Now - birthDate;
        int totalDaysOld = (int)ageInDays.TotalDays;

        Console.WriteLine($"Total days old: {totalDaysOld} days");

        int daysToNextAnniversary = 10000 - (totalDaysOld % 10000);
        DateTime nextAnniversary = DateTime.Now.AddDays(daysToNextAnniversary);

        Console.WriteLine($"Next 10,000-day anniversary will be on: {nextAnniversary.ToShortDateString()}");
    }
}