namespace tetris.blocks;

class LBlock : Block
{
    public LBlock()
    {
        this.Vertices = [(0, 0), (0, 1), (0, 2), (1, 2)];
    }

    public override int Width => 2;

    public override int Height => 3;
}
