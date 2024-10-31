using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemManager : MonoBehaviour
{
    [Header("������ ����Ʈ â")]
    public GameObject itemListObj;   // ������ ������Ʈ
    [Header("�� ������ ��ų â")]
    public GameObject items;         // ������â
    [Header("�����۴� ��ų")]
    public ImageArray[] skilCount;       //�̹�����
    public Image[] skills;

    void Update()
    {

        if(Input.GetKeyDown(KeyCode.I)) //������ ������Ʈ ���� ����
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

        items.SetActive(true);  //�̹��� ���� �� Ȱ��ȭ
    }
}

[System.Serializable]
public class ImageArray
{
    public Sprite[] imgs;
}
