namespace tetris.blocks;

class LBlock : Block
{
    public LBlock()
    {
        this.Vertices = [(0, 0), (0, 1), (0, 2), (1, 2)];
    }

    public int Width => 2;

    public int Height => 3;

    public List<(int, int)> Vertices { get; }

    public void Rotate()
    {
        throw new NotImplementedException();
    }
}
