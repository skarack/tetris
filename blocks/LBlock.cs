namespace tetris.blocks;

class LBlock : Block
{
    public LBlock()
    {
        this.Representations.Enqueue(new ([(0, 0), (0, 1), (0, 2), (1, 2)], 2, 3));
    }
}
