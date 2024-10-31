using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    private GameObject item;  // 아이템 오브젝트
    public GameObject[] items; // 아이템창
    [SerializeField] private int CountItemUi; // 아이템창 카운트

    public void UseItem()
    {
        print("use");
    
    }
    void Update()
    {
        // 마우스 버튼 클릭 감지
        if (Input.GetMouseButtonDown(0))
        {
            // 마우스 클릭 위치에서 Ray를 발사
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);

            // Raycast 결과 확인
            if (hit.collider != null)
            {
                // 클릭한 오브젝트의 GameObject 가져오기
                item = hit.collider.gameObject;
                Debug.Log("Clicked on: " + item.tag);
                if (item != null)
                {
                    // 클릭한 오브젝트 판단
                    if(item.tag == "item")
                    {
                        items[CountItemUi++].SetActive(true);
                    }
                }
            }
        }
    } 

}
