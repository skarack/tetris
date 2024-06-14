namespace tetris.blocks;

class TBlock : Block
{
    public TBlock()
    {
        // up
        this.Representations.Enqueue(new ([(0, 0), (1, 0), (2, 0), (1, 1)], 3, 2));
        //left
        this.Representations.Enqueue(new ([(1, 0), (1, 1), (1, 2), (0, 1)], 2, 3));
        // down
        this.Representations.Enqueue(new ([(0, 1), (1, 1), (2, 1), (1, 0)], 3, 2));
        //right
        this.Representations.Enqueue(new ([(0, 0), (0, 1), (0, 2), (1, 1)], 2, 3));
    }
}
