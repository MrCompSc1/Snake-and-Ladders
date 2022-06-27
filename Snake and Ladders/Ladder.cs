internal class Ladder : Object
{
    private static int nextLadderNum = 1;
    public int LadderNum { get; }

    public Ladder(int startCell, int endCell) : base(startCell, endCell)
    {
        BoardSymbol = 'L';
        LadderNum = nextLadderNum;
        nextLadderNum++;
    }
}