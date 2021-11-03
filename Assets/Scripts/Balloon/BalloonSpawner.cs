using System.Collections;
using UnityEngine;

public class BalloonSpawner : MonoBehaviour
{
    [SerializeField] private SpawnPoint[] _spawnPoints;
    [SerializeField] private Balloon _balloonTemplate;

    private void Start()
    {
        StartCoroutine(Spawn(0.7f));
    }

    private IEnumerator Spawn(float timeBetweenSpawn)
    {
        var delay = new WaitForSeconds(timeBetweenSpawn);
        int objectMass = 1;
        
        while (true)
        {
            var position = _spawnPoints[Random.Range(0, _spawnPoints.Length)].transform.position;
            Instantiate(_balloonTemplate, position, Quaternion.identity, transform).SetMass(objectMass);
            objectMass++;
            yield return delay;
        }
    }
}