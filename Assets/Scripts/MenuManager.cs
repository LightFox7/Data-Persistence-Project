using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuManager : MonoBehaviour
{
    public TMP_Text bestScoreText;
    public TMP_InputField inputField;
    // Start is called before the first frame update
    void Start()
    {
        bestScoreText.text = $"Best Score: {GameManager.Instance.bestPlayerName}: {GameManager.Instance.bestScore}";
    }

    public void UpdatePlayerName() {
        GameManager.Instance.playerName = inputField.text;
    }

    public void StartGame() {
        SceneManager.LoadScene(1);
    }

    public void Exit() {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
            Application.Quit();
#endif
        GameManager.Instance.SaveScore();
    }
}
