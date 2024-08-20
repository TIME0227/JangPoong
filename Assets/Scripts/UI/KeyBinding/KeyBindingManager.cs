using UnityEngine;
using UnityEngine.SceneManagement;

public class KeyBindingManager
{
    public static KeyBindingManager Instance { get; private set; }

    // ��� �׽�Ʈ�� ��ư
    private string nextSceneName = "1-1 tutorial";

    public void OnButtonClick()
    {
        SceneManager.LoadScene(nextSceneName);
    }


    // private void Awake()
    // {
    //     if (Instance == null)
    //     {
    //         Instance = this;
    //         DontDestroyOnLoad(gameObject);
    //     }
    //     else
    //     {
    //         Destroy(gameObject);
    //     }
    // }

    public KeyCode jumpKeyCode = KeyCode.W;
    public KeyCode slideKeyCode = KeyCode.S;
    public KeyCode runKeyCode = KeyCode.LeftShift;
    public KeyCode leftKeyCode = KeyCode.A;
    public KeyCode rightKeyCode = KeyCode.D;

    // private void Start()
    // {
    //    
    // }

    public void SaveKeyBindings()
    {
        PlayerPrefs.SetString("JumpKey", jumpKeyCode.ToString());
        PlayerPrefs.SetString("SlideKey", slideKeyCode.ToString());
        // PlayerPrefs.SetString("RunKey", runKeyCode.ToString());
        PlayerPrefs.SetString("LeftKey", leftKeyCode.ToString());
        PlayerPrefs.SetString("RightKey", rightKeyCode.ToString());
        PlayerPrefs.Save();
    }

    public void LoadKeyBindings()
    {
        if (PlayerPrefs.HasKey("JumpKey"))
        {
            jumpKeyCode = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("JumpKey"));
            slideKeyCode = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("SlideKey"));
            // runKeyCode = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("RunKey"));
            leftKeyCode = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("LeftKey"));
            rightKeyCode = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("RightKey"));
        }
    }
}
