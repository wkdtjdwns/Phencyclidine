using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crosshairs : MonoBehaviour
{
    public LayerMask targetMask; // ������ �߰�
    public Texture2D dot; // �⺻ �̹���
    public Texture2D dotHighlightImg; // �����۰� �浹���� �� �̹���

    private void Start()
    {
        // ���콺 Ŀ���� �⺻ �̹����� �����մϴ�.
        Cursor.SetCursor(dot, Vector2.zero, CursorMode.Auto);
    }

    private void Update()
    {
        /*// ���콺 ��ġ���� Ray�� �߻��մϴ�.
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // 2D Raycast�� �����մϴ�.
        RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero, Mathf.Infinity, targetMask);

        // Ray�� targetMask�� �浹�ϴ��� Ȯ���մϴ�.
        if (hit.collider.tag == "item")
        {
            Debug.Log("�浹 ����: " + hit.collider.name); // �浹�� ������Ʈ �̸� ���
            // �浹���� �� Ŀ�� �̹����� highlight �̹����� �����մϴ�.
            Cursor.SetCursor(dotHighlightImg, Vector2.zero, CursorMode.Auto);
        }
        else
        {
            // �浹���� �ʾ��� �� �⺻ �̹����� �����մϴ�.
            Cursor.SetCursor(dot, Vector2.zero, CursorMode.Auto);
            Debug.Log("�浹 ����"); // �浹�� ������ ���
        }*/
    }
}