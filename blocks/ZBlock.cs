namespace tetris.blocks;

class ZBlock : Block
{
    public ZBlock()
    {
        this.Vertices = [(0, 0), (1, 0), (1, 1), (2, 1)];
    }

    public override int Width => 3;

    public override int Height => 2;
}
