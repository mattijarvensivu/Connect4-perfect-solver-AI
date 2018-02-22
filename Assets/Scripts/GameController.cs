using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class GameController : MonoBehaviour
{
    private Color playerSide;
    private Color opponentSide;
    private Color currentturn;
    private Ai Ai;
    public Text WinText;
    public Text XCounter;
    public Text OCounter;
    public Text TieCounter;
    public Button restartButton;
    public Button undoButton;
    public Button[] dropButtons = new Button[6];
    public int xcounter;
    public int ocounter;
    public int tiecounter;
    public Rows[] visualboard = new Rows[6];
    public int[] moves;
    public Bitboard bitboards = new Bitboard();


    void Start()
    {
        Ai Ai_ = new Ai();
        Ai = Ai_;
        undoButton.onClick.AddListener(() => undoMove());
        for (int i = 0; i < dropButtons.Length; i++)
        {
            int capturedIterator = i;
            dropButtons[i].onClick.AddListener(() => MakeMove(capturedIterator));
        }

    }
    private void undoMove()
    {
        bitboards.undoMove();
    }
    private void MakeMove(int columnindex)
    {
      
        bitboards.makebitboardMove(columnindex); 
        
        for (int i = 0; i<6; i++)
        {
            if(visualboard[i].rows[columnindex].spot.color==Color.blue || visualboard[i].rows[columnindex].spot.color == Color.red)
            {

                if (i > 0)
                {
                
                    visualboard[i-1].rows[columnindex].spot.color = currentturn;
                    break;
                }
              

            }
            if (i == 5)
            {
                visualboard[i].rows[columnindex].spot.color = currentturn;

            }
        }
       
        CheckFullRows();
        ChangeSides();

    }


    private void CheckFullRows()
    {
        for (int i = 0; i < 7; i++){
            for(int j = 0; j< 6; j++)
            {
                if (j == 0)
                {
                    if (visualboard[j].rows[i].spot.color == Color.red || visualboard[j].rows[i].spot.color == Color.blue)
                    {
                        dropButtons[i].interactable = false;
                    }
                }
               
            }
        }
    }


   
    void RestartClick()
    {


    }
   
    void Awake()
    {

        currentturn = Color.red;
        playerSide = Color.red;
        opponentSide = Color.blue;



    }


    public Color GetPlayerSide()
    {
        return currentturn;
    }

    public void EndTurn()
    {
        
 

    }

    void ChangeSides()
    {
        currentturn = (currentturn == Color.red) ? Color.blue : Color.red;
        if (currentturn == Color.blue)
        {
            AiTurn();
        }

    }
    public void AiTurn()
    {
      
        
        EndTurn();

    }
    public void GameOver()
    {
       /* for (int i = 0; i < buttonlist.Length; i++)
        {
            buttonlist[i].GetComponentInParent<Button>().interactable = false;
        }
        */
        Application.Quit();
    }
}