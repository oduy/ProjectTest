using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float upForce;
    private Animator anim;
    private Rigidbody2D rb2d;
    bool runOneBirdFly = false;

    public enum Bird { Stand, FLy, Die };
    private Bird currentState = Bird.Stand;

    public Bird CurrentState { get => currentState; set => currentState = value; }

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

    }

    void Update()
    {
        switch (currentState)
        {
            case Bird.Stand:
                {
                    BirdStand();
                    break;
                }
            case Bird.FLy:
                {
                    BirdFly();
                    break;
                }
            case Bird.Die:
                {
                    BirdEnd();
                    break;
                }
        }
        print(currentState);
    }

    void BirdStand()
    {
        rb2d.velocity = Vector2.zero;
        rb2d.isKinematic = true;
        
    }

    void BirdFly()
    {   
        if (!runOneBirdFly)
        {
            rb2d.isKinematic = false;
            runOneBirdFly = true;
            transform.position = Vector2.zero;
        }

        if (Input.GetMouseButtonDown(0) && Time.timeScale != 0)
        {
            anim.SetTrigger("Flap");
            rb2d.velocity = Vector2.zero;
            rb2d.AddForce(new Vector2(0, upForce));
        }

    }

    void BirdEnd(){
        runOneBirdFly = false;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        rb2d.velocity = Vector2.zero;
        currentState = Bird.Die;
        GameController.controller.CurrentState = GameController.STATE.END;
        CanvasManager.FindObjectOfType<CanvasManager>().CurSTAGE = CanvasManager.UISTAGE.GameOver;
        anim.SetTrigger("Die");
    }



}
