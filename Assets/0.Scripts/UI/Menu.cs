using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{

    public GameObject mainMenuHolder;       //메인 메뉴 오브젝트
    public GameObject optionsMenuHolder;    //옵션 메뉴 오브젝트

    /// <summary>
    /// 게임 시작
    /// </summary>
    public void Play()
    {
        SceneManager.LoadScene("Dialog1");
    }

    /// <summary>
    /// 게임 종료
    /// </summary>
    public void Quit()
    {
#if UNITY_EDITOR
        // 이 코드는 Unity 에디터에서만 실행됨
        UnityEditor.EditorApplication.isPlaying = false;    //빌드 전 게임 종료
#endif

        Application.Quit();
    }

    /// <summary>
    /// 옵션 메뉴 활성화
    /// </summary>
    public void OptionsMenu()
    {
        mainMenuHolder.SetActive(false);
        optionsMenuHolder.SetActive(true);
    }

    /// <summary>
    /// 메인 메뉴 활성화
    /// </summary>
    public void MainMenu()
    {
        mainMenuHolder.SetActive(true);
        optionsMenuHolder.SetActive(false);
    }

}