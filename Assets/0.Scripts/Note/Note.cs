using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Note : MonoBehaviour
{
    [SerializeField] private Pages[] pages;
    [SerializeField] private bool[] relationshipChecks;
    [SerializeField] private bool[] alibiChecks;
    [SerializeField] private bool[] provisoChecks;

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
        SetContentActive();
        noteObj.SetActive(true);
    }

    public void CloseNote()
    {
        noteObj.SetActive(false);
    }

    private void SetContentActive()
    {
        for (int i = 0; i < relationshipChecks.Length; i++)
        {
            pages[0].contents[i].SetActive(relationshipChecks[i]);
        }

        for (int i = 0; i < alibiChecks.Length; i++)
        {
            pages[1].contents[i].SetActive(alibiChecks[i]);
        }

        for (int i = 0; i < provisoChecks.Length; i++)
        {
            pages[2].contents[i].SetActive(provisoChecks[i]);
        }
    }

    public void UnlockCheck(int index, int number)
    {
        if (index == 0)
        {
            relationshipChecks[number] = true;
        }

        else if (index == 1)
        {
            alibiChecks[number] = true;
        }

        else
        {
            provisoChecks[number] = true;
        }
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