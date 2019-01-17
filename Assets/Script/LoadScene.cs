using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public float time = 2f;
    public int numscene = 1;

    void Start()
    {
        StartCoroutine(Timedelay(time));
    }
    
    IEnumerator Timedelay(float time)
    {
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene(numscene);
    }
}
