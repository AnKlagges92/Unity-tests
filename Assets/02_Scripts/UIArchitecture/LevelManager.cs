using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Configurations = UI.LevelUIController.Configurations;

public class LevelManager : MonoSingleton<LevelManager>
{
    private Observable<int> _level;
    private Observable<int> _maxLevel;

    [SerializeField] private Configurations _configurations;

    public Observable<int> LevelRaw { get { return _level; } }
    public Observable<int> MaxLevelRaw { get { return _maxLevel; } }
    public Configurations Configurations { get { return _configurations; } }

    public int Level
    {
        set { _level.Value = value; }
        get { return _level.Value; }
    }

    public int MaxLevel
    {
        set { _maxLevel.Value = value; }
        get { return _maxLevel.Value; }
    }

    protected override void OnAwake()
    {
        _level = new Observable<int>(5);
        _maxLevel = new Observable<int>(100);
    }
}
