using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class EnemySpawnerInstaller : MonoInstaller
{
    [SerializeField] private float _spawnCooldown;
    [SerializeField] private List<Transform> _spawnPoints;
    [SerializeField] private CoroutineRunner _coroutineRunner;

    public override void InstallBindings()
    {
        Container.Bind<EnemyFactory>().AsSingle();
        Container.Bind<CoroutineRunner>().FromInstance(_coroutineRunner).AsSingle();
        Container.Bind<float>().FromInstance(_spawnCooldown).WhenInjectedInto<EnemySpawner>();
        Container.Bind<List<Transform>>().FromInstance(_spawnPoints).WhenInjectedInto<EnemySpawner>();
        Container.Bind<EnemySpawner>().AsSingle();


    }

}
