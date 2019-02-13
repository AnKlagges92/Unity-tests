using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UI_old;

public class ProfilePanelUI_old : MonoBehaviour
{
    [SerializeField]
    private LevelUIController_old _levelController;

    [SerializeField]
    private LevelDisplayUIController_old _levelDisplayController;

    [SerializeField]
    private LevelDisplayFullUIController_old _levelDisplayFullController;

    private void Start()
    {
        _levelController.Setup(LevelManager.Instance.LevelRaw);
        _levelDisplayController.Setup(LevelManager.Instance.LevelRaw, null);
        _levelDisplayFullController.Setup(LevelManager.Instance.LevelRaw, null);
    }
}
