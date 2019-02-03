using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingBackground : MonoBehaviour
{
    private BoxCollider2D box;
    private Rigidbody2D rb2d;
    private float lenght;
    [SerializeField]
    private float speed;

    bool callRunBackGroundOneTime = false;

    void Start(){
        box = GetComponent<BoxCollider2D>();
        rb2d = GetComponent<Rigidbody2D>();

        lenght = box.size.x;
        
    }

    void Update()
    {
        if(GameController.controller.CurrentState == GameController.STATE.END){
            rb2d.velocity = Vector2.zero;
        }
        
        if(GameController.controller.CurrentState == GameController.STATE.MENU ||
            GameController.controller.CurrentState == GameController.STATE.PLAY)
            StartGame();

    }

    void StartGame(){
        if(!callRunBackGroundOneTime){
            rb2d.velocity = new Vector2(-1 , 0);
            callRunBackGroundOneTime = true;
        }    
        if(transform.position.x < -lenght){
            RepositionBackground();
        }
    }

    void RepositionBackground(){
        Vector2 offset = new Vector2(lenght * 2f, 0);
        transform.position = (Vector2)transform.position + offset;
    }
}
