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
        [SerializeField] private AmountUIPart _levelAmount;
        [SerializeField] private ImageUIPart _icon;

        protected override LevelUIController.Parts Parts
        {
            get { return new LevelUIController.Parts(_levelAmount, _icon, null); }
        }
    }
}