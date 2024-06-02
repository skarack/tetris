var title = "Tetris";
Console.Title = title;

var shape = new Shape(10, 10);
for (int i = 0; i < 10; i++)
{
    Console.Clear();
    DrawTitle(title);
    shape.Draw();
    shape.Update();
    Thread.Sleep(700);
}

Console.Clear();

void DrawTitle(string title)
{
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.SetCursorPosition(Console.WindowWidth/2-title.Count()/2, Console.CursorTop);
    Console.WriteLine(title);
    Console.ResetColor();
}

class Shape
{
    private int x;
    private int y;

    public Shape(int x, int y)
    {
        this.x = x;
        this.y = y;
    }

    public void Update()
    {
        this.y += 1;
    }

    public void Draw()
    {
        Console.SetCursorPosition(this.x, this.y);
        Console.WriteLine("*");
        Console.SetCursorPosition(this.x, this.y+1);
        Console.WriteLine("**");
        Console.SetCursorPosition(this.x, this.y+2);
        Console.WriteLine(" *");
    }
}
