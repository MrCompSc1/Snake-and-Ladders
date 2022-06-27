internal class Snake : Object
{
    private static int nextSnakeNum = 1;
    public int SnakeNum { get; }

    public Snake(int startCell, int endCell) : base(startCell, endCell)
    {
        BoardSymbol = 'S';
        SnakeNum = nextSnakeNum;
        nextSnakeNum++;
    }
}