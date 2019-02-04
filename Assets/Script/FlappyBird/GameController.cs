using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    #region contruction
    public static GameController controller;
    void Awake(){
        if(controller == null){
            controller = this;
        }
    }
    #endregion

    [Header("Show Score and save high score")]    
    public Text text;
    public Text hightScoreText;
    int score = 0;

    
    public enum STATE{MENU, PLAY, END};
    private STATE currentState = STATE.MENU;

    //property 
    public STATE CurrentState { get => currentState; set => currentState = value; }
    public int Score { get => score; set => score = value; }

    void Update(){
        switch(CurrentState){
            case STATE.MENU:{
                
                break;
            }
            case STATE.PLAY:{
                playGame();
                
                break;
            }
            case STATE.END:{
                endGame();
                break;
            }
        }
        print(currentState);
    }

    void playGame(){

        //spawn column
        ColumnManager.FindObjectOfType<ColumnManager>().Stage = ColumnManager.COLUMN.SPAWN;
        Player.FindObjectOfType<Player>().CurrentState = Player.Bird.FLy;

        // save hight score
        text.text = score.ToString();
        if(score > PlayerPrefs.GetInt("HightScore")){
            SaveHightScore.HightScore.saveScore(score); 
        }

    }

    void endGame(){
        //reset score and show it
        score = 0;
        hightScoreText.text = SaveHightScore.HightScore.getScore().ToString();
        
        //stop spawn column
        ColumnManager.FindObjectOfType<ColumnManager>().Stage = ColumnManager.COLUMN.NOTSPAWN;
    }
    
    

}
