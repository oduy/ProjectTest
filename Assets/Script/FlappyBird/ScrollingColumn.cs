using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollingColumn : MonoBehaviour
{
    public float speed = 5f;

    public enum STAGEColumn{SCROLLING, STOP, DELETE};
    private STAGEColumn currentSTAGE= STAGEColumn.SCROLLING;

    public STAGEColumn CurrentSTAGE { get => currentSTAGE; set => currentSTAGE = value; }

    void Update()
    {
        
        switch(CurrentSTAGE){
            case STAGEColumn.SCROLLING:{
                stageScrolling();
                break;
            }
            case STAGEColumn.STOP:{

                break;
            }
            case STAGEColumn.DELETE:{
                Destroy(gameObject);
                break;
            }
        }
        print(currentSTAGE);
        
    }

    void stageScrolling(){
        if(GameController.controller.CurrentState == GameController.STATE.PLAY)
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        
        else{
            currentSTAGE= STAGEColumn.STOP;
        }

        
    }
    


    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.tag != "Player"){
            Destroy(gameObject);
        }
        GameController.controller.Score++;
    }
}
