using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuspectList : MonoBehaviour
{
    [SerializeField] private GameObject[] page;
    [SerializeField] private GameObject[] suspect;
    public void StartingList()
    {
        page[0].SetActive(false);
        page[1].SetActive(true);
    }


}
