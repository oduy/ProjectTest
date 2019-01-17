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

    void Start(){
        if(text != null)
            text.text = Time.ToString();
        StartCoroutine(Timedelay());

        
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0)){
            Time = 10;
            if(text != null)
            text.text = Time.ToString();
        }
        if(Time == 0)
        {
            SceneManager.LoadScene(numscene);
        }
    }



    IEnumerator Timedelay()
    {
        yield return new WaitForSeconds(1);
        Time--;
        text.text = Time.ToString();
        if(Time > 0){
            StartCoroutine(Timedelay());
        }
    }
}
