namespace tetris.blocks;

class JBlock : Block
{
    public JBlock()
    {
        this.Representations.Enqueue(new ([(1, 0), (1, 1), (0, 2), (1, 2)], 2, 3));
        this.Representations.Enqueue(new ([(0, 0), (0, 1), (1, 1), (2, 1)], 3, 2));
        this.Representations.Enqueue(new ([(0, 0), (1, 0), (0, 1), (0, 2)], 2, 3));
        this.Representations.Enqueue(new ([(0, 0), (1, 0), (2, 0), (2, 1)], 3, 2));
    }
}
