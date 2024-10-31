using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Dead_body : MonoBehaviour
{
    public LayerMask targetMask; // 아이템 추가

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // 마우스 위치에서 Ray를 발사합니다.
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            // targetMask에 포함된 레이 확인
            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero, targetMask);

            if (hit.collider != null)
            {
                SceneManager.LoadScene("Dialog2");
            }
        }
    }
}
