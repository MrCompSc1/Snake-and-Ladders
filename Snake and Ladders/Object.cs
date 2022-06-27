internal abstract class Object
{
    public int StartCell { get; }
    public int EndCell { get; }
    public char BoardSymbol { get; protected set; }

    public Object(int startCell, int endCell)
    {
        StartCell = startCell;
        EndCell = endCell;
    }   
}