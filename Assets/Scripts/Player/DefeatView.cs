using System;
using TMPro;
using UnityEngine;

public class DefeatView : MonoBehaviour
{
    [SerializeField] private Player _player;

    [SerializeField] private Canvas _scoreCanvas;
    [SerializeField] private Canvas _defeatCanvas;

    [SerializeField] private TMP_Text _currentScore;
    [SerializeField] private TMP_Text _bestScore;

    private void OnEnable()
    {
        _player.Defeat += OnDefeat;
    }

    private void OnDisable()
    {
        _player.Defeat -= OnDefeat;
    }

    private void OnDefeat(int score)
    {
        _scoreCanvas.gameObject.SetActive(false);
        _defeatCanvas.gameObject.SetActive(true);

        Time.timeScale = 0;

        ShowScores(score);
    }

    private void ShowScores(int score)
    {
        if (PlayerPrefs.GetInt("BestScore") < score)
        {
            PlayerPrefs.SetInt("BestScore", score);
            _bestScore.text = score.ToString();
            _currentScore.text = score.ToString();
        }
        else
        {
            _bestScore.text = PlayerPrefs.GetInt("BestScore").ToString();
            _currentScore.text = score.ToString();
        }
    }
}