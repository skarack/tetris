namespace tetris.blocks;

class ZBlock : Block
{
    public ZBlock()
    {
        this.Representations.Enqueue(new ([(0, 0), (1, 0), (1, 1), (2, 1)], 3, 2));
        this.Representations.Enqueue(new ([(1, 0), (1, 1), (0, 1), (0, 2)], 2, 3));
    }
}
