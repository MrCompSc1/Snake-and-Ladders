internal class Player
{
    public char Symbol { get; set; }
    public string Name { get; set; }
    public int Cell { get; set; }
    public int PlayerNumber { get; }
    private static int nextPlayerNumber = 1;

    public Player()
    {
        Name = "";
        Symbol = '\0';
        PlayerNumber = nextPlayerNumber;
        nextPlayerNumber++;
    }
}