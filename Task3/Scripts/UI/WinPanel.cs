using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Task3
{
    public class WinPanel : MonoBehaviour
    {
        [SerializeField] private LevelButton _restartButton;
        [SerializeField] private LevelButton _mainMenuButton;

        private SceneLoadMediator _sceneLoadMediator;
        private LoadingLevelData _levelData;

        [Inject]
        private void Construct(SceneLoadMediator sceneLoadMediator, LoadingLevelData levelData)
        {
            _sceneLoadMediator = sceneLoadMediator;
            _levelData = levelData;
        }

        private void OnEnable()
        {
            _restartButton.Click += RestartLevel;
            _mainMenuButton.Click += GoToMainMenu;
        }

        private void OnDisable()
        {
            _restartButton.Click -= RestartLevel;
            _mainMenuButton.Click -= GoToMainMenu;
        }

        public void GoToMainMenu()
        {
            _sceneLoadMediator.GoToGamemodeScene();
        }

        public void RestartLevel()
        {
            _sceneLoadMediator.GoToGameplayScene(new LoadingLevelData(_levelData.LevelCondition));
        }
    }
}

