namespace tetris;

using tetris.blocks;

public class Tetris
{
    const int FRAME_PACE = 1000 / 60;

    private readonly Random rdn = new();

    private int score;
    private Block next_block;

    public Tetris()
    {
        this.next_block = this.GenerateNewBlock();
    }

    public void Run()
    {
        var playfield = new Playfield(5, 5);
        playfield.OnNewBlockNeeded = () =>
        {
            Block block = this.next_block;
            this.next_block = this.GenerateNewBlock();
            return block;
        };
        playfield.OnRowsDeleted = (row_count) => { this.CalculateScore(row_count); };

        while(true)
        {
            Console.Clear();
            playfield.Update();
            this.ShowScore();
            this.ShowNextBlock();
            Thread.Sleep(FRAME_PACE);
        }
    }

    private void CalculateScore(int row_count)
    {
        //40 * (n + 1) 	100 * (n + 1) 	300 * (n + 1) 	1200 * (n + 1)
        score += row_count switch 
        {
            1 => 40,
            2 => 100,
            3 => 300,
            _ => 1200
        };
    }

    private Block GenerateNewBlock() => this.rdn.Next(7) switch
    {
        0 => new IBlock(),
        1 => new SBlock(),
        2 => new LBlock(),
        3 => new JBlock(),
        4 => new OBlock(),
        5 => new ZBlock(),
        6 => new TBlock(),
        _ => new SBlock()
    };

    private void ShowNextBlock()
    {
        Console.SetCursorPosition(35, 5);
        Console.WriteLine("NEXT");
        this.next_block.Draw(19, 7);
    }

    private void ShowScore()
    {
        Console.SetCursorPosition(35, 12);
        Console.WriteLine("SCORE");
        Console.SetCursorPosition(35, 13);
        Console.WriteLine(this.score);
    }
}
