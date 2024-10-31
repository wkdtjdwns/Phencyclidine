using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    [SerializeField] private CanvasGroup canvasGroup;

    [SerializeField] private GameObject background;
    [SerializeField] private Sprite[] backgrounds;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            ChangeBackground(0);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            ChangeBackground(1);
        }
    }

    public void ChangeBackground(int index)
    {
        StartCoroutine(FadeInOut(index));
    }

    private IEnumerator FadeInOut(int index)
    {
        float cur = 0.0f;
        float per = 1.0f;
        while (cur <= per)
        {
            canvasGroup.alpha = Mathf.Lerp(0f, 1f, cur / per);
            cur += Time.deltaTime;
            yield return null;
        }

        background.GetComponent<SpriteRenderer>().sprite = backgrounds[index];
        StartCoroutine(FadeOut());
    }

    private IEnumerator FadeOut()
    {
        float cur = 0.0f;
        float per = 1.0f;
        while (cur <= per)
        {
            canvasGroup.alpha = Mathf.Lerp(1f, 0f, cur / per);
            cur += Time.deltaTime;
            yield return null;
        }
    }
}
