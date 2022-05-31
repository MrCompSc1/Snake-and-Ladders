internal class Cell
{
    private static int nextCellNumber = 1;
    public int CellNumber { get; }

    public Cell()
    {
        CellNumber = nextCellNumber;
        nextCellNumber += 1;
    }
}