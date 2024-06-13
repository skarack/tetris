namespace tetris;

using tetris.blocks;

public class Tetris
{
    const int FRAME_PACE = 1000 / 60;

    private readonly Random rdn = new();

    public Tetris()
    {
    }

    public void Run()
    {
        var playfield = new Playfield(5, 5);
        playfield.OnNewBlockNeeded = () => this.GenerateNewBlock();

        while(true)
        {
            Console.Clear();
            playfield.Update();
            Thread.Sleep(FRAME_PACE);
        }
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
}
