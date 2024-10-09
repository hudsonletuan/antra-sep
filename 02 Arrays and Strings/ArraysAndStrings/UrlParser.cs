namespace Arrays;

public class UrlParser
{
    public static void Parse()
    {
        Console.WriteLine("Enter a URL:");
        string input = Console.ReadLine();

        ParseURL(input);
    }

    static void ParseURL(string url)
    {
        string protocol = "";
        string server = "";
        string resource = "";

        int protocolEndIndex = url.IndexOf("://");
        if (protocolEndIndex != -1)
        {
            protocol = url.Substring(0, protocolEndIndex);
            url = url.Substring(protocolEndIndex + 3);
        }

        int resourceStartIndex = url.IndexOf('/');
        if (resourceStartIndex != -1)
        {
            server = url.Substring(0, resourceStartIndex);
            resource = url.Substring(resourceStartIndex + 1);
        }
        else
        {
            server = url;
        }

        Console.WriteLine($"[protocol] = \"{protocol}\"");
        Console.WriteLine($"[server] = \"{server}\"");
        Console.WriteLine($"[resource] = \"{resource}\"");
    }
}