using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemScan : MonoBehaviour
{
    public LayerMask targetMask; // ������ �߰�
    public Text[] texts;
    public string[] strs;

    private void Update()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // targetMask�� ���Ե� ���� Ȯ��
        RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero, targetMask);

        // Raycast ��� Ȯ��
        if (hit.collider != null)
        {
            switch (hit.collider.name)
            {
                case "Proviso - 3 Image":
                    texts[0].text = strs[0].Replace("\\n", "\n");
                    break;
            }
        }
    }
}
