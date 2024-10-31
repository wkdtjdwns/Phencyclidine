using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Dead_body : MonoBehaviour
{
    public LayerMask targetMask; // ������ �߰�

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // ���콺 ��ġ���� Ray�� �߻��մϴ�.
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            // targetMask�� ���Ե� ���� Ȯ��
            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero, targetMask);

            if (hit.collider != null)
            {
                SceneManager.LoadScene("Dialog2");
            }
        }
    }
}
