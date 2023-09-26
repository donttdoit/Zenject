using UnityEngine;
using Zenject;

public class Bootstrap : MonoBehaviour
{
    private EnemySpawner _spawner;

    [Inject]
    private void Construct(EnemySpawner enemySpawner) => _spawner = enemySpawner;

    private void Awake()
    {
        _spawner.StartWork();
    }

    private void Update()
    {

    }
}
