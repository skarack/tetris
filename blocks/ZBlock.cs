namespace tetris.blocks;

class ZBlock : Block
{
    public ZBlock()
    {
        this.Vertices = [(0, 0), (1, 0), (1, 1), (2, 1)];
    }

    public int Width => 3;

    public int Height => 2;

    public List<(int, int)> Vertices { get; }

    public void Rotate()
    {
        throw new NotImplementedException();
    }
}
