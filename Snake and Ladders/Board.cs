internal class Board
{
    private readonly List<Cell> cells = new();
    private readonly Random objectChance;
    public int BoardSize
    {
        get { return cells.Count; }
    }

    public Board(int cellsRequired)
    {
        objectChance = new();
        int endCell;

        for (int i = 1; i <= cellsRequired; i++)
        {
            cells.Add(new Cell());
        }
        for (int i = 2; i <= cellsRequired-11; i++)
        {
            if (objectChance.Next(1, 100) <= 5)
            {
                endCell = objectChance.Next(i+10, cellsRequired - 1);

                if (!cells[i - 1].HasObject && !cells[endCell - 1].HasObject)
                {
                    Ladder newLadder = new(i, endCell);
                    cells[i - 1].PlaceObject(newLadder);
                    cells[endCell - 1].PlaceObject(newLadder);
                }
            }    
        }
        for (int i = 11; i <= cellsRequired - 1; i++)
        {
            if (objectChance.Next(1, 100) <= 10)
            {
                endCell = objectChance.Next(0, i - 10);

                if (!cells[i - 1].HasObject && !cells[endCell - 1].HasObject)
                {
                    Snake newSnake = new(i, endCell);
                    cells[i - 1].PlaceObject(newSnake);
                    cells[endCell - 1].PlaceObject(newSnake);
                }
            }
        }
    }

    public bool WinningPlayer()
    {
        bool winner = false;
        if (cells[BoardSize-1].HasPlayers())
        {
            winner = true;
        }
        return winner;
    }

    public int DestinationCell(int cellNumber)
    {
        // Might be null - need to change
        return cells[cellNumber].PlacedObject!.EndCell-1;
    }

    public bool ObjectInCell(int cellNumber)
    {
        bool hasObject = false;

        if (cells[cellNumber].HasObject)
        {
            hasObject = true;
        }

        return hasObject;
    }

    public void MovePlayer(Player currPlayer, int cellNumber)
    {
        cells[cellNumber].AssignPlayer(currPlayer);
    }

    public void RemovePlayer(Player currPlayer, int cellNumber)
    {
        cells[cellNumber].UnassignPlayer(currPlayer);
    }

    public void Display()
    {
        int cellsDrawn = 0;
        bool fillLeft = true;
        string row1Display = "";
        string row2Display = "";
        string row3Display = "";
        string row4Display = "";
        string playerDisplay = "";

        for (int i = cells.Count; i >= 1; i--)
        {
            if (cellsDrawn == 10)
            {
                Console.WriteLine(row1Display);
                Console.WriteLine(row2Display);
                Console.WriteLine(row3Display);
                Console.WriteLine(row4Display);

                row1Display = "";
                row2Display = "";
                row3Display = "";
                row4Display = "";

                cellsDrawn = 0;
                fillLeft = !fillLeft;
            }

            if (fillLeft)
            {
                row1Display += "----------";
                if (cells[i - 1].HasObject)
                {
                    row2Display += ("|" + (cells[i - 1].CellNumber).ToString()).PadRight(8) + cells[i - 1].PlacedObject!.BoardSymbol + "|";
                }
                else
                {
                    row2Display += ("|" + (cells[i - 1].CellNumber).ToString()).PadRight(9) + "|";
                }
                
                if (cells[i - 1].HasPlayers())
                {
                    foreach (Player playerInCell in cells[i - 1].PlayersInCell())
                    {
                        playerDisplay += playerInCell.Symbol;
                    }
                    row3Display += "|" + playerDisplay.PadRight(8) + "|";
                    playerDisplay = "";
                }
                else
                {
                    row3Display += "|        |";
                } 
                
                row4Display += "----------";
            }
            else
            {
                row1Display = "----------" + row1Display;
                if (cells[i - 1].HasObject)
                {
                    row2Display = ("|" + (cells[i - 1].CellNumber).ToString()).PadRight(8) + cells[i - 1].PlacedObject!.BoardSymbol + "|" + row2Display;
                }
                else
                {
                    row2Display = ("|" + (cells[i - 1].CellNumber).ToString()).PadRight(9) + "|" + row2Display;
                }

                if (cells[i - 1].HasPlayers())
                {
                    foreach (Player playerInCell in cells[i - 1].PlayersInCell())
                    {
                        playerDisplay += playerInCell.Symbol;
                    }
                    row3Display = "|" + playerDisplay.PadRight(8) + "|" + row3Display;
                    playerDisplay = "";
                }
                else
                {
                    row3Display = "|        |" + row3Display;
                }

                row4Display = "----------" + row4Display;
            }

            cellsDrawn += 1;
        }

        // Last row will always be incomplete
        Console.WriteLine(row1Display);
        Console.WriteLine(row2Display);
        Console.WriteLine(row3Display);
        Console.WriteLine(row4Display);
    }
}