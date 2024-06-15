namespace tetris.blocks;

class SBlock : Block
{
    public SBlock()
    {
        this.Representations.Enqueue(new ([(1, 0), (2, 0), (0, 1), (1, 1)], 3, 2));
        this.Representations.Enqueue(new ([(0, 0), (0, 1), (1, 1), (1, 2)], 2, 3));
    }
}
