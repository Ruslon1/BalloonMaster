using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private ScoreCounter _scoreCounter;
    
    private int _currentHealth = 100;

    public event Action<int> Defeat;
    public event Action<int> TookHealth;

    public void TakeHealth(int damage)
    {
        _currentHealth -= damage;
        TookHealth?.Invoke(_currentHealth);

        if (_currentHealth <= 0)
            Defeat?.Invoke(_scoreCounter.CurrentScore);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.TryGetComponent(out Balloon balloon))
        {
            balloon.Attack(this);
            Destroy(balloon.gameObject);
        }
    }
}