using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    public Button[] dropButtons = new Button[6];
    // int number = 0;
    public int xcounter;
    public int ocounter;
    public int tiecounter;
    public Rows[] visualboard = new Rows[6];



    private void MakeMove(int columnindex)
    {
        Debug.Log(columnindex);
        
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


    void Start()
    {
        Ai Ai_ = new Ai();
        Ai = Ai_;
       
            for (int i = 0; i < dropButtons.Length; i++)
            {
                int capturedIterator = i;
                dropButtons[i].onClick.AddListener(() => MakeMove(capturedIterator));
            }
        
       // restartButton.onClick.AddListener(RestartClick);

        // AiTurn();

    }
    void RestartClick()
    {
      /*  for (int i = 0; i < buttonlist.Length; i++)
        {
            buttonlist[i].GetComponentInParent<Button>().interactable = true;
            buttonlist[i].text = "";
        }
        WinText.text = "";
        currentturn = Color.red;
*/


    }
    /*public void SetGameControllerReferenceButtons()
    {
        for (int i = 0; i < buttonlist.Length; i++)
        {
            buttonlist[i].GetComponentInParent<GridSpace>().SetGameControllerReference(this);

        }
    }*/
    void Awake()
    {

        //SetGameControllerReferenceButtons();
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
        
       //if end  
        //else { ChangeSides(); }

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
        //int aichoice = Ai.Aiturn(buttonlist, "O", "X");
       // int aichoice = Ai.findBestMove(buttonlist);
        // Debug.Log(aichoice);
        //buttonlist[aichoice].GetComponentInParent<Button>().interactable = false;
        //buttonlist[aichoice].text = "O";


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