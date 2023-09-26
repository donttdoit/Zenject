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
        Container.Bind<GameplayMediator>().FromInstance(_gameplayMediator);
        Container.Bind<DefeatPanel>().FromInstance(_defeatPanel);
        Container.BindInterfacesAndSelfTo<MediatorBootstrap>().AsSingle();
    }
}
