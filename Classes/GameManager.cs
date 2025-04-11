using UnityEngine;

public class GameManager 
{
    private Connect4Board board;
    
    public GameManager()
    {
        this.board = new Connect4Board();
    }

    public void play()
    {
        MoveResult result;
        do
        {
            result = this.board.makeMove(2, "Red");
        }
        while (!result.success);

        // we have a successful move
        // check to see if that mvove was involved in a winning move
        if(this.theBoard.isWinner(result))
        {
            
        }
    }
}

