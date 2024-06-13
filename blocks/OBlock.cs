namespace tetris.blocks;

class OBlock : Block
{
    public OBlock()
    {
        this.Representations.Enqueue(new ([(0, 0), (1, 0), (0, 1), (1, 1)], 2, 2));
    }
}
