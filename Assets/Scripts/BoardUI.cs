using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BoardUI : MonoBehaviour {
    public GameObject boardPos00;
    public GameObject boardPos01;
    public GameObject boardPos02;
    public GameObject boardPos10;
    public GameObject boardPos11;
    public GameObject boardPos12;
    public GameObject boardPos20;
    public GameObject boardPos21;
    public GameObject boardPos22;        
                      
    private Image[,] boardPosImage;
    public Sprite xSprite;
    public Sprite oSprite;

    public static BoardUI Instance;

    private void Awake()
    {
        Instance = this;
    }

    // Use this for initialization
    void Start () {
        
        boardPosImage = new Image[3, 3];
        boardPosImage[0, 0] = boardPos00.GetComponent<Image>();
        boardPosImage[0, 1] = boardPos01.GetComponent<Image>();
        boardPosImage[0, 2] = boardPos02.GetComponent<Image>();
        boardPosImage[1, 0] = boardPos10.GetComponent<Image>();
        boardPosImage[1, 1] = boardPos11.GetComponent<Image>();
        boardPosImage[1, 2] = boardPos12.GetComponent<Image>();
        boardPosImage[2, 0] = boardPos20.GetComponent<Image>();
        boardPosImage[2, 1] = boardPos21.GetComponent<Image>();
        boardPosImage[2, 2] = boardPos22.GetComponent<Image>();

        xSprite = Resources.Load<Sprite>("xSprite");
        oSprite = Resources.Load<Sprite>("oSprite");   
    }     

    public void UpdateBoard(Move m, Board board, int currentPlayer)
    {
        if(currentPlayer == Board.PLAYER_X)
        {                                                           
            boardPosImage[m.GetRow(), m.GetColumn()].sprite = xSprite;
        }
        else
        {                                                          
            boardPosImage[m.GetRow(), m.GetColumn()].sprite = oSprite;
        }
    }

    public void Clear()
    {  
        for(int i = 0; i < 3; i++)
        {
            for(int j = 0; j < 3; j++)
            {                                      
                boardPosImage[i, j].sprite = null;
            }
        }
    }
}
