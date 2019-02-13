using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UI;

public class ProfileUIPanel : MonoBehaviour
{
    [Header("Level Parts")]
    [SerializeField] private LevelTextsUIPart _levelText;
    [SerializeField] private TextUIPart _otherText;
    [SerializeField] private GameObjectUIPart _levelHighlight;
    [SerializeField] private ImageUIPart _levelIcon;

    private LevelUIController _levelController;
    private LevelUIController _noIconLevelController;

    private void Start()
    {
        var levelParts = new LevelUIController.Parts(_levelText, _otherText, null, _levelHighlight);
        _levelController = new LevelUIController(levelParts, LevelManager.Instance.LevelRaw, LevelManager.Instance.MaxLevelRaw);

        var noIconLevelParts = new LevelUIController.Parts(_levelText, _otherText, _levelHighlight);
        _noIconLevelController = new LevelUIController(noIconLevelParts, LevelManager.Instance.LevelRaw, LevelManager.Instance.MaxLevelRaw);
    }
}
