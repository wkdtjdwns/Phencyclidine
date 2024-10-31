using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class DialogSystem : MonoBehaviour
{
    [SerializeField] private SpriteRenderer background;
    [SerializeField] private Sprite[] backgrounds;

    [SerializeField] private Speaker[] speakers; // 대화에 참여하는 캐릭터들의 UI 배열
    public DialogData[] dialogs; // 현재 분기의 대사 목록 배열

    [SerializeField] private GameObject dialogGroup;
    [SerializeField] private Image dialogImage; // 대화창 Image UI
    [SerializeField] private Text associationText; // 현재 대사중인 캐릭터 소속 출력 Text UI
    [SerializeField] private Text nameText; // 현재 대사중인 캐릭터 이름 출력 Text UI
    [SerializeField] private Text dialogueText; // 현재 대사 출력 Text UI
    [SerializeField] private bool isAutoStart = true; // 자동 시작 여부
    [SerializeField] private bool isFirst = true; // 최초 1회만 호출하기 위한 변수
    [SerializeField] private int curIndex = -1; // 현재 대사 순번
    [SerializeField] private int curSpeakerIndex = 0; // 현재 말을 하는 화자(Speaker)의 speakers 배열 순번
    [SerializeField] private float typingSpeed = 0.1f; // 텍스트 타이핑 효과의 재생 속도
    [SerializeField] private bool isTypingEffect = false;  // 텍스트 타이핑 효과를 재생중인지

    private void Awake()
    {
        Setup();
    }

    private void Setup()
    {
        // 모든 대화 관련 게임오브젝트 비활성화
        for (int i = 0; i < speakers.Length; ++i)
        {
            SetActiveObjects(speakers[i], false);

            // 캐릭터 이미지는 보이도록 설정
            speakers[i].spriteRenderer.gameObject.SetActive(true);
        }
    }

    public bool UpdateDialog()
    {
        // 대사 분기가 시작될 때 1회만 호출
        if (isFirst == true)
        {
            // 초기화. 캐릭터 이미지는 활성화하고, 대사 관련 UI는 모두 비활성화
            Setup();

            // 자동 재생(isAutoStart=true)으로 설정되어 있으면 첫 번째 대사 재생
            if (isAutoStart)
            {
                SetNextDialog();
            }

            isFirst = false;
        }

        if (Input.GetMouseButtonDown(0))
        {
            // 텍스트 타이핑 효과를 재생중일때 마우스 왼쪽 클릭하면 타이핑 효과 종료
            if (isTypingEffect == true)
            {
                isTypingEffect = false;

                // 타이핑 효과를 중지하고, 현재 대사 전체를 출력함
                StopCoroutine("OnTypingText");

                dialogueText.text = dialogs[curIndex].dialogue;

                return false;
            }

            // 대사가 남아있을 경우 다음 대사 진행
            if (dialogs.Length > curIndex + 1)
            {
                SetNextDialog();
            }

            // 대사가 더 이상 없을 경우 모든 오브젝트를 비활성화하고 true 반환
            else
            {
                // 현재 대화에 참여했던 모든 캐릭터, 대화 관련 UI를 보이지 않게 비활성화
                for (int i = 0; i < speakers.Length; ++i)
                {
                    SetActiveObjects(dialogGroup, speakers[i], false);

                    // SetActiveObjects()에 캐릭터 이미지를 보이지 않게 하는 부분이 없기 때문에 별도로 호출
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

                // SetActiveObjects()에 캐릭터 이미지를 보이지 않게 하는 부분이 없기 때문에 별도로 호출
                speakers[i].spriteRenderer.gameObject.SetActive(false);
            }

            // 다음 대사를 진행하도록 
            curIndex++;

            // 현재 화자 소속 텍스트 설정
            associationText.text = dialogs[curIndex].association;

            // 현재 화자 이름 텍스트 설정
            nameText.text = dialogs[curIndex].name;

            background.sprite = backgrounds[dialogs[curIndex].mapIndex];

            // 현재 화자의 대사 텍스트 설정
            StartCoroutine("OnTypingText");
        }

        else
        {
            // 모든 대화 관련 게임오브젝트 비활성화
            for (int i = 0; i < speakers.Length; ++i)
            {
                SetActiveObjects(speakers[i], false);

                // 캐릭터 이미지는 보이도록 설정
                speakers[i].spriteRenderer.gameObject.SetActive(true);
            }

            // 다음 대사를 진행하도록 
            curIndex++;

            // 현재 화자 순번 설정
            curSpeakerIndex = dialogs[curIndex].speakerIndex;

            // 현재 화자의 대화 관련 오브젝트 활성화
            SetActiveObjects(speakers[curSpeakerIndex], true);
            speakers[curSpeakerIndex].isFirst = false;

            // 현재 화자 소속 텍스트 설정
            associationText.text = dialogs[curIndex].association;

            // 현재 화자 이름 텍스트 설정
            nameText.text = dialogs[curIndex].name;

            background.sprite = backgrounds[dialogs[curIndex].mapIndex];

            // 현재 화자의 대사 텍스트 설정
            StartCoroutine("OnTypingText");
        }
    }

    private void SetActiveObjects(Speaker speaker, bool visible)
    {
        // 캐릭터 알파 값 변경
        Color color = speaker.spriteRenderer.color;
        color.a = visible == true ? 1 : speaker.isFirst ? 0.0f : 0.2f;
        speaker.spriteRenderer.color = color;
    }

    private void SetActiveObjects(GameObject dialogGroup, Speaker speaker, bool visible)
    {
        // 캐릭터 알파 값 변경
        Color color = speaker.spriteRenderer.color;
        color.a = visible == true ? 1 : speaker.isFirst ? 0.2f : 0.0f;
        speaker.spriteRenderer.color = color;
        dialogGroup.SetActive(visible);
    }

    private IEnumerator OnTypingText()
    {
        int index = 0;

        isTypingEffect = true;

        // 텍스트를 한글자씩 타이핑치듯 재생
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
    public SpriteRenderer spriteRenderer;  // 캐릭터 이미지 (청자/화자 알파값 제어)
    public bool isFirst;
}

[System.Serializable]
public struct DialogData
{
    public int speakerIndex; // 이름과 대사를 출력할 현재 DialogSystem의 speakers 배열 순번
    public string association; // 캐릭터 소속
    public string name; // 캐릭터 이름
    public int mapIndex;

    [TextArea(3, 5)]
    public string dialogue; // 대사
}