using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollingColumn : MonoBehaviour
{
    public float speed = 5f;
    
    void Update()
    {
        if(GameController.controller.CurrentState == GameController.STATE.PLAY)
            transform.Translate(Vector2.left * speed * Time.deltaTime);

    }
    
    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.tag != "Player"){
            Destroy(gameObject);
        }
        GameController.controller.Score++;
    }
}
