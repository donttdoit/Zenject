using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class MediatorInstaller : MonoInstaller
{
    [SerializeField] GameplayMediator _gameplayMediator;
    [SerializeField] DefeatPanel _defeatPanel;

    public override void InstallBindings()
    {
        Container.BindInstance(_gameplayMediator).AsSingle();
        Container.BindInstance(_defeatPanel).AsSingle();
        Container.BindInstance(new MediatorBootstrap()).AsSingle().NonLazy();
    }
}
