using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{

    public static GameManager MyInstance;

    public TextMeshProUGUI ScoreText;

    public int Score;

    public GameObject GameoverPanel;
    public GameObject StartGamePanel;
    private void Awake()
    {
        MyInstance = this;
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
        ScoreText.text = Score.ToString();
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
}
