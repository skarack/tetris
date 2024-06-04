namespace tetris;

public class Tetris
{
    const int GAME_WIDTH = 26;
    const int GAME_HEIGHT = 20;
    const int PLAYFIELD_WIDTH = 10;
    const int PLAYFIELD_HEIGHT = 16;
    const int NEXT_BLOCK_POS_X = 17;
    const int NEXT_BLOCK_POS_Y = 3;
    const int SCORE_POS_X = 17;
    const int SCORE_POS_Y = 15;
    const string TITLE = "Tetris";

    private Block nextBlock;
    private int score;

    public Tetris()
    {
        this.nextBlock = new IBlock();
    }

    public void Run()
    {
        while(true)
        {
            Console.Clear();

            DrawTitle();
            DrawPlayfield();
            DrawScore();
            DrawNextBlock();
            Thread.Sleep(1000);
        }
    }

    private void DrawScore()
    {
        Console.SetCursorPosition(SCORE_POS_X, SCORE_POS_Y);
        Console.WriteLine("SCORE");
        Console.SetCursorPosition(SCORE_POS_X, SCORE_POS_Y+1);
        Console.WriteLine(score);
    }

    private void DrawNextBlock()
    {
        Console.SetCursorPosition(NEXT_BLOCK_POS_X, NEXT_BLOCK_POS_Y);
        Console.WriteLine("NEXT");
        this.nextBlock.Draw(NEXT_BLOCK_POS_X, NEXT_BLOCK_POS_Y + 1);
    }

    private void DrawPlayfield()
    {
        // Draw playfield left border
        for (int i = 0; i < PLAYFIELD_HEIGHT; i++)
        {
            Console.SetCursorPosition(3, i+2);
            Console.WriteLine("|");
        }

        // Draw playfield right border
        for (int i = 0; i < PLAYFIELD_HEIGHT; i++)
        {
            Console.SetCursorPosition(PLAYFIELD_WIDTH+4, i+2);
            Console.WriteLine("|");
        }

        // Draw playfield bottom border
        for (int i = 0; i < PLAYFIELD_WIDTH; i++)
        {
            Console.SetCursorPosition(i+4, PLAYFIELD_HEIGHT + 2);
            Console.WriteLine("_");
        }
    }

    private void DrawTitle()
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.SetCursorPosition(GAME_WIDTH/2-TITLE.Count()/2, Console.CursorTop);
        Console.WriteLine(TITLE);
        Console.ResetColor();
    }
}
