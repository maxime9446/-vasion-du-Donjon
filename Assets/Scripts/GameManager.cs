using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{

    public static GameManager MyInstance;

    public TextMeshProUGUI ScoreText;
    public TextMeshProUGUI HighScoreText;

    public int Score;
    private int highScore;

    public GameObject GameoverPanel;
    public GameObject StartGamePanel;
    private void Awake()
    {
        MyInstance = this;
        LoadHighScore();
    }
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;
        StartGamePanel.SetActive(true);
        GameoverPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        ScoreText.text = "Score : " + Score.ToString();
        if (Score > highScore)
        {
            highScore = Score;
            HighScoreText.text = "Highscore : " + highScore.ToString(); 
            SaveHighScore(); 
        }
    }

    public void StartGame()
    {
        StartGamePanel.SetActive(false);
        Time.timeScale = 1;
    }

    public void ResetLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void LoadHighScore()
    {
        highScore = PlayerPrefs.GetInt("HighScore", 0); 
        HighScoreText.text = "Highscore : " + highScore.ToString();
    }

    void SaveHighScore()
    {
        PlayerPrefs.SetInt("HighScore", highScore); 
        PlayerPrefs.Save(); 
    }
}
