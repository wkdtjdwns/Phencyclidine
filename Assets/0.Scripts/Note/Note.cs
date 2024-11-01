using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Note : MonoBehaviour
{
    [SerializeField] private GameObject[] pageObject;
    [SerializeField] private int index;
    [SerializeField] private GameObject noteObj;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            ShowNote();
        }
    }

    public void ShowNote()
    {
        noteObj.SetActive(true);
    }

    public void CloseNote()
    {
        noteObj.SetActive(false);
    }

    public void ProvPage()
    {
        if (index <= 0)
        {
            index = 2;
        }

        else
        {
            index--;
        }

        OffAllPage();
        pageObject[index].SetActive(true);
    }

    public void NextPage()
    {
        if (index >= 2)
        {
            index = 0;
        }

        else
        {
            index++;
        }

        OffAllPage();
        pageObject[index].SetActive(true);
    }

    private void OffAllPage()
    {
        for (int i = 0; i < pageObject.Length; i++)
        {
            pageObject[i].SetActive(false);
        }
    }
}