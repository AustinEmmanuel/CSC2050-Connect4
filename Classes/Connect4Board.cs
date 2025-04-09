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

    public bool makeMove(int column, string color)
    {
        if(column < 0 || column > this.columns - 1)
        {
            return false; // Invalid column
        }

        if(this.theBoard[0][column] != null)
        {
            return false; // Column is full
        }

        // a legal move and room for a new checker, so drop the checker into the board
        for (int i = this.rows - 1; i >= 0; i--)
        {
            if(this.theBoard[i][column] == null)
            {
                this.theBoard[i][column] = new Checker(color); // Assuming Checker has a default constructor
                break;
            }
        }
        // Check for a win condition
        return true;

    }
}

