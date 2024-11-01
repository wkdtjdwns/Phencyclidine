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
                SoundManager.instance.PlayBgm("��ü Ȯ��");
                break;

            case "Dialog9":
            case "Dialog10":
            case "Dialog11":
                SoundManager.instance.PlayBgm("����");
                break;

            case "GameScene2":
            case "GameScene3":
                SoundManager.instance.PlayBgm("���� ����");
                break;

            case "GameScene4":
                SoundManager.instance.PlayBgm("���� ����");
                break;

            case "Dialog18":
                SoundManager.instance.PlayBgm("������");
                break;
        }

        SceneManager.LoadScene(sceneName);
    }
}
