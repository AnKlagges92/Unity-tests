using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UI_alt;

public class ProfileUIPanel_alt : MonoBehaviour
{
    [SerializeField]
    private LevelTextUIData _levelTextData;

    [SerializeField]
    private LevelDisplayUIData _levelDisplayData;

    [SerializeField]
    private LevelHighlightUIData _levelHighlightData;

    private LevelUIController_alt _levelController;
    private LevelUIController_alt _levelDisplayController;
    private LevelUIController_alt _levelDisplayFullController;

    private void Start()
    {
        _levelController = new LevelUIController_alt(new LevelUIData[] { _levelTextData }, LevelManager.Instance.LevelRaw);
        _levelDisplayController = new LevelUIController_alt(new LevelUIData[] { _levelTextData, _levelDisplayData }, LevelManager.Instance.LevelRaw, null);
        _levelDisplayFullController = new LevelUIController_alt(new LevelUIData[] { _levelTextData, _levelDisplayData, _levelHighlightData }, LevelManager.Instance.LevelRaw, null);
    }
}
