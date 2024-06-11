namespace tetris.blocks;

class SBlock : Block
{
    public SBlock()
    {
        this.Vertices = [(1, 0), (2, 0), (0, 1), (1, 1)];
    }

    public int Width => 3;

    public int Height => 2;

    public List<(int, int)> Vertices { get; }

    public void Rotate()
    {
        throw new NotImplementedException();
    }
}
