using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject GameOverTxt;
    [SerializeField] private GameObject GameCompleteTxt;
    [SerializeField] private TextMeshProUGUI pointsText;
    private float score = 0;
    public bool gameOver = false;
    public static GameManager Instance;

    private void Start() {
        Instance = this;
    }

    public void UpdatePoints(float points) {
        score += points;
        pointsText.text = "Pontos: " + score;

        if (score >= 2500) {
            GameCompleteTxt.SetActive(true);
        }
    }

    public void GameOver() {
        gameOver = true;
        GameOverTxt.SetActive(true);
    }

    public void ResetGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
