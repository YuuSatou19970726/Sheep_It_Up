using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameplayController : MonoBehaviour
{
    public static GameplayController instance;

    [SerializeField]
    private Text scoreText;

    private int score;

    void Awake()
    {
        MakeInstance();
    }

    void Start()
    {
        score = 0;
    }

    public void IncrementScore()
    {
        score++;
        scoreText.text = "x" + score;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("Gameplay");
    }

    void MakeInstance()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
