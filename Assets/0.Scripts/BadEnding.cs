using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BadEnding : MonoBehaviour
{
    private void Awake()
    {
        Invoke("GoMainScene", 5f);
    }

    private void GoMainScene()
    {
        SceneManager.LoadScene("StartScene");
    }
}
