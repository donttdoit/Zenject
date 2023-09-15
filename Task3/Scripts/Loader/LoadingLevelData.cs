using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Task3
{
    public class LoadingLevelData
    {
        private IWinCondition _winCondition;

        public LoadingLevelData(IWinCondition winCondition) => _winCondition = winCondition;

        public IWinCondition WinCondition => _winCondition;
    }
}

