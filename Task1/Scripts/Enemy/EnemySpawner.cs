using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class EnemySpawner
{
    private float _spawnCooldown;
    private List<Transform> _spawnPoints;

    private List<Enemy> _spawnedEnemies = new List<Enemy>();

    private CoroutineRunner _coroutineSpawner;
    private EnemyFactory _enemyFactory;
    private Coroutine _spawn;

    

    [Inject]
    private void Construct(EnemyFactory enemyFactory, CoroutineRunner coroutineSpawner)
    {
        _enemyFactory = enemyFactory;
        _coroutineSpawner = coroutineSpawner;
        Debug.Log("ConstructCoroutineSpawner");
        Debug.Log(_coroutineSpawner);
    }


    public EnemySpawner(float spawnCooldown, List<Transform> spawnPoints)
    {
        Debug.Log($"SpawnPointsCount {spawnPoints.Count}");
        _spawnCooldown = spawnCooldown;
        _spawnPoints = new List<Transform>(spawnPoints);
    }

    public void StartWork()
    {
        StopWork();
       
        _spawn = _coroutineSpawner.StartCoroutine(Spawn());
    }

    public void StopWork()
    {
        if (_spawn != null)
            _coroutineSpawner.StopCoroutine(_spawn);
    }


    private IEnumerator Spawn()
    {
        float time = 0;

        while (true)
        {
            while (time < _spawnCooldown)
            {
                time += Time.deltaTime;

                yield return null;
            }

            Enemy enemy = _enemyFactory.Get((EnemyType)UnityEngine.Random.Range(0, Enum.GetValues(typeof(EnemyType)).Length));
            enemy.MoveTo(_spawnPoints[UnityEngine.Random.Range(0, _spawnPoints.Count)].position);
            _spawnedEnemies.Add(enemy);
            time = 0;
        }
    }

    
}




