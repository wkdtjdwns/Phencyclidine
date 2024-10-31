using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class DialogSystem : MonoBehaviour
{
    [SerializeField] private SpriteRenderer background;
    [SerializeField] private Sprite[] backgrounds;

    [SerializeField] private Speaker[] speakers; // ��ȭ�� �����ϴ� ĳ���͵��� UI �迭
    public DialogData[] dialogs; // ���� �б��� ��� ��� �迭

    [SerializeField] private GameObject dialogGroup;
    [SerializeField] private Image dialogImage; // ��ȭâ Image UI
    [SerializeField] private Text associationText; // ���� ������� ĳ���� �Ҽ� ��� Text UI
    [SerializeField] private Text nameText; // ���� ������� ĳ���� �̸� ��� Text UI
    [SerializeField] private Text dialogueText; // ���� ��� ��� Text UI
    [SerializeField] private bool isAutoStart = true; // �ڵ� ���� ����
    [SerializeField] private bool isFirst = true; // ���� 1ȸ�� ȣ���ϱ� ���� ����
    [SerializeField] private int curIndex = -1; // ���� ��� ����
    [SerializeField] private int curSpeakerIndex = 0; // ���� ���� �ϴ� ȭ��(Speaker)�� speakers �迭 ����
    [SerializeField] private float typingSpeed = 0.1f; // �ؽ�Ʈ Ÿ���� ȿ���� ��� �ӵ�
    [SerializeField] private bool isTypingEffect = false;  // �ؽ�Ʈ Ÿ���� ȿ���� ���������

    private void Awake()
    {
        Setup();
    }

    private void Setup()
    {
        // ��� ��ȭ ���� ���ӿ�����Ʈ ��Ȱ��ȭ
        for (int i = 0; i < speakers.Length; ++i)
        {
            SetActiveObjects(speakers[i], false);

            // ĳ���� �̹����� ���̵��� ����
            speakers[i].spriteRenderer.gameObject.SetActive(true);
        }
    }

    public bool UpdateDialog()
    {
        // ��� �бⰡ ���۵� �� 1ȸ�� ȣ��
        if (isFirst == true)
        {
            // �ʱ�ȭ. ĳ���� �̹����� Ȱ��ȭ�ϰ�, ��� ���� UI�� ��� ��Ȱ��ȭ
            Setup();

            // �ڵ� ���(isAutoStart=true)���� �����Ǿ� ������ ù ��° ��� ���
            if (isAutoStart)
            {
                SetNextDialog();
            }

            isFirst = false;
        }

        if (Input.GetMouseButtonDown(0))
        {
            // �ؽ�Ʈ Ÿ���� ȿ���� ������϶� ���콺 ���� Ŭ���ϸ� Ÿ���� ȿ�� ����
            if (isTypingEffect == true)
            {
                isTypingEffect = false;

                // Ÿ���� ȿ���� �����ϰ�, ���� ��� ��ü�� �����
                StopCoroutine("OnTypingText");

                dialogueText.text = dialogs[curIndex].dialogue;

                return false;
            }

            // ��簡 �������� ��� ���� ��� ����
            if (dialogs.Length > curIndex + 1)
            {
                SetNextDialog();
            }

            // ��簡 �� �̻� ���� ��� ��� ������Ʈ�� ��Ȱ��ȭ�ϰ� true ��ȯ
            else
            {
                // ���� ��ȭ�� �����ߴ� ��� ĳ����, ��ȭ ���� UI�� ������ �ʰ� ��Ȱ��ȭ
                for (int i = 0; i < speakers.Length; ++i)
                {
                    SetActiveObjects(dialogGroup, speakers[i], false);

                    // SetActiveObjects()�� ĳ���� �̹����� ������ �ʰ� �ϴ� �κ��� ���� ������ ������ ȣ��
                    speakers[i].spriteRenderer.gameObject.SetActive(false);
                }

                return true;
            }
        }

        return false;
    }

    private void SetNextDialog()
    {
        if (dialogs[curIndex + 1].speakerIndex == -1)
        {
            for (int i = 0; i < speakers.Length; ++i)
            {
                SetActiveObjects(speakers[i], false);

                // SetActiveObjects()�� ĳ���� �̹����� ������ �ʰ� �ϴ� �κ��� ���� ������ ������ ȣ��
                speakers[i].spriteRenderer.gameObject.SetActive(false);
            }

            // ���� ��縦 �����ϵ��� 
            curIndex++;

            // ���� ȭ�� �Ҽ� �ؽ�Ʈ ����
            associationText.text = dialogs[curIndex].association;

            // ���� ȭ�� �̸� �ؽ�Ʈ ����
            nameText.text = dialogs[curIndex].name;

            background.sprite = backgrounds[dialogs[curIndex].mapIndex];

            // ���� ȭ���� ��� �ؽ�Ʈ ����
            StartCoroutine("OnTypingText");
        }

        else
        {
            // ��� ��ȭ ���� ���ӿ�����Ʈ ��Ȱ��ȭ
            for (int i = 0; i < speakers.Length; ++i)
            {
                SetActiveObjects(speakers[i], false);

                // ĳ���� �̹����� ���̵��� ����
                speakers[i].spriteRenderer.gameObject.SetActive(true);
            }

            // ���� ��縦 �����ϵ��� 
            curIndex++;

            // ���� ȭ�� ���� ����
            curSpeakerIndex = dialogs[curIndex].speakerIndex;

            // ���� ȭ���� ��ȭ ���� ������Ʈ Ȱ��ȭ
            SetActiveObjects(speakers[curSpeakerIndex], true);
            speakers[curSpeakerIndex].isFirst = false;

            // ���� ȭ�� �Ҽ� �ؽ�Ʈ ����
            associationText.text = dialogs[curIndex].association;

            // ���� ȭ�� �̸� �ؽ�Ʈ ����
            nameText.text = dialogs[curIndex].name;

            background.sprite = backgrounds[dialogs[curIndex].mapIndex];

            // ���� ȭ���� ��� �ؽ�Ʈ ����
            StartCoroutine("OnTypingText");
        }
    }

    private void SetActiveObjects(Speaker speaker, bool visible)
    {
        // ĳ���� ���� �� ����
        Color color = speaker.spriteRenderer.color;
        color.a = visible == true ? 1 : speaker.isFirst ? 0.0f : 0.2f;
        speaker.spriteRenderer.color = color;
    }

    private void SetActiveObjects(GameObject dialogGroup, Speaker speaker, bool visible)
    {
        // ĳ���� ���� �� ����
        Color color = speaker.spriteRenderer.color;
        color.a = visible == true ? 1 : speaker.isFirst ? 0.2f : 0.0f;
        speaker.spriteRenderer.color = color;
        dialogGroup.SetActive(visible);
    }

    private IEnumerator OnTypingText()
    {
        int index = 0;

        isTypingEffect = true;

        // �ؽ�Ʈ�� �ѱ��ھ� Ÿ����ġ�� ���
        while (index < dialogs[curIndex].dialogue.Length)
        {
            dialogueText.text = dialogs[curIndex].dialogue.Substring(0, index);

            index++;

            yield return new WaitForSeconds(typingSpeed);
        }

        isTypingEffect = false;
    }
}

[System.Serializable]
public struct Speaker
{
    public SpriteRenderer spriteRenderer;  // ĳ���� �̹��� (û��/ȭ�� ���İ� ����)
    public bool isFirst;
}

[System.Serializable]
public struct DialogData
{
    public int speakerIndex; // �̸��� ��縦 ����� ���� DialogSystem�� speakers �迭 ����
    public string association; // ĳ���� �Ҽ�
    public string name; // ĳ���� �̸�
    public int mapIndex;

    [TextArea(3, 5)]
    public string dialogue; // ���
}