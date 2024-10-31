using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyOnLoad : MonoBehaviour
{
    private void Awake()
    {
        SuspectDataDontDestroy();
        //NoteDontDestroy();
    }

    private void SuspectDataDontDestroy()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("SuspectData");

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

    //private void NoteDontDestroy()
    //{
    //    GameObject[] objs = GameObject.FindGameObjectsWithTag("Note");

    //    if (objs.Length == 1)
    //    {
    //        DontDestroyOnLoad(objs[0]);
    //    }

    //    else
    //    {
    //        for (int index = 1; index < objs.Length; index++)
    //        {
    //            Destroy(objs[index]);
    //        }
    //    }
    //}
}