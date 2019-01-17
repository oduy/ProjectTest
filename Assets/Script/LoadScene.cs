using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public float time = 2f;
    public int numscene = 1;

    bool oneTime = false;

    // void Start()
    // {
    //     StartCoroutine(Timedelay(time));
    // }

    void Update(){
        if(!oneTime){
            StartCoroutine(Timedelay(time));
            oneTime = true;
        }
    }

    IEnumerator Timedelay(float time)
    {
        yield return new WaitForSeconds(time);
        Manager.CurrentState = Manager.State.GAMEPLAY;
        print("a" + Manager.CurrentState);
    }

}
