using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ExtensionMethod
{
    public static void ResetTransformation(this Transform trans)
    {
        trans.position = Vector3.zero;
        trans.rotation = Quaternion.Euler(0f,0f,0f);
        Debug.Log(trans.rotation);
    }
}
