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

    public GameObject bntReplay;
    public GameObject Column;
    public float time = 2f;
    bool oneTime = false;


    //make score
    public Text text;
    int score = 0;

    //state design
    public enum STATE{START, PLAY, END};
    private STATE currentState = STATE.START;

    //property 
    public STATE CurrentState { get => currentState; set => currentState = value; }
    public int Score { get => score; set => score = value; }

    void Start(){
        bntReplay.SetActive(false);
    }

    void Update(){
        switch(CurrentState){
            case STATE.START:{
                startGame();
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


    void startGame(){
        score = 0;
        TapToPlay.FindObjectOfType<TapToPlay>().CurrentState = TapToPlay.stateTEXT.isTrue;
        if(Input.GetMouseButtonDown(0)){
            currentState = STATE.PLAY;
        }
    }

    void playGame(){
        if(!oneTime){
            CloneColumn();
            oneTime = true;
        }
        bntReplay.SetActive(false);
        TapToPlay.FindObjectOfType<TapToPlay>().CurrentState = TapToPlay.stateTEXT.isFalse;
        Player.FindObjectOfType<Player>().CurrentState = Player.Bird.FLy;

        text.text = score.ToString();
    }

    void endGame(){
        bntReplay.SetActive(true);
        if(Input.GetMouseButtonDown(0)){
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
    
    void CloneColumn(){
        StartCoroutine(Clone(time));
    }


    IEnumerator Clone(float time){
        yield return new WaitForSeconds(time);
        float num = Random.Range(-3f, 3f);
        Instantiate(Column, new Vector2(4, num), Quaternion.identity);
        if(currentState == STATE.PLAY)
            StartCoroutine(Clone(time));
    }
}
