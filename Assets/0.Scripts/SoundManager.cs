using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    // �ٸ� Ŭ���������� ���� ������ �� �ֵ��� ��
    public static SoundManager instance;

    [SerializeField] private AudioClip[] bgmClips;
    [SerializeField] private Slider bgmSlider;

    public float bgmVolume;
    public AudioSource bgmPlayer;

    private void Awake()
    {
        instance = this;
        bgmVolume = 0.5f;

        bgmPlayer = GameObject.Find("Bgm Player").gameObject.GetComponent<AudioSource>();

        //PlayBgm("����");
    }

    public void PlayBgm(string type)
    {
        int index = 0;

        // Ÿ�Կ� ���� �ٸ� ���带 �÷�����
        switch (type)
        {
            case "����": index = 0; break;
            case "��ü Ȯ��": index = 1; break;
            case "����": index = 2; break;
            case "���� ����": index = 3; break;
            case "���� ����": index = 4; break;
            case "������": index = 5; break;
        }
        bgmPlayer.Stop();

        bgmPlayer.clip = bgmClips[index];

        bgmPlayer.Play();
    }

    public void ChangeBgmSound(float value)
    {
        bgmPlayer.volume = value * 0.5f;
    }
}