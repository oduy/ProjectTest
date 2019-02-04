using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColumnManager : MonoBehaviour
{
    
    public GameObject Column;
    float nexttime = 0;
    public float time = 2.5f;

    public enum COLUMN{SPAWN, NOTSPAWN};
    private COLUMN stage = COLUMN.SPAWN;

    public COLUMN Stage { get => stage; set => stage = value; }

    void Update(){
        switch(Stage){
            case COLUMN.SPAWN:{
                SpawColumn();
                break;
            }
            case COLUMN.NOTSPAWN:{

                break;
            }
        }
    }
    
    #region clone colum
    void SpawColumn(){
        if(Time.time > nexttime && GameController.controller.CurrentState == GameController.STATE.PLAY)
        {
            float num = Random.Range(-3f, 3f);
            Instantiate(Column, new Vector2(4, num), Quaternion.identity);
            nexttime = Time.time + time;
        }

    }
    #endregion

}
