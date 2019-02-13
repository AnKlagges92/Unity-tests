using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UI_alt_alt_alt;

public class ProfileUIPanel_alt_alt_alt : MonoBehaviour
{
    [Header("Level Parts")]
    [SerializeField] private TextUIPart _levelText;
    [SerializeField] private LevelTextsUIPart _levelMaxText;
    [SerializeField] private ImageUIPart _levelDisplay;
    [SerializeField] private GameObjectUIPart _levelHighlight;

    private LevelUIController_alt_alt_alt _levelController;

    private void Start()
    {
        _levelController = new LevelUIController_alt_alt_alt(LevelManager.Instance.LevelRaw, null, _levelText, _levelMaxText, _levelDisplay, _levelHighlight);
    }
}
