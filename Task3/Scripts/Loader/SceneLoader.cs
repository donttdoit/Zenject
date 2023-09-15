using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Task3
{
    public class SceneLoader
    {
        private ZenjectSceneLoaderWrapper _loader;

        public SceneLoader(ZenjectSceneLoaderWrapper loader) => _loader = loader;

        public void Load(LoadingLevelData levelLoadingData)
        {
            _loader.Load(container => container.BindInstance(levelLoadingData).WhenInjectedInto<GameplaySceneInstaller>(), 
                         (int)SceneID.GameplayScene);
        }

        public void Load(SceneID sceneID)
        {
            if (sceneID == SceneID.GameplayScene)
                throw new ArgumentException($"{sceneID} cannot be started without configuration");

            _loader.Load(null, (int)sceneID);
        }
    }
}

