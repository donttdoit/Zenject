using System;
using UnityEngine;

public class GameplayMediator : MonoBehaviour, IDisposable
{
    [SerializeField] private DefeatPanel _defeatPanel;
    private Level _level;

    public void Dispose()
    {
        _level.Defeat -= OnLevelDefeat;
    }

    public void Initialize(Level level)
    {
        _level = level;
        _level.Defeat += OnLevelDefeat;
    }

    public void RestartLevel()
    {
        _defeatPanel.Hide();
        _level.Restart();
    }

    private void OnLevelDefeat() => _defeatPanel.Show();

    
}