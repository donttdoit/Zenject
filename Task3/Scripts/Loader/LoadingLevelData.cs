using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Task3
{
    public class LoadingLevelData
    {
        private LevelCondition _levelCondition;

        public LoadingLevelData(LevelCondition levelCondition) => _levelCondition = levelCondition;

        public LevelCondition LevelCondition => _levelCondition;
    }
}

