using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Note : MonoBehaviour
{
    [SerializeField] private Pages[] pages;
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
        pages[index].pageObject.SetActive(true);
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
        pages[index].pageObject.SetActive(true);
    }

    private void OffAllPage()
    {
        for (int i = 0; i < pages.Length; i++)
        {
            pages[i].pageObject.SetActive(false);
        }
    }
}

[System.Serializable]
public struct Pages
{
    public GameObject pageObject;
    public GameObject[] contents;
}