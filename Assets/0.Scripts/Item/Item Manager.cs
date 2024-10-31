using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    private GameObject item;  // ������ ������Ʈ
    public GameObject[] items; // ������â
    [SerializeField] private int CountItemUi; // ������â ī��Ʈ

    public void UseItem()
    {
        print("use");
    
    }
    void Update()
    {
        // ���콺 ��ư Ŭ�� ����
        if (Input.GetMouseButtonDown(0))
        {
            // ���콺 Ŭ�� ��ġ���� Ray�� �߻�
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);

            // Raycast ��� Ȯ��
            if (hit.collider != null)
            {
                // Ŭ���� ������Ʈ�� GameObject ��������
                item = hit.collider.gameObject;
                Debug.Log("Clicked on: " + item.tag);
                if (item != null)
                {
                    // Ŭ���� ������Ʈ �Ǵ�
                    if(item.tag == "item")
                    {
                        items[CountItemUi++].SetActive(true);
                    }
                }
            }
        }
    } 

}
