﻿internal class Board
{
    private List<Cell> cells = new List<Cell>();

    public Board(int cellsRequired)
    {
        for (int i = 1; i <= cellsRequired; i++)
        {
            cells.Add(new Cell());
        }
    }

    public void MovePlayer(Player currPlayer, int cellNumber)
    {
        cells[cellNumber].AssignPlayer(currPlayer);
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
                row2Display += ("|" + (cells[i - 1].CellNumber).ToString()).PadRight(9) + "|";
                
                if (cells[i - 1].HasPlayers())
                {
                    foreach (Player playerInCell in cells[i - 1].PlayersInCell())
                    {
                        playerDisplay += playerInCell.Symbol;
                    }
                    row3Display += "|" + playerDisplay.PadRight(8) + "|";
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
                row2Display = ("|" + (cells[i - 1].CellNumber).ToString()).PadRight(9) + "|" + row2Display;

                if (cells[i - 1].HasPlayers())
                {
                    foreach (Player playerInCell in cells[i - 1].PlayersInCell())
                    {
                        playerDisplay += playerInCell.Symbol;
                    }
                    row3Display = "|" + playerDisplay.PadRight(8) + "|" + row3Display;
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