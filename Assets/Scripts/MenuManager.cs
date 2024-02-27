using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public Text scoreText;

    public int score;
    // Start is called before the first frame update
    void Start()
    {
        LoadScore();
    }

    void LoadScore()
    {
        scoreText.text = "Points: " + score.ToString();
    }

    public void LoadFirstLevel()
    {
        SceneManager.LoadScene("Nivel 1");
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("Main menu");
    }

    public void LoadGameOver()
    {
        SceneManager.LoadScene("Game Over");
    }
}
