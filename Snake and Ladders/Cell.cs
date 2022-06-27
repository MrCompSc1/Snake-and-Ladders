internal class Cell
{
    private static int nextCellNumber = 1;
    public int CellNumber { get; }
    public bool HasObject { get; private set; }
    private readonly List<Player> playerList;
    public Object? PlacedObject { get; private set; }

    public Cell()
    {
        CellNumber = nextCellNumber;
        nextCellNumber += 1;
        playerList = new();
        HasObject = false;
    }

    public void PlaceObject(Object newObject)
    {
        PlacedObject = newObject;
        HasObject = true;
    }
    
    public void AssignPlayer(Player playerToAdd)
    {
        playerList.Add(playerToAdd);
    }

    public void UnassignPlayer(Player playerToRemove)
    {
        playerList.Remove(playerToRemove);
    }

    public bool HasPlayers()
    {
        bool hasPlayer = false;
        if (playerList.Count > 0)
        {
            hasPlayer = true;
        }
        return hasPlayer;
    }

    public List<Player> PlayersInCell()
    {
        return playerList;
    }
}