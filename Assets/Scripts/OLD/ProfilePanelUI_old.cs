using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UI_old;

public class ProfilePanelUI_old : MonoBehaviour
{
    [SerializeField]
    private LevelUIController_old _levelController;

    [SerializeField]
    private LevelUIController_Highlight_old _levelHighlightController;

    [SerializeField]
    private LevelUIController_Icon_old _levelIconController;

    [SerializeField]
    private LevelUIController_Full_old _levelFullController;

    private void Start()
    {
        _levelController.Setup(LevelManager.Instance.LevelRaw);
        _levelHighlightController.Setup(LevelManager.Instance.LevelRaw);
        _levelIconController.Setup(LevelManager.Instance.LevelRaw, null);
        _levelFullController.Setup(LevelManager.Instance.LevelRaw, null);
    }
}
