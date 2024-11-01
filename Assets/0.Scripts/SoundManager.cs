using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    // 다른 클래스에서도 쉽게 접근할 수 있도록 함
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

        //PlayBgm("시작");
    }

    public void PlayBgm(string type)
    {
        int index = 0;

        // 타입에 따라서 다른 사운드를 플레이함
        switch (type)
        {
            case "시작": index = 0; break;
            case "시체 확인": index = 1; break;
            case "조사": index = 2; break;
            case "증거 정리": index = 3; break;
            case "범인 색출": index = 4; break;
            case "진엔딩": index = 5; break;
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