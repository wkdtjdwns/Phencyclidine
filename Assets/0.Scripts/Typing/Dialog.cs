using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialog : MonoBehaviour
{
    [SerializeField] private DialogSystem dialogSystem;

    private IEnumerator Start()
    {
        // 첫 번째 대사 분기 시작
        yield return new WaitUntil(() => dialogSystem.UpdateDialog());
    }
}
