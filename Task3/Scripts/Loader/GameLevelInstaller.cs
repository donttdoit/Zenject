using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Task3
{
    public class GameLevelInstaller : MonoInstaller
    {
        [SerializeField] private SpheresList _spheresList;
        [SerializeField] private WinPanel _winPanel;
        private LoadingLevelData _loadingLevelData;

        public override void InstallBindings()
        {
            BindLevelInfo();
        }

        [Inject]
        private void Construct(LoadingLevelData loadingLevelData)
        {
            _loadingLevelData = loadingLevelData;
        }

        private void BindLevelInfo()
        {
            Container.Bind<LoadingLevelData>().FromInstance(_loadingLevelData);
            Container.BindInstance(_spheresList).AsSingle();
            Container.BindInstance(_winPanel).AsSingle();
            Container.BindInterfacesAndSelfTo<Level>().AsSingle();
        }

        
    }
}

