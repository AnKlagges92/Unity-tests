using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UIStyle = UI.LevelUIController.UIStyle;

public class LevelManager : MonoSingleton<LevelManager>
{
    [SerializeField] private UIStyle _style;

    private Observable<int> _level;
    private Observable<int> _maxLevel;

    public UIStyle UIStyle { get { return _style; } }
    public Observable<int> LevelRaw { get { return _level; } }
    public Observable<int> MaxLevelRaw { get { return _maxLevel; } }

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
