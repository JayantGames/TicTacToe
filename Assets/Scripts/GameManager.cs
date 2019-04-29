using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameManager : MonoBehaviour {
    public GameObject boardUIGO;
    public GameObject gameStatus;

    private Board board;
    private BoardUI boardUI;
    private Text gameStatusText;
    private int humanPlayer;
    private int aiPlayer;
    private bool gameStarted;
    private Minimax minimax;
    private int currentPlayer;

    // Public references
    public GameObject gamePlayCanvas;
    public GameObject mainMenuCanvas;
    public GameObject gameOverCanvas;
    public Dropdown difficultySelectionDropdown;
    public Image winConditionImage;

    // Use this for initialization
    void Start() {
        board = new Board();
        boardUI = boardUIGO.GetComponent<BoardUI>();
        gameStatusText = gameStatus.GetComponent<Text>();
        gameStarted = false;
        minimax = new Minimax();
        currentPlayer = -1;
        enableMainMenuCanvas(); 
    }

    public void SwapCurrentPlayer()
    {
        if (currentPlayer == Board.PLAYER_X)
            currentPlayer = Board.PLAYER_O;
        else
            currentPlayer = Board.PLAYER_X;
    }

    // Update is called once per frame
    void Update() {
        if (gameStarted && currentPlayer == aiPlayer)
        {
            Move m;
            if (difficultySelectionDropdown.value == 0)
            {                                     
                m = minimax.minimax(board, new Move(), 0, 1, aiPlayer);
            }
            else
            {                                          
                m = minimax.minimax(board, new Move(), 0, 7, aiPlayer);
            }

               bool success = board.ApplyMove(m, aiPlayer);
               if (success)
               {
                   boardUI.UpdateBoard(m, board, currentPlayer);
                   CheckWinner();
                   SwapCurrentPlayer();
               }   
        }
    }      

    public void OnClicked(GameObject sender)
    {
        if (gameStarted && currentPlayer == humanPlayer)
        {
            Move m = ConvertToMove(sender.name);
            bool success = board.ApplyMove(m, humanPlayer);
            if (success)
            {
                boardUI.UpdateBoard(m, board, currentPlayer);
                CheckWinner();
                SwapCurrentPlayer();
            }  
        }
    }

    public void SetHumanPlayer(int humanPlayer)
    {
        this.humanPlayer = humanPlayer;
        if (humanPlayer == Board.PLAYER_X)
        {
            aiPlayer = Board.PLAYER_O;
            currentPlayer = humanPlayer;
        }
        else
        {
            aiPlayer = Board.PLAYER_X;
            currentPlayer = aiPlayer;
        }

        minimax.SetMaximizingPlayer(aiPlayer);
        minimax.SetMinimizingPlayer(humanPlayer);
                                                                           
        boardUI.Clear();
        gameStarted = true;
        gameStatusText.text = "";
    }

    private Move ConvertToMove(string name)
    {
        Move m = new Move();

        switch (name)
        {
            case "BoardPos00":
                m = new Move(0, 0); break;
            case "BoardPos01":
                m = new Move(0, 1); break;
            case "BoardPos02":
                m = new Move(0, 2); break;
            case "BoardPos10":
                m = new Move(1, 0); break;
            case "BoardPos11":
                m = new Move(1, 1); break;
            case "BoardPos12":
                m = new Move(1, 2); break;
            case "BoardPos20":
                m = new Move(2, 0); break;
            case "BoardPos21":
                m = new Move(2, 1); break;
            case "BoardPos22":
                m = new Move(2, 2); break;
        }      
        return m;
    }

    private void CheckWinner()
    {
        int winner = board.Winner();
        if (winner == humanPlayer)
        {                                      
            enableGameOverCanvas(humanPlayer);
        }
        else if (winner == aiPlayer)
        {                              
            enableGameOverCanvas(aiPlayer);
        }
        else if (winner == 2)
        {                            
            enableGameOverCanvas(2);
        }
    }

    private void ResetGame()
    {
        gameStarted = false;
        board = new Board();                                                           
    }

    public void enableGamePlayCanvas()
    {
        mainMenuCanvas.SetActive(false);
        gameOverCanvas.SetActive(false);
        SetHumanPlayer(0);
    }               

    public void enableMainMenuCanvas()
    {                   
        mainMenuCanvas.SetActive(true);
        gameOverCanvas.SetActive(false); 
    }

    public void enableGameOverCanvas(int state)
    {
        gameOverCanvas.SetActive(true);
        switch (state)
        {
            case 0:
                {
                    winConditionImage.sprite = Resources.Load<Sprite>("WinImage");
                    break;
                }
            case 1:
                {
                    winConditionImage.sprite = Resources.Load<Sprite>("LoseImage");
                    break;
                }
            case 2:
                {
                    winConditionImage.sprite = Resources.Load<Sprite>("DrawImage");
                    break;
                }
        }
        ResetGame();
    }
}
