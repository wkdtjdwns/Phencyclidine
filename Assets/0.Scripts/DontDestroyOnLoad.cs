using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyOnLoad : MonoBehaviour
{
    private void Awake()
    {
        DontDestroy();
    }
    private void DontDestroy()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("DontDestroy");

        if (objs.Length == 1)
        {
            DontDestroyOnLoad(objs[0]);
        }

        else
        {
            for (int index = 1; index < objs.Length; index++)
            {
                Destroy(objs[index]);
            }
        }
    }
}