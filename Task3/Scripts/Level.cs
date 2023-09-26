using System;
using UnityEngine;
using Zenject;

namespace Task3
{
    public class Level : IDisposable, IInitializable
    {
        private LoadingLevelData _loadingLevelData;
        private SpheresList _spheresList;
        private WinPanel _winPanel;
        private IWinCondition _winCondition;

        [Inject]
        private void Construct(LoadingLevelData loadingLevelData, SpheresList spheresList, WinPanel winPanel)
        {
            _loadingLevelData = loadingLevelData;
            _spheresList = spheresList;
            _spheresList.SphereDestroyed += CheckWin;
            _winPanel = winPanel;
        }

        public void Initialize()
        {
            switch (_loadingLevelData.LevelCondition)
            {
                case LevelCondition.GreenSpheresNeedBeDestroyed:
                    _winCondition = new OnlyOneColorWinPattern(_spheresList, SphereType.GreenSphere);
                    break;

                case LevelCondition.RedSpheresNeedBeDestroyed:
                    _winCondition = new OnlyOneColorWinPattern(_spheresList, SphereType.RedSphere);
                    break;

                case LevelCondition.WhiteSpheresNeedBeDestroyed:
                    _winCondition = new OnlyOneColorWinPattern(_spheresList, SphereType.WhiteSphere);
                    break;

                case LevelCondition.AllSpheresNeedBeDestroyed:
                default:
                    _winCondition = new AllSpheresNeededBeDestroyPattern(_spheresList);
                    break;
            }
        }

        public void Dispose()
        {
            _spheresList.SphereDestroyed -= CheckWin;
        }


        private void CheckWin()
        {
            if (_winCondition.CheckWinResult())
            {
                _winPanel.gameObject.SetActive(true);
            }
            else
            {
                _winPanel.gameObject.SetActive(false);
            }
        }

        
    }
}
