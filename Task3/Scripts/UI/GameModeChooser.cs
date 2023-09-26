using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Task3
{
    public class GameModeChooser : MonoBehaviour
    {
        [SerializeField] private Button _allSpheresButton;
        [SerializeField] private Button _redSpheresButton;
        [SerializeField] private Button _greenSpheresButton;
        [SerializeField] private Button _whiteSpheresButton;

        private SceneLoadMediator _sceneLoadMediator;

        private void OnEnable()
        {
            _allSpheresButton.onClick.AddListener(AllspheresRule);
            _redSpheresButton.onClick.AddListener(RedSpheresRule);
            _greenSpheresButton.onClick.AddListener(GreenSpheresRule);
            _whiteSpheresButton.onClick.AddListener(WhiteSpheresRule);
        }


        private void OnDisable()
        {
            _allSpheresButton.onClick.RemoveListener(AllspheresRule);
            _redSpheresButton.onClick.RemoveListener(RedSpheresRule);
            _greenSpheresButton.onClick.RemoveListener(GreenSpheresRule);
            _whiteSpheresButton.onClick.RemoveListener(WhiteSpheresRule);
        }

        [Inject]
        private void Construct(SceneLoadMediator sceneLoadMediator) => _sceneLoadMediator = sceneLoadMediator;

        // Тут надо прокинуть реализацию, а она требует монобеховский параметр, который на другой сцене, как тогда лучше? Прокидывать числа, а на той сцене принимать?
        private void AllspheresRule()
        {
            _sceneLoadMediator.GoToGameplayScene(new LoadingLevelData(LevelCondition.AllSpheresNeedBeDestroyed));
        }

        private void RedSpheresRule()
        {
            _sceneLoadMediator.GoToGameplayScene(new LoadingLevelData(LevelCondition.RedSpheresNeedBeDestroyed));
        }

        private void GreenSpheresRule()
        {
            _sceneLoadMediator.GoToGameplayScene(new LoadingLevelData(LevelCondition.GreenSpheresNeedBeDestroyed));
        }

        private void WhiteSpheresRule()
        {
            _sceneLoadMediator.GoToGameplayScene(new LoadingLevelData(LevelCondition.WhiteSpheresNeedBeDestroyed));
        }
    }
}

