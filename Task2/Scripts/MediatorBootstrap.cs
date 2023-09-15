using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class MediatorBootstrap : IInitializable, ITickable
{
    private GameplayMediator _gameplayMediator;
    private DefeatPanel _defeatPanel;

    private Level _level;

    [Inject]
    private void Construct(GameplayMediator gameplayMediator, DefeatPanel defeatPanel)
    {
        _gameplayMediator = gameplayMediator;
        _defeatPanel = defeatPanel;
        Initialize();
    }

    public void Initialize()
    {
        _level = new Level();

        _gameplayMediator.Initialize(_level);
        _defeatPanel.Initialize(_gameplayMediator);

        _level.Start();
        Debug.Log("YEs");
    }

    public void Tick()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            _level.OnDefeat();
    }
}
