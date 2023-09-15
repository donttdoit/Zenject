using System;
using UnityEngine;

namespace Task3
{
    public class Level : IDisposable
    {
        private IWinCondition _winCondition;
        private SpheresList _spheresList;
        private WinPanel _winPanel;

        public Level(IWinCondition winCondition, SpheresList spheresList, WinPanel winPanel)
        {
            _winCondition = winCondition;
            _spheresList = spheresList;
            _spheresList.SphereDestroyed += CheckWin;
            _winPanel = winPanel;
        }

        public void Dispose()
        {
            _spheresList.SphereDestroyed -= CheckWin;
        }

        public void SetConditionToWin(IWinCondition winCondition) => _winCondition = winCondition;
        public IWinCondition GetConditionToWin() => _winCondition;

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
