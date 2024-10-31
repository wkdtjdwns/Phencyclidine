using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemManager : MonoBehaviour
{
    [Header("아이템 리스트 창")]
    public GameObject itemListObj;   // 아이템 오브젝트
    [Header("상세 아이템 스킬 창")]
    public GameObject items;         // 아이템창
    [Header("아이템당 스킬")]
    public ImageArray[] skilCount;       //이미지들
    public Image[] skills;

    void Update()
    {

        if(Input.GetKeyDown(KeyCode.I)) //아이템 오브젝트 켜짐 꺼짐
            itemListObj.SetActive(itemListObj.activeSelf == false ? true : false);
    }

    public void OpenItemList(int index)
    {
        Debug.Log(skilCount[index].imgs.Length);
        for (int i = 0; i < skilCount[index].imgs.Length; i++)
        {
            skills[i].gameObject.SetActive(true);
            skills[i].sprite = skilCount[index].imgs[i];
        }

        items.SetActive(true);  //이미지 설정 후 활성화
    }
}

[System.Serializable]
public class ImageArray
{
    public Sprite[] imgs;
}
