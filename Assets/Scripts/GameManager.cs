using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static GameManager MyInstance;

    public GameObject GameoverPanel;
    private void Awake()
    {
        MyInstance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        GameoverPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ResetLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
