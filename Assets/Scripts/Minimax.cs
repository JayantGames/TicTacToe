using UnityEngine;
using System.Collections;

public class Minimax {
    private int maximizingPlayer;
    private int minimizingPlayer;

    public Minimax()
    {

    }

    public void SetMaximizingPlayer(int p)
    {
        maximizingPlayer = p;
    }

    public void SetMinimizingPlayer(int p)
    {
        minimizingPlayer = p;
    }  

    public Move minimax(Board board, Move move, int depth, int maxDepth, int player)
    {
        if(board.Winner() >= 0)
        {
            move.SetValue(evaluation(board, depth));
        }
        else if(depth == maxDepth)
        {
            move.SetValue(evaluation(board, depth));
        }
        else
        {
            ArrayList movesList = board.GetPossibleMoves();
            if(movesList.Count == 0)
            {
                move.SetValue(evaluation(board, depth));
            }
            else
            {
                if(player == maximizingPlayer)
                {
                    move.SetValue(-1000);
                    foreach(Move m in movesList)
                    {
                        Board newBoard = board.CloneBoard();
                        if (!newBoard.ApplyMove(m, player))
                            continue;

                        Move theMove = minimax(newBoard, m, depth + 1, maxDepth, minimizingPlayer);
                        if (better(theMove.GetValue(), move.GetValue(), player))
                        {
                            move.SetValue(theMove.GetValue());
                            if (player == maximizingPlayer)
                                move.SetMove(theMove);
                        }     
                    }
                }
                else
                {
                    move.SetValue(1000);
                    foreach(Move m in movesList)
                    {
                        Board newBoard = board.CloneBoard();
                        if (!newBoard.ApplyMove(m, player))
                            continue;

                        Move theMove = minimax(newBoard, m, depth + 1, maxDepth, maximizingPlayer);
                        if (better(theMove.GetValue(), move.GetValue(), player))
                        {
                            move.SetValue(theMove.GetValue());
                            if (player == maximizingPlayer)
                                move.SetMove(theMove);
                        }
                            
                    }
                }
            }
        }          
        return move;
    }

    private int evaluation(Board board, int depth)
    {
        int winner = board.Winner();

        if(winner == maximizingPlayer)
        {
            return 10 - depth;
        }
        if(winner == minimizingPlayer)
        {
            return depth - 10;
        }       
        return 0;
    }


    private bool better(int theScore, int bestScore, int player)
    {
        if(player == maximizingPlayer)
        {
            if (theScore > bestScore)
                return true;
            return false;
        }
        else
        {
            if (theScore < bestScore)
                return true;
            return false;
        }
    }
}
