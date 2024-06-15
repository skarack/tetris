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
        this.RemoveFullLines();

        this.RequestNewBlock();
    }

    private void RemoveFullLines()
    {
        int line_reset_count = 0;

        for (var row = PLAYFIELD_HEIGHT - 1; row >= 0 ; row--)
        {
            if (!this.IsLineFull(row))
            {
                continue;
            }

            this.ResetLine(row);
            line_reset_count++;
        }

        if (line_reset_count > 0)
        {
            this.OnRowsDeleted?.Invoke(line_reset_count);
            this.DropLines();
        }
    }

    private void CopyLine(int src, int dst)
    {
        for (var col = 0; col < PLAYFIELD_WIDTH; col++)
        {
            this.fieldMatrix[dst, col] = this.fieldMatrix[src, col];
        }
    }

    private void DropLines()
    {
        for (var row = PLAYFIELD_HEIGHT - 2; row >= 0 ; row--)
        {
            int dst_row = row;
            int next_row = row + 1;

            while (next_row != PLAYFIELD_HEIGHT && this.IsLineEmpty(next_row))
            {
                dst_row = next_row;
                next_row++;
            }

            if (row != dst_row)
            {
                this.CopyLine(row, dst_row);
                this.ResetLine(row);
            }
        }
    }

    private bool IsLineEmpty(int row)
    {
        for (var col = 0; col < PLAYFIELD_WIDTH; col++)
        {
            if (this.fieldMatrix[row, col])
            {
                return false;
            }
        }

        return true;
    }

    private bool IsLineFull(int row)
    {
        for (var col = 0; col < PLAYFIELD_WIDTH; col++)
        {
            if (!this.fieldMatrix[row, col])
            {
                return false;
            }
        }

        return true;
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
                    var next_x_position = this.block_position_x - 1;
                    if (!this.DetectCollision(next_x_position, this.block_position_y))
                    {
                        this.block_position_x -= 1;
                    }
                }
                break;
            case ConsoleKey.RightArrow:
                if (this.block_position_x + this.current_block.CurrentRepresentation.Width < this.position_x + PLAYFIELD_WIDTH)
                {
                    var next_x_position = this.block_position_x + 1;
                    if (!this.DetectCollision(next_x_position, this.block_position_y))
                    {
                        this.block_position_x += 1;
                    }
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

    private void ResetLine(int row)
    {
        for (var col = 0; col < PLAYFIELD_WIDTH; col++)
        {
            this.fieldMatrix[row, col] = false;
        }
    }
}
