namespace tetris.blocks;

public interface Block
{
    List<(int, int)> Vertices { get; }

    int Width { get; }
    int Height { get; }

    void Draw(int x, int y)
    {
        foreach ((int x, int y) vertex in this.Vertices)
        {
            Pixel.Draw(x + vertex.x, y + vertex.y);
        }
    }

    void Rotate();
}
