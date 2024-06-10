namespace tetris.blocks;

class OBlock : Block
{
    public OBlock()
    {
        this.Vertices = [(0, 0), (1, 0), (0, 1), (1, 1)];
    }

    public override int Width => 2;

    public override int Height => 2;
}
