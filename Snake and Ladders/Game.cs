internal class Game
{
    private List<Player> players;
    Board gameBoard;

    public Game()
    {
        players = new List<Player>();
        bool validSize;
        int boardSize;

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

        } while (!validSize || boardSize < 1);

        Console.WriteLine();
        gameBoard = new Board(boardSize);
    }

    public void PlayGame()
    {
        int currentPlayer = 0;
        char morePlayers;
        
        do
        {
            AddPlayer(currentPlayer);
            currentPlayer++;
            Console.Write("\nMore players? (n to stop): ");
            morePlayers = Console.ReadKey().KeyChar;
            Console.WriteLine();

        } while (morePlayers != 'n');

        Console.Clear();
        gameBoard.Display();
    }

    private void AddPlayer(int playerNumber)
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
        gameBoard.MovePlayer(players[playerNumber], 0);
    }
}