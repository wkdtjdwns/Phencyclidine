using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{

    public GameObject mainMenuHolder;       //���� �޴� ������Ʈ
    public GameObject optionsMenuHolder;    //�ɼ� �޴� ������Ʈ

    public Slider[] volumeSliders;           //���� �����̴�
    public Toggle[] resolutionToggles;       //�ػ� ���
    public Toggle fullscreenToggle;          //��ü ȭ�� ���
    public int[] screenWidths;               //�ػ�
    int activeScreenResIndex;                //��� �ػ� �ε���

    void Start()
    {
        activeScreenResIndex = PlayerPrefs.GetInt("screen res index");
        bool isFullscreen = (PlayerPrefs.GetInt("fullscreen") == 1) ? true : false;

        for (int i = 0; i < resolutionToggles.Length; i++)
        {
            resolutionToggles[i].isOn = i == activeScreenResIndex;
        }

        if (isFullscreen)
        {
            for (int i = 0; i < resolutionToggles.Length; i++)
            {
                resolutionToggles[i].interactable = !isFullscreen;
            }
        }

        //volumeSliders[0].value = AudioManager.instance.masterVolumePercent;
        //volumeSliders[1].value = AudioManager.instance.musicVolumePercent;
        //volumeSliders[2].value = AudioManager.instance.sfxVolumePercent;

        fullscreenToggle.isOn = isFullscreen;
    }

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

    /// <summary>
    /// �ػ� ����
    /// </summary>
    /// <param name="i">�ػ� �ε���</param>
    public void SetScreenResolution(int i)
    {
        // ������ �ػ� ����� ���� �ִ��� Ȯ��
        if (resolutionToggles[i].isOn)
        {
            activeScreenResIndex = i;   // ���� �ػ� �ε����� ������Ʈ
            float aspectRatio = 16 / 9f;

            // �־��� �ػ󵵿� ������ ȭ�� �ػ� ����, ��ü ȭ���� �ƴ�
            Screen.SetResolution(screenWidths[i], (int)(screenWidths[i] / aspectRatio), false);
            PlayerPrefs.SetInt("screen res index", activeScreenResIndex);
            PlayerPrefs.Save();
        }
    }

    /// <summary>
    /// Ǯ��ũ�� ����
    /// </summary>
    /// <param name="isFullscreen">��ü ȭ�� ����</param>
    public void SetFullscreen(bool isFullscreen)
    {
        // ��ü ȭ�� ���ο� ���� �ػ� ����� Ȱ��ȭ ���� ����
        for (int i = 0; i < resolutionToggles.Length; i++)
        {
            resolutionToggles[i].interactable = !isFullscreen;
        }

        if (isFullscreen)
        {
            // ��� �����Ǵ� �ػ� ����� ������
            Resolution[] allResolutions = Screen.resolutions;
            // ���� ū �ػ󵵸� ����
            Resolution maxResolution = allResolutions[allResolutions.Length - 1];
            // ������ �ػ󵵷� ��ü ȭ�� ����
            Screen.SetResolution(maxResolution.width, maxResolution.height, true);
        }
        else
        {
            // ��ü ȭ���� �����ϸ� ������ ������ �ػ󵵷� ����
            SetScreenResolution(activeScreenResIndex);
        }

        PlayerPrefs.SetInt("fullscreen", ((isFullscreen) ? 1 : 0));
        PlayerPrefs.Save();
    }

    /// <summary>
    /// ������ ���� ����
    /// </summary>
    /// <param name="value">������ ���� ��</param>
    public void SetMasterVolume(float value)
    {
//        AudioManager.instance.SetVolume(value, AudioManager.AudioChannel.Master);
    }

    /// <summary>
    /// ���� ���� ����
    /// </summary>
    /// <param name="value">���� ���� ��</param>
    public void SetMusicVolume(float value)
    {
        //AudioManager.instance.SetVolume(value, AudioManager.AudioChannel.Music);
    }

    /// <summary>
    /// ȿ���� ���� ����
    /// </summary>
    /// <param name="value">ȿ���� ���� ��</param>
    public void SetSfxVolume(float value)
    {
        //AudioManager.instance.SetVolume(value, AudioManager.AudioChannel.Sfx);
    }

}