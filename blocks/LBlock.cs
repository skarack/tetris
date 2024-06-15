namespace tetris.blocks;

class LBlock : Block
{
    public LBlock()
    {
        this.Representations.Enqueue(new ([(0, 0), (0, 1), (0, 2), (1, 2)], 2, 3));
        this.Representations.Enqueue(new ([(0, 0), (1, 0), (2, 0), (0, 1)], 3, 2));
        this.Representations.Enqueue(new ([(0, 0), (1, 0), (1, 1), (1, 2)], 2, 3));
        this.Representations.Enqueue(new ([(0, 1), (1, 1), (2, 1), (2, 0)], 3, 2));
    }
}
