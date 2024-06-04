using tetris;

var tetris = new Tetris();
tetris.Run();

//var title = "Tetris";
//Console.Title = title;
//
//Block shape = new IBlock();
//for (int i = 0; i < 10; i++)
//{
//    Console.Clear();
//    DrawTitle(title);
//    shape.Draw(1, i + 1);
//    shape.Update();
//    Thread.Sleep(700);
//}
//
//Console.Clear();
//
//void DrawTitle(string title)
//{
//    Console.ForegroundColor = ConsoleColor.Yellow;
//    Console.SetCursorPosition(Console.WindowWidth/2-title.Count()/2, Console.CursorTop);
//    Console.WriteLine(title);
//    Console.ResetColor();
//}
//
//abstract class Block
//{
//    public void Update()
//    {
//    }
//
//    abstract public void Draw(int x, int y);
//}
//
//class IBlock : Block
//{
//    public IBlock()
//    {
//    }
//
//    public override void Draw(int x, int y)
//    {
//        Console.SetCursorPosition(x, y);
//        Console.WriteLine("*");
//        Console.SetCursorPosition(x, y + 1);
//        Console.WriteLine("*");
//        Console.SetCursorPosition(x, y + 2);
//        Console.WriteLine("*");
//        Console.SetCursorPosition(x, y + 3);
//        Console.WriteLine("*");
//    }
//}
