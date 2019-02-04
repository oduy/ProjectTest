using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour // state canvas in game
{
    [Header("GameObject Canvas UI")]
    public GameObject UIMenu; //canvas menu
    public GameObject UIInGame; // canvas ingame
    public GameObject UIGameOver; // canvas Gameover

    [Header("Bird")]
    public GameObject Bird;

    [Header("High Score Menu")]
    public Text hightScoreMenu;

    [Header("Pause Panel")]
    public GameObject pausePanel;

    

    public enum UISTAGE {Menu, InGame, GameOver};
    private UISTAGE curSTAGE = UISTAGE.Menu;

    public UISTAGE CurSTAGE { get => curSTAGE; set => curSTAGE = value; }

    void Start(){
        UIMenu.SetActive(false);
        UIInGame.SetActive(false);
        UIGameOver.SetActive(false);
        pausePanel.SetActive(false);
    }
    
    void Update(){
        switch(CurSTAGE){
            case UISTAGE.Menu:{
                FuncMenuStage();
                break;
            }
            case UISTAGE.InGame:{
                FuncIngameStage();
                break;
            }
            case UISTAGE.GameOver:{
                FuncGameOverStage();
                break;
            }
        }
    }

    #region function UI STAGE
    void FuncMenuStage(){
        if(GameController.controller.CurrentState == GameController.STATE.MENU)
        {
            UIMenu.SetActive(true);
            UIInGame.SetActive(false);
            UIGameOver.SetActive(false);
        }
        hightScoreMenu.text = SaveHightScore.HightScore.getScore().ToString();
    }

    void FuncIngameStage(){
        if(GameController.controller.CurrentState == GameController.STATE.PLAY)
        {
            UIInGame.SetActive(true);
            UIMenu.SetActive(false);
            UIGameOver.SetActive(false);
        }
    }

    void FuncGameOverStage(){
        if(GameController.controller.CurrentState == GameController.STATE.END)
        {
            UIGameOver.SetActive(true);
            UIInGame.SetActive(false);
            UIMenu.SetActive(false);

            if(Input.GetMouseButtonDown(0)){
                resetSTATEGAME();

                GameController.controller.CurrentState = GameController.STATE.PLAY;
                CurSTAGE = UISTAGE.InGame;
            }
        }
    }
    #endregion

    void resetSTATEGAME(){
        //delete column to replay game
        foreach(ScrollingColumn p in ScrollingColumn.FindObjectsOfType<ScrollingColumn>())
        p.CurrentSTAGE = ScrollingColumn.STAGEColumn.DELETE;

        //reset bird state
        Bird.transform.ResetTransformation();
        Bird.GetComponent<Player>().CurrentState = Player.Bird.Stand;
        Bird.GetComponent<Animator>().Rebind();
    }

    #region handle all of the button
    public void BtnPlayGame(){
        Player.FindObjectOfType<Player>().CurrentState = Player.Bird.FLy;

        GameController.controller.CurrentState = GameController.STATE.PLAY;
        CurSTAGE = UISTAGE.InGame;
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        pausePanel.SetActive(true);
    } 

    public void ContinueGame()
    {
        Time.timeScale = 1;
        pausePanel.SetActive(false);
    }

    public void Replay(){
        Time.timeScale = 1;
        pausePanel.SetActive(false);
        resetSTATEGAME();
        GameController.controller.CurrentState = GameController.STATE.PLAY;
        CurSTAGE = UISTAGE.InGame;
    }

    public void LoadMenu(){
        Time.timeScale = 1;
        pausePanel.SetActive(false);
        resetSTATEGAME();
        GameController.controller.CurrentState = GameController.STATE.MENU;
        CurSTAGE = UISTAGE.Menu;
    }

    #endregion

}
