namespace tetris;

class IBlock : Block
{
    public IBlock()
    {
    }

    public override void Draw(int x, int y)
    {
        Console.SetCursorPosition(x, y);
        Console.WriteLine("*");
        Console.SetCursorPosition(x, y + 1);
        Console.WriteLine("*");
        Console.SetCursorPosition(x, y + 2);
        Console.WriteLine("*");
        Console.SetCursorPosition(x, y + 3);
        Console.WriteLine("*");
    }
}
