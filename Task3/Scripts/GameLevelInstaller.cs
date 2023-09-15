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

        public override void InstallBindings()
        {
            Container.BindInstance(new Level(new AllSpheresNeededBeDestroyPattern(_spheresList), _spheresList, _winPanel)).AsSingle();
        }
    }
}

