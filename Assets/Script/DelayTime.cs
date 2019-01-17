using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DelayTime : MonoBehaviour
{
    public Text text;
    public int Time = 10;
    public int numscene = 1;

    void Start()
    {
        if (text != null)
            text.text = Time.ToString();
    }

    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            if (Manager.CurrentState == Manager.State.MENU)
            {
                StartCoroutine(Timedelay());
                Manager.CurrentState = Manager.State.GAMEPLAY;
            }
            Time = 10;
            if (text != null)
                text.text = Time.ToString();
        }
        if (Time == 0)
        {
            //  Manager.CurrentState = Manager.State.START;
        }
    }



    IEnumerator Timedelay()
    {
        yield return new WaitForSeconds(1);
        Time--;
        text.text = Time.ToString();
        if (Time > 0)
        {
            StartCoroutine(Timedelay());
        }
    }
}
