using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static Color black = new Color(0, 0, 0);
    public static Color white = new Color(255, 255, 255);

    //싱글톤 패턴 사용
    public static GameManager instance;

    //인벤토리 비스무리한 시스템
    public bool isMenu;
    //아이템 리스트
    public bool[] itemList;
    //캐릭터 리스트
    public bool[] charList;
    //키 스크립트 리스트
    public bool[] keyList;

    public GameObject[] statusUI; //0은 캐릭터, 1은 아이템, 2는 키 스크립트
    public GameObject[] statusBtn; // "

    public GameObject ExitMenu;

    // 플레이어 제어
    public PlayerCtrl pc; // 플레이어 컨트롤 스크립트
    public GameObject p; // 플레이어 오브젝트
    public Path path;

    //이동 버튼 활성화/비활성화 하기 위함
    public GameObject MoveButton;

    //NPC와 대화하기 위한 컴포넌트
    public NPCScript npc;
    //대화 창 띄우는 텍스트
    public Text script;
    //대화 가능 시 뜨는 버튼
    public GameObject chatButton;

    public House house;
    
    //세이브와 로드
    public SaveLoad sv;

    public Text tempText;

    private void Start()
    {
        instance = this;
        sv = FindObjectOfType<SaveLoad>();
        pc = FindObjectOfType<PlayerCtrl>();
        GameStart();
        sv.Load();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            sv.Save();
            Debug.Log("a");
        }
    }

    public void GameStart()
    {
        statusUI[0] = GameObject.Find("UI").transform.Find("CharactersMenu").gameObject;
        statusUI[1] = GameObject.Find("UI").transform.Find("ItemMenu").gameObject;
        statusUI[2] = GameObject.Find("UI").transform.Find("KeyScriptMenu").gameObject;
        statusBtn[0] = GameObject.Find("UI").transform.Find("CharButton").gameObject;
        statusBtn[1] = GameObject.Find("UI").transform.Find("ItemButton").gameObject;
        statusBtn[2] = GameObject.Find("UI").transform.Find("KeyButton").gameObject;
        script = GameObject.Find("UI").transform.Find("Script").GetComponent<Text>();
        chatButton = GameObject.Find("UI").transform.Find("ChatButton").gameObject;
    }
}
