namespace tetris.blocks;

public abstract class Block
{
    public Queue<Representation> Representations { get; } = [];

    public Representation CurrentRepresentation => this.Representations.Peek();

    public void Draw(int x, int y)
    {
        var currentRepresentation = this.Representations.Peek();
        foreach ((int x, int y) vertex in currentRepresentation.Vertices)
        {
            Pixel.Draw(x + vertex.x, y + vertex.y);
        }
    }

    public void Rotate()
    {
        this.Representations.Enqueue(this.Representations.Dequeue());
    }
}
