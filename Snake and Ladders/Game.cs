internal class Game
{
    private readonly List<Player> players;
    private readonly Dice dice;
    private readonly Board gameBoard;
    
    public Game()
    {
        players = new();
        dice = new();
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
        int currentPlayer = 0, cellsToMove;
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
        currentPlayer = -1;

        do
        {
            currentPlayer = (currentPlayer + 1) % players.Count;
            Console.WriteLine($"Player {currentPlayer + 1} press any key to roll...");
            Console.ReadKey();

            cellsToMove = dice.Roll();
            Console.WriteLine($"You rolled {cellsToMove}");
            Console.ReadKey();

            if (players[currentPlayer].Cell + cellsToMove <= gameBoard.BoardSize - 1)
            {
                gameBoard.RemovePlayer(players[currentPlayer], players[currentPlayer].Cell);
                players[currentPlayer].Cell = players[currentPlayer].Cell + cellsToMove;
                gameBoard.MovePlayer(players[currentPlayer], players[currentPlayer].Cell);
            }
            else
            {
                Console.WriteLine("Must have an exact roll, sorry!");
                Console.ReadKey();
            }
            
            Console.Clear();
            gameBoard.Display();
        } while (!gameBoard.WinningPlayer());

        Console.WriteLine($"\nPlayer {currentPlayer + 1} wins!!!!");
    }

    private void AddPlayer(int playerNumber)
    {
        string? reqPlayerName;
        string playerName;
        char playerSymbol;
        
        players.Add(new());

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
        players[playerNumber].Cell = 0;
        gameBoard.MovePlayer(players[playerNumber], 0);
    }
}