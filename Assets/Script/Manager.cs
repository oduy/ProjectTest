using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    public Text text;
    public GameObject btnPlay;
    public GameObject btnReplay;
    public int Time = 5;
    public int numscene = 1;

    public enum State {MENU, GAMEPLAY, GAMEOVER, NULL};
    private State CurrentState = State.MENU;

    void Start(){
        btnReplay.SetActive(false);
    }    

    private bool runOneTime = false;
    void Update()
    {
        switch(CurrentState)
        {
            case State.MENU:{
                btnPlay.SetActive(true);
                break;
            }
            case State.GAMEPLAY:{
                funcGameplay();
                break;
            }

            case State.GAMEOVER:{
                btnReplay.SetActive(true);
                break;
            }
        }
        print(CurrentState);
    }

    

    IEnumerator Timedelay()
    {
        yield return new WaitForSeconds(1f);
        Time--;
        text.text = Time.ToString();
        if (Time > 0)
        {
            StartCoroutine(Timedelay());
        }
    }

    private void funcGameplay(){
        if(!runOneTime){
            Time = 5;
            text.text = Time.ToString();
            btnReplay.SetActive(false);
            btnPlay.SetActive(false);
            StartCoroutine(Timedelay());  
            runOneTime = true;  
        }
        if (Input.GetMouseButtonDown(0))
        {   
            Time = 5;
            if (text != null)
                text.text = Time.ToString();
        }
        if (Time == 0)
        {
            CurrentState = State.GAMEOVER;
        }
    }

    public void funcMenu(){
        runOneTime = false;
        CurrentState = State.GAMEPLAY;
        btnReplay.SetActive(false);
        
    }

    public void funcGameover(){
        CurrentState = State.MENU;
        btnReplay.SetActive(false);
        
    }
    
}
