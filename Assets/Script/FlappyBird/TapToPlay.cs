using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TapToPlay : MonoBehaviour
{
    public enum stateTEXT{isTrue, isFalse};
    private stateTEXT currentState = stateTEXT.isTrue;

    public float timeToFlicker = 0.5f;
    public Text text;
    bool checkOneTime = false;
    bool isSetFalse = false; // set active false Text 

    public stateTEXT CurrentState { get => currentState; set => currentState = value; }

    void Update(){
        switch(CurrentState){
            case stateTEXT.isTrue:{
                isTrue();
                break;
            }
            case stateTEXT.isFalse:{
                isFalse();
                break;
            }
        }
    }

    void isTrue(){
        if(!checkOneTime){
            Flicker();
            checkOneTime = true;
        }
    }

    void isFalse(){
        if(checkOneTime){
            isSetFalse = true;
            setfalseTapToPlay();
            checkOneTime = false;
        }
    }

    public void Flicker(){
        StartCoroutine(Ficker(timeToFlicker));
    }
    
    IEnumerator Ficker(float time){
        yield return new WaitForSeconds(time);
        if(text.gameObject.activeSelf == true && !isSetFalse)
            text.gameObject.SetActive(false);
        else if(text.gameObject.activeSelf == false && !isSetFalse)
            text.gameObject.SetActive(true);
            
        StartCoroutine(Ficker(time));
    }
    public void setfalseTapToPlay()
    {
        text.gameObject.SetActive(false);
    }
}
