using UnityEngine;

[RequireComponent(typeof(Balloon))]
public class BalloonParticleView : MonoBehaviour
{
    [SerializeField] private ParticleSystem _effect;
    [SerializeField] private Balloon _balloon;

    private void OnEnable() => _balloon.Destroyed += OnDestroyed;

    private void OnDisable() => _balloon.Destroyed += OnDestroyed;

    private void OnDestroyed() => _effect.Play();
}