using UnityEngine;
using UI;

/// <summary>
/// [Example]
/// This is a panel that shows the level
/// It contains references to SEVERAL ALTERNATIVES
/// [Example]
/// </summary>
public class ProfileUIPanel : MonoBehaviour
{
    /// <summary>
    /// Alternative A: Containers
    /// The class with the desired components must be used (_Text, _Icon, _Highlight, etc..)
    /// PROS: This alternative is useful for PREFABS
    /// PROS: Additional methods can be added to manage multiple parts
    /// CONS: It require a new class for each variation
    /// </summary>
    [Header("Level Containers")]
    [SerializeField] private SimpleLevelUIContainer _simpleLevelContainer;
    [SerializeField] private LevelUIContainer _fullLevelContainer;

    /// <summary>
    /// Alternative B: Parts
    /// The required parts needs to be referenced(Image, GameoObject, etc..)
    /// PROS: Only the required parts will be references (No need to serialize empty references)
    /// CONS: 
    /// </summary>
    [Header("Level Parts")]
    [SerializeField] private AmountUIPart _levelAmount;
    [SerializeField] private GameObjectUIPart _levelHighlight;
    [SerializeField] private ImageUIPart _levelIcon;

    private LevelUIController _levelController;

    private void Start()
    {
        var levelParts = new LevelUIController.Parts(_levelAmount, _levelIcon, _levelHighlight);
        _levelController = LevelUIController.GetController(levelParts);
    } 
}
