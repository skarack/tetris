namespace tetris.blocks;

class IBlock : Block
{
    private int orientation = 0;
    public List<(int, int)> StandingVertices { get; init; } = [];
    public List<(int, int)> FlatVertices { get; init; } = [];

    public IBlock()
    {
        this.StandingVertices = [(0, 0), (0, 1), (0, 2), (0, 3)];
        this.FlatVertices = [(0, 0), (1, 0), (2, 0), (3, 0)];
        this.Vertices = this.StandingVertices;

        this.Width = 1;
        this.Height = 4;
    }

    public int Width { get; private set; }

    public int Height { get; private set; }

    public List<(int, int)> Vertices { get; private set; }

    public void Rotate()
    {
        if (orientation == 0)
        {
            this.Vertices = FlatVertices;
            this.orientation = 1;
            this.Width = 4;
            this.Height = 1;
            return;
        }

        this.Vertices = StandingVertices;
        this.orientation = 0;
        this.Width = 1;
        this.Height = 4;
    }
}
