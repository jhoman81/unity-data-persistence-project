using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif

[DefaultExecutionOrder(1000)]
public class MenuUIHandler : MonoBehaviour
{
    public string playerName;
    public TMP_InputField inputField;
    public Button playButton;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void NameSelected()
    {
        MainManager.Instance.playerName = playerName;
    }
    public void StartNew()
    {

        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
        MainManager.Instance.SaveScore();
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
