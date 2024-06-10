namespace tetris.blocks;

class TBlock : Block
{
    public TBlock()
    {
        this.Vertices = [(0, 0), (1, 0), (2, 0), (1, 1)];
    }

    public override int Width => 3;

    public override int Height => 2;
}
