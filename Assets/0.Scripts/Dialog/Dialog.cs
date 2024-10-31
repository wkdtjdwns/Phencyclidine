using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialog : MonoBehaviour
{
    [SerializeField] private DialogSystem dialogSystem;
    [SerializeField] private string sceneName;

    private IEnumerator Start()
    {
        yield return new WaitUntil(() => dialogSystem.UpdateDialog());

        SceneController.instance.SceneChange(sceneName);
    }
}
