using UnityEngine;

/// <summary>
/// BASE & FULL version can be placed in the SAME SCRIPT. 
/// FULL version needs to be placed on top of the script to be shown on the inspector!
/// Containers are built upon necessity
/// </summary>
namespace UI
{
    /// <summary>
    /// --- EXAMPLE ---
    /// This is the FULL version of the container
    /// </summary>
    public class LevelUIContainer : BaseLevelUIContainer
    {
        [SerializeField] private AmountUIPart _levelAmount;
        [SerializeField] private GameObjectUIPart _highlight;
        [SerializeField] private ImageUIPart _icon;

        protected override LevelUIController.Parts Parts
        {
            get { return new LevelUIController.Parts(_levelAmount, _icon, _highlight); }
        }
    }

    /// <summary>
    /// --- EXAMPLE ---
    /// This is the BASE version of the container
    /// </summary>
    public abstract class BaseLevelUIContainer : MonoBehaviour
    {
        [SerializeField] private bool _initOnStart = true;

        protected LevelUIController _controller = null;
        protected bool _initialized = false;

        protected abstract LevelUIController.Parts Parts { get; }

        protected void Start()
        {
            if (_initOnStart)
            {
                Init();
            }
        }

        public void Init()
        {
            if (!_initialized)
            {
                _initialized = true;
                _controller = LevelUIController.GetController(Parts);
            }
        }
    }
}