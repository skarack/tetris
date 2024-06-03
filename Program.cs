var title = "Tetris";
Console.Title = title;

Block shape = new IBlock(10, 10);
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

abstract class Block
{
    protected int x;
    protected int y;

    protected Block(int x, int y)
    {
        this.x = x;
        this.y = y;
    }

    public void Update()
    {
        this.y += 1;
    }

    abstract public void Draw();
}

class IBlock : Block
{
    public IBlock(int x, int y) : base(x, y)
    {
    }

    public override void Draw()
    {
        Console.SetCursorPosition(this.x, this.y);
        Console.WriteLine("*");
        Console.SetCursorPosition(this.x, this.y + 1);
        Console.WriteLine("*");
        Console.SetCursorPosition(this.x, this.y + 2);
        Console.WriteLine("*");
        Console.SetCursorPosition(this.x, this.y + 3);
        Console.WriteLine("*");
    }
}
