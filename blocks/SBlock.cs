namespace tetris.blocks;

class SBlock : Block
{
    public SBlock()
    {
        this.Vertices = [(1, 0), (2, 0), (0, 1), (1, 1)];
    }

    public override int Width => 3;

    public override int Height => 2;
}
