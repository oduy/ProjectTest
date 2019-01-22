using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveHightScore : MonoBehaviour
{
    #region contructor
    public static SaveHightScore HightScore;

    void Awake(){
        if(HightScore != null)
            return;
        HightScore = this;
    }
    #endregion

    
    public void saveScore(int Score){
        PlayerPrefs.SetInt("HightScore", Score);
        PlayerPrefs.Save();
    }

    public int getScore(){
        return PlayerPrefs.GetInt("HightScore");
    }
}