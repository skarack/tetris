namespace tetris.blocks;

class JBlock : Block
{
    public JBlock()
    {
        this.Representations.Enqueue(new ([(1, 0), (1, 1), (0, 2), (1, 2)], 2, 3));
    }
}
