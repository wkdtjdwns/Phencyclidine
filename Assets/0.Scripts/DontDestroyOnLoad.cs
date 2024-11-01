using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyOnLoad : MonoBehaviour
{
    private void Awake()
    {
        SuspectDataDontDestroy();
        SoundManagerDontDestroy();
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

    private void SoundManagerDontDestroy()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("SoundManager");

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