namespace tetris;

using tetris.blocks;

public class Playfield
{
    private const int PLAYFIELD_WIDTH = 10;
    private const int PLAYFIELD_HEIGHT = 16;

    public delegate Block NewBlockNeeded();
    public delegate void RowsDeleted(int row_count);

    private bool[,] fieldMatrix;

    private int position_x;
    private int position_y;

    private Block? current_block;
    private int block_position_x;
    private int block_position_y;

    private DateTime last_update_tick;

    public Playfield(int x, int y)
    {
        this.position_x = x;
        this.position_y = y;

        this.fieldMatrix = new bool[PLAYFIELD_HEIGHT, PLAYFIELD_WIDTH];
    }

    public NewBlockNeeded? OnNewBlockNeeded { get; set; }

    public RowsDeleted? OnRowsDeleted {get; set;}

    public void Update()
    {
        if (this.current_block is null)
        {
            this.RequestNewBlock();
        }

        this.Draw();
    }

    private void Draw()
    {
        const int width = 10;
        const int height = 16;

        for (int row = 0; row < height; row++)
        {
            for (int col = 0; col < width; col++)
            {
                var isFilled = this.fieldMatrix[row, col];
                Pixel.Draw(this.position_x + col, this.position_y + row, isFilled ? ConsoleColor.White : ConsoleColor.DarkGray);
            }
        }

        this.ProcessInput();
        this.DropBlock();

        this.current_block?.Draw(this.block_position_x, this.block_position_y);
    }

    private void ConvertBlockToMatrix()
    {
        if (this.current_block is null)
        {
            return;
        }

        var block_vertices = this.current_block.CurrentRepresentation.Vertices;
        foreach ((int x, int y) vertex in block_vertices)
        {
            var row = (this.block_position_y + vertex.y) - this.position_y;
            var col = (this.block_position_x + vertex.x) - this.position_x;
            this.fieldMatrix[row, col] = true;
        }
    }

    private bool DetectCollision(int x, int y)
    {
        if (this.current_block is null)
        {
            return false;
        }

        var block_vertices = this.current_block.CurrentRepresentation.Vertices;
        foreach ((int x, int y) vertex in block_vertices)
        {
            var row = (y + vertex.y) - this.position_y;
            var col = (x + vertex.x) - this.position_x;
            if (this.fieldMatrix[row, col])
            {
                return true;
            }
        }

        return false;
    }

    private void DropBlock()
    {
        if (this.current_block is null)
        {
            return;
        }

        //if (DateTime.Now.Subtract(this.last_update_tick).TotalMilliseconds < 750)
        if (DateTime.Now.Subtract(this.last_update_tick).TotalMilliseconds < 200)
        {
            return;
        }

        if (this.block_position_y + this.current_block.CurrentRepresentation.Height < this.position_y + PLAYFIELD_HEIGHT)
        {
            var next_y_position = this.block_position_y + 1;
            if (!this.DetectCollision(this.block_position_x, next_y_position))
            {
                this.block_position_y += 1;
                this.last_update_tick = DateTime.Now;
                return;
            }

        }

        this.ConvertBlockToMatrix();

        this.RequestNewBlock();
    }

    private void ProcessInput()
    {
        if (this.current_block is null || !Console.KeyAvailable)
        {
            return;
        }

        var key = Console.ReadKey();
        switch(key.Key)
        {
            case ConsoleKey.LeftArrow: 
                if (this.block_position_x > this.position_x)
                {
                    this.block_position_x -= 1;
                }
                break;
            case ConsoleKey.RightArrow:
                if (this.block_position_x + this.current_block.CurrentRepresentation.Width < this.position_x + PLAYFIELD_WIDTH)
                {
                    this.block_position_x += 1;
                }
                break;
            case ConsoleKey.UpArrow:
                this.current_block.Rotate();
                break;
        }
    }
    
    private void RequestNewBlock()
    {
        if (this.OnNewBlockNeeded is null)
        {
            return;
        }

        this.current_block = this.OnNewBlockNeeded();
        this.block_position_x = this.position_x + (PLAYFIELD_WIDTH/2 - (int)Math.Ceiling(this.current_block.CurrentRepresentation.Width/2.0));
        this.block_position_y = this.position_y;
        this.last_update_tick = DateTime.Now;
    }
}
