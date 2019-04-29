using System.Collections;
using UnityEngine;

public class Board {
    private int[,] board;

    public const int PLAYER_X = 0;
    public const int PLAYER_O = 1;

    public Board()
    {
        board = new int[3,3];
        for (int i = 0; i < 3; i++)
            for (int j = 0; j < 3; j++)
                board[i, j] = -1;
    }


    public Board CloneBoard()
    {
        Board b = new Board();
        b.SetBoard((int[,])this.board.Clone());
        return b;
    }

    public void SetBoard(int[,] b)
    {
        this.board = b;
    }

    public int[,] GetBoard()
    {
        return board;
    }

    public ArrayList GetPossibleMoves()
    {
        ArrayList moves = new ArrayList();

        for(int i = 0; i < 3; i++)
        {
            for(int j = 0; j < 3; j++)
            {
                if (board[i, j] == -1)
                    moves.Add(new Move(i, j));
            }
        }
        return moves;
    }

    public bool ApplyMove(Move m, int player)
    {
        int i = m.GetRow();
        int j = m.GetColumn();
        if(board[i, j] == -1)
        {
            board[i, j] = player;
            return true;
        }
        return false;
    }

    public override string ToString()
    {
        string res = "";
        for(int i = 0; i < 3; i++)
        {
            for(int j = 0; j < 3; j++)
            {
                res += board[i, j] + " ";
            }
            res += "\n";
        }

        return res;
    }

    public int Winner()
    {

        if (board[0, 0] == PLAYER_X && board[0, 1] == PLAYER_X && board[0, 2] == PLAYER_X)
            return PLAYER_X;

        if (board[1, 0] == PLAYER_X && board[1, 1] == PLAYER_X && board[1, 2] == PLAYER_X)
            return PLAYER_X;

        if (board[2, 0] == PLAYER_X && board[2, 1] == PLAYER_X && board[2, 2] == PLAYER_X)
            return PLAYER_X;

        if (board[0, 0] == PLAYER_X && board[1, 0] == PLAYER_X && board[2, 0] == PLAYER_X)
            return PLAYER_X;

        if (board[0, 1] == PLAYER_X && board[1, 1] == PLAYER_X && board[2, 1] == PLAYER_X)
            return PLAYER_X;

        if (board[0, 2] == PLAYER_X && board[1, 2] == PLAYER_X && board[2, 2] == PLAYER_X)
            return PLAYER_X;

        if (board[0, 0] == PLAYER_X && board[1, 1] == PLAYER_X && board[2, 2] == PLAYER_X)
            return PLAYER_X;

        if (board[0, 2] == PLAYER_X && board[1, 1] == PLAYER_X && board[2, 0] == PLAYER_X)
            return PLAYER_X;

        ///////////////////////////////////////

        if (board[0, 0] == PLAYER_O && board[0, 1] == PLAYER_O && board[0, 2] == PLAYER_O)
            return PLAYER_O;

        if (board[1, 0] == PLAYER_O && board[1, 1] == PLAYER_O && board[1, 2] == PLAYER_O)
            return PLAYER_O;

        if (board[2, 0] == PLAYER_O && board[2, 1] == PLAYER_O && board[2, 2] == PLAYER_O)
            return PLAYER_O;

        if (board[0, 0] == PLAYER_O && board[1, 0] == PLAYER_O && board[2, 0] == PLAYER_O)
            return PLAYER_O;

        if (board[0, 1] == PLAYER_O && board[1, 1] == PLAYER_O && board[2, 1] == PLAYER_O)
            return PLAYER_O;

        if (board[0, 2] == PLAYER_O && board[1, 2] == PLAYER_O && board[2, 2] == PLAYER_O)
            return PLAYER_O;

        if (board[0, 0] == PLAYER_O && board[1, 1] == PLAYER_O && board[2, 2] == PLAYER_O)
            return PLAYER_O;

        if (board[0, 2] == PLAYER_O && board[1, 1] == PLAYER_O && board[2, 0] == PLAYER_O)
            return PLAYER_O;

        //////////////////////////////////////

        int emptySpots = 0;
        for(int i = 0; i < 3; i++)
        {
            for(int j = 0; j < 3; j++)
            {
                if (board[i, j] == -1)
                    emptySpots++;
            }
        }
        if(emptySpots == 0)
            return 2; //draw

        return -1;
    }   
}