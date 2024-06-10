namespace tetris.blocks;

abstract public class Block
{
    public List<(int, int)> Vertices { get; protected set; } = [];

    public abstract int Width { get; }
    public abstract int Height { get; }

    public void Draw(int x, int y)
    {
        foreach ((int x, int y) vertex in this.Vertices)
        {
            Pixel.Draw(x + vertex.x, y + vertex.y);
        }
    }

    public abstract void Rotate();
}
