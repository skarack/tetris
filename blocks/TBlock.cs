namespace tetris.blocks;

class TBlock : Block
{
    public TBlock()
    {
        this.Representations.Enqueue(new ([(0, 0), (1, 0), (2, 0), (1, 1)], 3, 2));
        this.Representations.Enqueue(new ([(1, 0), (1, 1), (1, 2), (0, 1)], 2, 3));
        this.Representations.Enqueue(new ([(0, 1), (1, 1), (2, 1), (1, 0)], 3, 2));
        this.Representations.Enqueue(new ([(0, 0), (0, 1), (0, 2), (1, 1)], 2, 3));
    }
}
