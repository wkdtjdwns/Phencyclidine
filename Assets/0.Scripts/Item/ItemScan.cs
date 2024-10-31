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
        if (Input.GetMouseButtonDown(0))
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
                    
                    case "Alibi - 1 Image":
                        texts[1].text = strs[1].Replace("\\n", "\n");
                        break;
                    case "Proviso - 4 Image":
                        texts[2].text = strs[2].Replace("\\n", "\n");
                        break;
                }
            }
        }
    }
}
