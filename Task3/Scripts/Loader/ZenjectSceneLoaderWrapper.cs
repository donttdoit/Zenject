using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace Task3
{
    public class ZenjectSceneLoaderWrapper
    {
        private readonly ZenjectSceneLoader _loader;

        public ZenjectSceneLoaderWrapper(ZenjectSceneLoader loader) => _loader = loader;

        public void Load(Action<DiContainer> action, int sceneID)
        {
            _loader.LoadScene(sceneID, LoadSceneMode.Single, container => action?.Invoke(container));
        }

    }
}

