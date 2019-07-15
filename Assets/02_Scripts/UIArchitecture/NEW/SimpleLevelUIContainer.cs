using UnityEngine;

/// <summary>
/// Containers are built upon necessity
/// </summary>
namespace UI
{
    /// <summary>
    /// --- EXAMPLE ---
    /// This is a SIMPLE version of the container
    /// </summary>
    public class SimpleLevelUIContainer : BaseLevelUIContainer
    {
        [SerializeField] private LevelTextsUIPart _levelText;
        [SerializeField] private ImageUIPart _icon;

        protected override LevelUIController.Parts Parts
        {
            get { return new LevelUIController.Parts(_levelText, _icon, null); }
        }
    }
}