namespace tetris.blocks;

class JBlock : Block
{
    public JBlock()
    {
        this.Vertices = [(1, 0), (1, 1), (0, 2), (1, 2)];
    }

    public override int Width => 2;

    public override int Height => 3;
}
