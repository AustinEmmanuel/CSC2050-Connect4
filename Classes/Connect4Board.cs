using UnityEngine;

public class Connect4Board 
{
    private Checker[][] theBoard; 

    private int rows = 6;
    private int columns = 7;

    public Connect4Board()
    {
        this.theBoard = new Checker[this.rows][];
        for (int i = 0; i < this.theBoard.Length; i++)
        {
            this.theBoard[i] = new Checker[this.columns];
        }
    }

    public bool isWinner(MoveResult result)
    {
        if (!result.success)
        {
            return false; // No valid move, no winner
        }

        string color = result.color;
        int row = result.row;
        int column = result.column;

        // Check horizontal
        int count = 0;
        for (int c = 0; c < columns; c++)
        {
            if (theBoard[row][c]?.GetColor() == color)
            {
                count++;
                if (count == 4) return true;
            }
            else
            {
                count = 0;
            }
        }

        // Check vertical
        count = 0;
        for (int r = 0; r < rows; r++)
        {
            if (theBoard[r][column]?.GetColor() == color)
            {
                count++;
                if (count == 4) return true;
            }
            else
            {
                count = 0;
            }
        }

        // Check diagonal (bottom-left to top-right)
        count = 0;
        int startRow = row;
        int startCol = column;
        while (startRow > 0 && startCol > 0)
        {
            startRow--;
            startCol--;
        }
        while (startRow < rows && startCol < columns)
        {
            if (theBoard[startRow][startCol]?.GetColor() == color)
            {
                count++;
                if (count == 4) return true;
            }
            else
            {
                count = 0;
            }
            startRow++;
            startCol++;
        }

        // Check diagonal (top-left to bottom-right)
        count = 0;
        startRow = row;
        startCol = column;
        while (startRow < rows - 1 && startCol > 0)
        {
            startRow++;
            startCol--;
        }
        while (startRow >= 0 && startCol < columns)
        {
            if (theBoard[startRow][startCol]?.GetColor() == color)
            {
                count++;
                if (count == 4) return true;
            }
            else
            {
                count = 0;
            }
            startRow--;
            startCol++;
        }

        return false; // No winner found
    }

    public MoveResult makeMove(int column, string color)
    {
        MoveResult result = new MoveResult();

        if(column < 0 || column > this.columns - 1)
        {
            return result; // Invalid column
        }

        if(this.theBoard[0][column] != null)
        {
            return result; // Column is full
        }

        // a legal move and room for a new checker, so drop the checker into the board
        for (int i = this.rows - 1; i >= 0; i--)
        {
            if(this.theBoard[i][column] == null)
            {
                this.theBoard[i][column] = new Checker(color); // Assuming Checker has a default constructor
                result.success = true;
                result.row = i;
                result.column = column;
                result.color = color;
                break;
            }
        }
        // Check for a win condition
        return result;

    }
}

