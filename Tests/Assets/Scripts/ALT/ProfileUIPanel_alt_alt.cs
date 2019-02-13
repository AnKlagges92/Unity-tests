using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UI_alt_alt;

public class ProfileUIPanel_alt_alt : MonoBehaviour
{
    [SerializeField]
    private LevelUIData _levelData;

    [SerializeField]
    private LevelDisplayUIData _levelDisplayData;

    [SerializeField]
    private LevelDisplayFullUIData _levelDisplayFullData;

    private LevelUIController _levelController;
    private LevelDisplayUIController _levelDisplayController;
    private LevelDisplayFullUIController _levelDisplayFullController;

    private void Start()
    {
        _levelController = new LevelUIController(_levelData, LevelManager.Instance.LevelRaw);
        _levelDisplayController = new LevelDisplayUIController(_levelDisplayData, LevelManager.Instance.LevelRaw, null);
        _levelDisplayFullController = new LevelDisplayFullUIController(_levelDisplayFullData, LevelManager.Instance.LevelRaw, null);
    }
}
