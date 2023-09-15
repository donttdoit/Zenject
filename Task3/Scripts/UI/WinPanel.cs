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
        private Level _level;

        [Inject]
        private void Construct(SceneLoadMediator sceneLoadMediator, Level level)
        {
            _sceneLoadMediator = sceneLoadMediator;
            _level = level;
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
            _sceneLoadMediator.GoToGameplayScene(new LoadingLevelData(_level.GetConditionToWin()));
        }
    }
}

