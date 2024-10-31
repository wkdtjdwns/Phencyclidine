using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialog : MonoBehaviour
{
    [SerializeField] private DialogSystem dialogSystem;

    private IEnumerator Start()
    {
        // ù ��° ��� �б� ����
        yield return new WaitUntil(() => dialogSystem.UpdateDialog());
    }
}
