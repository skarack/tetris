namespace tetris.blocks;

class OBlock : Block
{
    public OBlock()
    {
        this.Vertices = [(0, 0), (1, 0), (0, 1), (1, 1)];
    }

    public int Width => 2;

    public int Height => 2;

    public List<(int, int)> Vertices { get; }

    public void Rotate()
    {
        throw new NotImplementedException();
    }
}
