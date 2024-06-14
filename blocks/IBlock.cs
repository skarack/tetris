
namespace tetris.blocks;

class IBlock : Block
{
    public IBlock()
    {
        this.Representations.Enqueue(new ([(0, 0), (0, 1), (0, 2), (0, 3)], 1, 4));
        this.Representations.Enqueue(new ([(0, 0), (1, 0), (2, 0), (3, 0)], 4, 1));
    }
}
