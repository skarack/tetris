namespace tetris;

public static class Pixel
{
    private const int PIXEL_WIDTH = 2;
    private const int PIXEL_HEIGHT = 1;

    public static void Draw(int x, int y, ConsoleColor color = ConsoleColor.White)
    {
        (int x, int y) mappedLocation = MapPositionToPixel(x, y);
        Console.BackgroundColor = color;

        for (int py = 0; py < PIXEL_HEIGHT; py++)
        {
            for (int px = 0; px < PIXEL_WIDTH; px++)
            {
                Console.SetCursorPosition(mappedLocation.x + px, mappedLocation.y + py);
                Console.WriteLine(" ");
            }
        }

        Console.ResetColor();
    }

    private static (int, int) MapPositionToPixel(int x, int y)
    {
        return (x * PIXEL_WIDTH - PIXEL_WIDTH, y * PIXEL_HEIGHT - PIXEL_HEIGHT);
    }
}
