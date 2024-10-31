using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crosshairs : MonoBehaviour
{
    public LayerMask targetMask; // 아이템 추가
    public Texture2D dot; // 기본 이미지
    public Texture2D dotHighlightImg; // 아이템과 충돌했을 때 이미지

    private void Start()
    {
        // 마우스 커서의 기본 이미지를 설정합니다.
        Cursor.SetCursor(dot, Vector2.zero, CursorMode.Auto);
    }

    private void Update()
    {
        /*// 마우스 위치에서 Ray를 발사합니다.
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // 2D Raycast를 수행합니다.
        RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero, Mathf.Infinity, targetMask);

        // Ray가 targetMask와 충돌하는지 확인합니다.
        if (hit.collider.tag == "item")
        {
            Debug.Log("충돌 감지: " + hit.collider.name); // 충돌한 오브젝트 이름 출력
            // 충돌했을 때 커서 이미지를 highlight 이미지로 변경합니다.
            Cursor.SetCursor(dotHighlightImg, Vector2.zero, CursorMode.Auto);
        }
        else
        {
            // 충돌하지 않았을 때 기본 이미지로 변경합니다.
            Cursor.SetCursor(dot, Vector2.zero, CursorMode.Auto);
            Debug.Log("충돌 없음"); // 충돌이 없음을 출력
        }*/
    }
}