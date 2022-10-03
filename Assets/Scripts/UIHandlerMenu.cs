using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class UIHandlerMenu : MonoBehaviour
{
    public string playerName;
    public TMP_InputField inputField;
    public TMP_Text highScoreText;
    public Button playButton;

    // Start is called before the first frame update
    public void Start()
    {
        playButton.interactable = false;
        ScoreKeeper.Instance.LoadGameRank();
        highScoreText.text = $"High Score - {ScoreKeeper.Instance.bestPlayer.ToUpper()}: {ScoreKeeper.Instance.bestScore}";
    }

    public void SaveText()
    {
        playButton.interactable = true;
        playerName = inputField.text;
        ScoreKeeper.Instance.currentPlayer = playerName;
    }

    public void ChangeScene()
    {
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
