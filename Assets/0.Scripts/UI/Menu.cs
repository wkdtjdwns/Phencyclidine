using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{

    public GameObject mainMenuHolder;       //���� �޴� ������Ʈ
    public GameObject optionsMenuHolder;    //�ɼ� �޴� ������Ʈ

    /// <summary>
    /// ���� ����
    /// </summary>
    public void Play()
    {
        SceneManager.LoadScene("Dialog1");
    }

    /// <summary>
    /// ���� ����
    /// </summary>
    public void Quit()
    {
#if UNITY_EDITOR
        // �� �ڵ�� Unity �����Ϳ����� �����
        UnityEditor.EditorApplication.isPlaying = false;    //���� �� ���� ����
#endif

        Application.Quit();
    }

    /// <summary>
    /// �ɼ� �޴� Ȱ��ȭ
    /// </summary>
    public void OptionsMenu()
    {
        mainMenuHolder.SetActive(false);
        optionsMenuHolder.SetActive(true);
    }

    /// <summary>
    /// ���� �޴� Ȱ��ȭ
    /// </summary>
    public void MainMenu()
    {
        mainMenuHolder.SetActive(true);
        optionsMenuHolder.SetActive(false);
    }

}