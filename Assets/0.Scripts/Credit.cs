using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Credit : MonoBehaviour
{
    private void Awake()
    {
        Invoke("GoMainScene", 35f);
    }

    private void GoMainScene()
    {
        SceneManager.LoadScene("StartScene");
    }
}
