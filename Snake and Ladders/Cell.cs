internal class Cell
{
    private static int nextCellNumber = 1;
    public int CellNumber { get; }
    private List<Player> playerList;

    public Cell()
    {
        CellNumber = nextCellNumber;
        nextCellNumber += 1;
        playerList = new List<Player>();
    }

    public void AssignPlayer(Player playerToAdd)
    {
        playerList.Add(playerToAdd);
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