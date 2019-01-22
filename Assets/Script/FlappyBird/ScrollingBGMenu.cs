using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollingBGMenu : MonoBehaviour
{
    public float speedScrolling = 5f;
    private float sizeOfGround = 20f;

    public Text HightScoreText;
    
    
    void Start(){
        
    }

    void Update(){
        if(Time.timeScale == 0)
        {
            Time.timeScale = 1;
        }

        if(-sizeOfGround > transform.position.x)
        {
            Reposition();
        }
        transform.Translate(Vector2.left* speedScrolling * Time.deltaTime);
        HightScoreText.text = SaveHightScore.HightScore.getScore().ToString();
    }
    void Reposition(){
        Vector2 offer = new  Vector2(sizeOfGround* 2f, 0 ); 
        transform.position = (Vector2)transform.position + offer;
    }
}
