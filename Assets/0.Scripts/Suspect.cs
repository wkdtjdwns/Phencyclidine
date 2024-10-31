using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Suspect : MonoBehaviour
{
    [SerializeField] private GameObject suspectList;

    private void Awake()
    {
        suspectList.SetActive(true);
    }

    public void ListCheck()
    {
        suspectList.SetActive(false);
        SceneManager.LoadScene("Dialog9");
    }
}
