internal class Game
{
    private List<Player> players;

    public Game()
    {
        players = new List<Player>();
    }

    public void PlayGame()
    {
        int boardSize, currentPlayer = 0;
        char morePlayers;
        bool validSize;

        Console.WriteLine("Snakes and Ladders!");
        Console.WriteLine("-------------------");
        
        do
        {
            Console.Write("Please enter size of board: ");
            validSize = int.TryParse(Console.ReadLine(), out boardSize);
            if (!validSize || boardSize < 1)
            {
                Console.WriteLine("Try again.\n");
            }

        }while (!validSize || boardSize < 1);

        Console.WriteLine();
        Board gameBoard = new Board(boardSize);

        do
        {
            addPlayer(currentPlayer);
            Console.Write("\nMore players? (n to stop): ");
            morePlayers = Console.ReadKey().KeyChar;
            Console.WriteLine();

        } while (morePlayers != 'n');

        Console.Clear();
        gameBoard.display();
    }

    private void addPlayer(int playerNumber)
    {
        string? reqPlayerName = "";
        string playerName;
        char playerSymbol;
        
        players.Add(new Player());

        do
        {
            Console.Write($"\nEnter player {playerNumber + 1} name: ");
            reqPlayerName = Console.ReadLine();

            if (reqPlayerName == "")
            {
                Console.WriteLine("Try again.");
            }

        } while (reqPlayerName == "");

        playerName = reqPlayerName + "";

        do
        {
            Console.Write($"Enter player {playerNumber + 1} symbol: ");
            playerSymbol = Console.ReadKey().KeyChar;

            if (playerSymbol == '\n')
            {
                Console.WriteLine("Try again.");
            }

        } while (playerSymbol == '\n');

        players[playerNumber].Name = playerName;
        players[playerNumber].Symbol = playerSymbol;
        playerNumber++;
    }
}