namespace _03OOP;

public class Color
{
    private int red;
    private int green;
    private int blue;
    private int alpha;

    public Color(int red, int green, int blue, int alpha)
    {
        this.red = Clamp(red);
        this.green = Clamp(green);
        this.blue = Clamp(blue);
        this.alpha = Clamp(alpha);
    }

    public Color(int red, int green, int blue) : this(red, green, blue, 255) { }

    public int Red
    {
        get => red;
        set => red = Clamp(value);
    }

    public int Green
    {
        get => green;
        set => green = Clamp(value);
    }

    public int Blue
    {
        get => blue;
        set => blue = Clamp(value);
    }

    public int Alpha
    {
        get => alpha;
        set => alpha = Clamp(value);
    }

    public double Grayscale()
    {
        return (red + green + blue) / 3.0;
    }

    private int Clamp(int value)
    {
        if (value < 0) return 0;
        if (value > 255) return 255;
        return value;
    }
}

public class Ball
{
    private float size;
    private Color color;
    private int throwCount;

    public Ball(float size, Color color)
    {
        this.size = size;
        this.color = color;
        this.throwCount = 0;
    }

    public void Pop()
    {
        size = 0;
    }

    public void Throw()
    {
        if (size > 0)
        {
            throwCount++;
            Console.WriteLine("Ball thrown! Current throw count: " + throwCount);
        }
        else
        {
            Console.WriteLine("Cannot throw a popped ball!");
        }
    }

    public int GetThrowCount()
    {
        return throwCount;
    }
}

public class ColorBall
{
    public static void Run(string[] args)
    {
        Color redColor = new Color(255, 0, 0);
        Color greenColor = new Color(0, 255, 0);
        Color blueColor = new Color(0, 0, 255);

        Ball ball1 = new Ball(5.0f, redColor);
        Ball ball2 = new Ball(10.0f, greenColor);
        Ball ball3 = new Ball(15.0f, blueColor);

        ball1.Throw();
        ball2.Throw();
        ball3.Throw();

        ball1.Pop();
        ball1.Throw();

        Console.WriteLine($"Ball 1 throw count: {ball1.GetThrowCount()}");
        Console.WriteLine($"Ball 2 throw count: {ball2.GetThrowCount()}");
        Console.WriteLine($"Ball 3 throw count: {ball3.GetThrowCount()}");
    }
}