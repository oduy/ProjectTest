using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    

    public enum State {MENU, GAMEPLAY, NULL};
    public static  State CurrentState;


    void Start(){
        CurrentState= State.MENU;
    }

    void Update()
    {
        switch(CurrentState)
        {
            case State.MENU:{
               // SceneManager.LoadScene(0);
               
                break;
            }
            case State.GAMEPLAY:{
               // SceneManager.LoadScene(1);
                print("run gameplay");
                break;
            }
            case State.NULL:{

                break;
            }
        }
        print(CurrentState);
    }



    
}
