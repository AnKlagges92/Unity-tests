using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UI;

/// <summary>
/// THIS IS AN EXAMPLE OF A UI PANEL
/// </summary>
public class ProfileUIPanel : MonoBehaviour
{
    [Header("Level Parts")]
    [SerializeField] private LevelTextsUIPart _levelText;
    [SerializeField] private TextUIPart _otherText;
    [SerializeField] private GameObjectUIPart _levelHighlight;
    [SerializeField] private ImageUIPart _levelIcon;

    private LevelUIController _levelController;

    private void Start()
    {
        var levelParts = new LevelUIController.Parts(_levelText, _otherText, null, _levelHighlight);
        _levelController = new LevelUIController(levelParts, LevelManager.Instance.LevelRaw, LevelManager.Instance.MaxLevelRaw);
    }
}
