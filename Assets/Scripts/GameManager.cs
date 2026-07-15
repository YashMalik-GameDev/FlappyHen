using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    [SerializeField] private GameObject restartText;
    [SerializeField] private float restartTime = 2f;
    [SerializeField] private GameObject statsUI;
    [SerializeField] private GameObject instructionText;

    private bool gameover = false;
    private bool canRestart = false;
    private bool gameStarted = false;
    private static bool hasPlayedBefore = false;

    private int score = 0;
    private int highScore = 0;

    private void Start()
    {
        highScore = PlayerPrefs.GetInt("HighScore", 0);

        restartText.SetActive(false);

        if (hasPlayedBefore)
        {
            instructionText.SetActive(false);
            statsUI.SetActive(true);
        }
        else
        {
            instructionText.SetActive(true);
            statsUI.SetActive(false);
        }
    }

    private void Update()
    {
        if (Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            Application.Quit();

        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #endif
        }

        if (!gameover)
        {
            return;
        }

        if (!canRestart)
        {
            return;
        }

        if (Keyboard.current.rKey.wasPressedThisFrame)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    private IEnumerator ShowRestartText()
    {
        yield return new WaitForSeconds(restartTime);
        restartText.SetActive(true);
        canRestart = true;
    }


    public void GameOver()
    {
        gameover = true;
        canRestart = false;
        StartCoroutine(ShowRestartText());

        if (score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt("HighScore", highScore);
        }
    }

    public void AddScore()
    {
        score++;
        Debug.Log(score);
    }

    public int GetScore()
    {
        return score;
    }

    public bool GetGameOver()
    {
        return gameover;
    }

    public int GetHighScore()
    {
        return highScore;
    }

    public bool GetGameStarted()
    {
        return gameStarted;
    }

    public void StartGame()
    {
        gameStarted = true;
        hasPlayedBefore = true;

        instructionText.SetActive(false);
        statsUI.SetActive(true);
    }

}
