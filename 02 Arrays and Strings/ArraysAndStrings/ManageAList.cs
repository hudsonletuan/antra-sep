namespace Arrays;

public class ManageAList
{
    public static void Manage()
    {
        List<string> itemList = new List<string>();
        
        while (true)
        {
            Console.WriteLine("\nCurrent List:");
            if (itemList.Count == 0)
            {
                Console.WriteLine("The list is empty.");
            }
            else
            {
                foreach (var item in itemList)
                {
                    Console.WriteLine(item);
                }
            }

            Console.WriteLine("Enter command (+ item, - item, or -- to clear. Enter 0 to exit.):");
            string input = Console.ReadLine();

            if (input == "--")
            {
                itemList.Clear();
            }
            else if (input.StartsWith("+"))
            {
                string item = input.Substring(1).Trim();
                itemList.Add(item);
            }
            else if (input.StartsWith("-"))
            {
                string item = input.Substring(1).Trim();
                if (itemList.Contains(item))
                {
                    itemList.Remove(item);
                }
                else
                {
                    Console.WriteLine($"Item '{item}' not found in the list.");
                }
            }
            else if (input == "0")
            {
                break;
            }
            else
            {
                Console.WriteLine("Invalid command. Please use + item, - item, or -- to clear. Enter 0 to exit.");
            }
        }
    }
}