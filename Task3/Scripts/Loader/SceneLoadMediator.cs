using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Task3
{
    public class SceneLoadMediator
    {
        private SceneLoader _sceneLoader;

        [Inject]
        public void Construct(SceneLoader sceneLoader)
        {
            _sceneLoader = sceneLoader;
        }

        public void GoToGameplayScene(LoadingLevelData loadingLevelData) 
        {
            _sceneLoader.Load(loadingLevelData);
        }

        public void GoToGamemodeScene()
        {
            _sceneLoader.Load(SceneID.GamemodeScene);
        }
    }
}

