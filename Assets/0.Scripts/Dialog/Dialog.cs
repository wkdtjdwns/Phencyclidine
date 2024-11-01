using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Dialog : MonoBehaviour
{
    [SerializeField] private DialogSystem dialogSystem;
    [SerializeField] private string sceneName;

    private IEnumerator Start()
    {
        yield return new WaitUntil(() => dialogSystem.UpdateDialog());

        switch (sceneName)
        {
            case "GameScene1":
                SoundManager.instance.PlayBgm("시체 확인");
                break;

            case "Dialog9":
            case "Dialog10":
            case "Dialog11":
                SoundManager.instance.PlayBgm("조사");
                break;

            case "GameScene2":
            case "GameScene3":
                SoundManager.instance.PlayBgm("증거 정리");
                break;

            case "GameScene4":
                SoundManager.instance.PlayBgm("범인 색출");
                break;

            case "Dialog18":
                SoundManager.instance.PlayBgm("진엔딩");
                break;
        }

        SceneManager.LoadScene(sceneName);
    }
}
