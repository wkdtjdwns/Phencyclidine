using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialog : MonoBehaviour
{
    [SerializeField] private DialogSystem[] dialogSystems;
    [SerializeField] private int index;

    private IEnumerator Start()
    {
        for (int i = 0; i < dialogSystems[index].dialogs.Length; i++)
        {
            yield return new WaitUntil(() => dialogSystems[index].UpdateDialog());
        }

        index++;
    }
}
