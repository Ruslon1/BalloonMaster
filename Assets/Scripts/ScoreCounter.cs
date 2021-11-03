using TMPro;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    [SerializeField] private TMP_Text _score;

    private int _currentScore;

    public int CurrentScore => _currentScore;
    
    public void AddScore(int amount)
    {
        _currentScore += amount;
        _score.text = _currentScore.ToString();
    }
}