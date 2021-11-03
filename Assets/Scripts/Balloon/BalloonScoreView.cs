using System;
using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(Balloon))]
public class BalloonScoreView : MonoBehaviour
{
    [SerializeField] private Balloon _balloon;
    private ScoreCounter _scoreCounter;

    private void Start()
    {
        _scoreCounter = FindObjectOfType<ScoreCounter>(); 
        //Без DI контейнера ничего лучше не придумал. [SerializeField] не подходит, так как шарик является префабом
    }

    private int _pointForDestroy => Random.Range(0, 10);

    private void OnEnable() => _balloon.Destroyed += OnDestroyed;

    private void OnDisable() => _balloon.Destroyed += OnDestroyed;

    private void OnDestroyed()
    {
        _scoreCounter.AddScore(_pointForDestroy);
    }
}