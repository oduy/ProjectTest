using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasManager : MonoBehaviour // state canvas in game
{
    [Header("GameObject Canvas UI")]
    public GameObject UIMenu; //canvas menu
    public GameObject UIInGame; // canvas ingame
    public GameObject UIGameOver; // canvas Gameover

    [Header("Bird")]
    public GameObject Bird;
    

    public enum UISTAGE {Menu, InGame, GameOver};
    private UISTAGE curSTAGE = UISTAGE.Menu;

    public UISTAGE CurSTAGE { get => curSTAGE; set => curSTAGE = value; }

    void Start(){
        UIMenu.SetActive(false);
        UIInGame.SetActive(false);
        UIGameOver.SetActive(false);
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
                GameController.controller.CurrentState = GameController.STATE.PLAY;
                CurSTAGE = UISTAGE.InGame;

                //reset 
                Bird.transform.ResetTransformation();
                Bird.GetComponent<Animator>().Rebind();
            }
        }
    }
    #endregion

    #region function of Button
    public void BtnPlayGame(){
        GameController.controller.CurrentState = GameController.STATE.PLAY;
        CurSTAGE = UISTAGE.InGame;
    }

    

    #endregion

}
