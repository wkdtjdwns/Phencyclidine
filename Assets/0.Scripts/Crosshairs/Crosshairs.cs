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
        // 마우스 위치에서 Ray를 발사합니다.
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // targetMask에 포함된 레이 확인
        RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero, targetMask);

        // Raycast 결과 확인
        if (hit.collider != null)
        {
            Debug.Log("충돌 감지: " + hit.collider.name); // 충돌한 오브젝트 이름 출력
            // 충돌했을 때 커서 이미지를 highlight 이미지로 변경합니다.
            Cursor.SetCursor(dotHighlightImg, Vector2.zero, CursorMode.Auto);
        }
        else
        {
            // 충돌하지 않았을 때 기본 이미지로 변경합니다.
            Cursor.SetCursor(dot, Vector2.zero, CursorMode.Auto);
        }
    }
}