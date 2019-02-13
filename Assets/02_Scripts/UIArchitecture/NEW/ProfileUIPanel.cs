using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UI;

/// <summary>
/// [Example]
/// This is a panel that shows the level
/// It contains references to several alternatives
/// [Example]
/// </summary>
public class ProfileUIPanel : MonoBehaviour
{
    [SerializeField] private LevelUIContainer_Text _levelTextContainer;
    [SerializeField] private LevelUIContainer_Icon _levelIconContainer;
    [SerializeField] private LevelUIContainer_Highlight _levelHighlightContainer;
    [SerializeField] private LevelUIContainer_Full _levelFullContainer;

    [Header("Level Parts")]
    [SerializeField] private LevelTextsUIPart _levelText;
    [SerializeField] private GameObjectUIPart _levelHighlight;
    [SerializeField] private ImageUIPart _levelIcon;

    private LevelUIController _levelController;

    private void Start()
    {
        var levelParts = new LevelUIController.Parts(_levelText, null, _levelHighlight);
        _levelController = new LevelUIController(levelParts, LevelManager.Instance.LevelRaw, LevelManager.Instance.MaxLevelRaw);
    }
}
