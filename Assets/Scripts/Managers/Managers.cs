using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Managers : MonoBehaviour
{
    //Singleton
    static Managers s_instance; //유일성 보장

    static Managers Instance { get
    {
        Init();
        return s_instance;
    } } //유일한 매니져를 가져온다.
    
    #region Core

    private DataManager _data = new DataManager();
    private InputManager _input = new InputManager();
    private ResourceManager _resource = new ResourceManager();
    private SceneManagerEx _scene = new SceneManagerEx();
    private UIManager _ui = new UIManager();
    private SoundManager sound = new SoundManager();
    private PlayerDataManager _playerData;

    private KeyBindingManager _keyBind = new KeyBindingManager();
    private InventoryManager _inventory = new InventoryManager();
    
    
    public static DataManager Data { get { return Instance._data; } }
    public static InputManager Input { get { return Instance._input; } }
    public static ResourceManager Resource { get { return Instance._resource; } }
    public static SceneManagerEx Scene
    {
        get { return Instance._scene; }
    }
    public static UIManager UI { get { return Instance._ui; } }
    public static SoundManager Sound
    {
        get { return Instance.sound; }
    }

    public static PlayerDataManager PlayerData
    {
        get
        {
            if (Instance._playerData == null)
            {
                Instance._playerData = GameObject.FindObjectOfType<PlayerDataManager>();
            }

            return Instance._playerData;
        }
    }


    public static KeyBindingManager KeyBind
    {
        get
        {
            return Instance._keyBind;
        }
    }

    public static InventoryManager Inventory
    {
        get
        {
            return Instance._inventory;
        }
    }
    
    #endregion
    
    private void Start()
    {
        Init();
    }

    private void Update()
    {
        _input.OnUpdate(); //마우스, 키보드 입력 체크를 Managers가 대표로 처리
    }

    //초기화
    static void Init()
    {
        if (s_instance == null)
        {
            //현재 @Managers가 씬에 있는지 확인
            GameObject go = GameObject.Find("@Managers");
            if (go == null)
            {
                //씬에 없는 경우 @Managers를 새로 만듦
                go = new GameObject { name = "@Managers" };
                go.AddComponent<Managers>();

            }
            DontDestroyOnLoad(go);
            s_instance = go.GetComponent<Managers>();


            s_instance._data.Init();
            s_instance.sound.Init();
            s_instance._keyBind.LoadKeyBindings();
        }

    }

    public static void Clear()
    {
        // Input.Clear();
        Sound.Clear();
        //추가 예정
   }


    public static void RestPlayData()
    {
        string[] dataKeys = Enum.GetNames(typeof(Define.SaveKey));

        foreach (string key in dataKeys)
        {
            if(PlayerPrefs.HasKey(key)) PlayerPrefs.DeleteKey(key);
        }
    }


    
}
