using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextSceen : MonoBehaviour
{
    public void Next(string name)
    {
        SceneManager.LoadScene(name);
    }
}
