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
    public Button PlayButton;
    public TMP_Text hiScoreText;

    // Start is called before the first frame update
    void Start()
    {
        ScoreManager.Instance.LoadHiScore();
        hiScoreText.text = $"HiScore - {ScoreManager.Instance.playerHiScoreName.ToUpper()}: {ScoreManager.Instance.hiScore}";
    }

    public void NameSelected()
    {
        ScoreManager.Instance.playerName = playerName;
    }
    public void StartNew()
    {
        playerName = inputField.text;
        ScoreManager.Instance.playerName = playerName;
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
