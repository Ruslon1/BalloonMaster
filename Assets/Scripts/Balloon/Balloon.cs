using System;
using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(MeshRenderer), typeof(Rigidbody))]
public class Balloon : MonoBehaviour
{
    [SerializeField] private ParticleSystem _effect;
    
    private MeshRenderer _meshRenderer;
    private Rigidbody _rigidbody;
    private int _damage => Random.Range(0, 10);

    public event Action Destroyed;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _meshRenderer = GetComponent<MeshRenderer>();
        SetRandomSettings();
    }

    private void OnMouseDown() => Destroy();

    private void SetRandomSettings() => ChangeColor(Random.ColorHSV());

    private void ChangeColor(Color color)
    {
        _effect.startColor = color;
        _meshRenderer.material.color = color;
    }

    private void Destroy()
    {
        Destroyed?.Invoke();
        Destroy(gameObject, 0.25f);
    }

    public void Attack(Player target) => target.TakeHealth(_damage);

    public void SetMass(int value) => _rigidbody.mass = value;
}