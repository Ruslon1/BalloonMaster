using System;
using TMPro;
using UnityEngine;

public class PlayerUIView : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private TMP_Text _healthCounter;

    private void OnEnable()
    {
        _player.TookHealth += OnTookHealth;
    }

    private void OnDisable()
    {
        _player.TookHealth -= OnTookHealth;
    }

    private void OnTookHealth(int health)
    {
        _healthCounter.text = health.ToString();
    }
}