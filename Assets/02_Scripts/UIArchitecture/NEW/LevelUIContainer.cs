using UnityEngine;

namespace UI
{
    /// <summary>
    /// [EXAMPLE]
    /// This is an OPTIONAL BASE container
    /// [EXAMPLE]
    /// </summary>
    public abstract class BaseLevelUIContainer : MonoBehaviour
    {
        [SerializeField] private bool _initOnStart = true;

        protected LevelUIController _controller = null;
        protected bool _initialized = false;

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
                _controller = new LevelUIController(GetParts(), LevelManager.Instance.LevelRaw, LevelManager.Instance.MaxLevelRaw);
            }
        }

        public abstract LevelUIController.Parts GetParts();
    }

    /// <summary>
    /// [EXAMPLE]
    /// This is a container
    /// [EXAMPLE]
    /// </summary>
    public class LevelUIContainer_Text : BaseLevelUIContainer
    {
        [SerializeField] private LevelTextsUIPart _levelText;

        public override LevelUIController.Parts GetParts()
        {
            return new LevelUIController.Parts
            {
                LevelText = _levelText,
                Highlight = null,
                Icon = null
            };
        }
    }

    /// <summary>
    /// [EXAMPLE]
    /// This is a container
    /// [EXAMPLE]
    /// </summary>
    public class LevelUIContainer_Full : BaseLevelUIContainer
    {
        [SerializeField] private LevelTextsUIPart _levelText;
        [SerializeField] private GameObjectUIPart _highlight;
        [SerializeField] private ImageUIPart _icon;

        public override LevelUIController.Parts GetParts()
        {
            return new LevelUIController.Parts
            {
                LevelText = _levelText,
                Highlight = _highlight,
                Icon = _icon
            };
        }
    }

    /// <summary>
    /// [EXAMPLE]
    /// This is a container
    /// [EXAMPLE]
    /// </summary>
    public class LevelUIContainer_Highlight_Text : BaseLevelUIContainer
    {
        [SerializeField] private LevelTextsUIPart _levelText;
        [SerializeField] private GameObjectUIPart _highlight;

        public override LevelUIController.Parts GetParts()
        {
            return new LevelUIController.Parts
            {
                LevelText = _levelText,
                Highlight = _highlight,
                Icon = null
            };
        }
    }

    /// <summary>
    /// [EXAMPLE]
    /// This is a container
    /// [EXAMPLE]
    /// </summary>
    public class LevelUIContainer_Icon_Text : BaseLevelUIContainer
    {
        [SerializeField] private LevelTextsUIPart _levelText;
        [SerializeField] private ImageUIPart _icon;

        public override LevelUIController.Parts GetParts()
        {
            return new LevelUIController.Parts
            {
                LevelText = _levelText,
                Highlight = null,
                Icon = _icon
            };
        }
    }

    /// <summary>
    /// [EXAMPLE]
    /// This is a container
    /// [EXAMPLE]
    /// </summary>
    public class LevelUIContainer_Highlight : BaseLevelUIContainer
    {
        [SerializeField] private GameObjectUIPart _highlight;

        public override LevelUIController.Parts GetParts()
        {
            return new LevelUIController.Parts
            {
                LevelText = null,
                Highlight = _highlight,
                Icon = null
            };
        }
    }

    /// <summary>
    /// [EXAMPLE]
    /// This is a container
    /// [EXAMPLE]
    /// </summary>
    public class LevelUIContainer_Highlight_Icon : BaseLevelUIContainer
    {
        [SerializeField] private ImageUIPart _icon;
        [SerializeField] private GameObjectUIPart _highlight;

        public override LevelUIController.Parts GetParts()
        {
            return new LevelUIController.Parts
            {
                LevelText = null,
                Highlight = _highlight,
                Icon = _icon
            };
        }
    }

    /// <summary>
    /// [EXAMPLE]
    /// This is a container
    /// [EXAMPLE]
    /// </summary>
    public class LevelUIContainer_Icon : BaseLevelUIContainer
    {
        [SerializeField] protected ImageUIPart _icon;

        public override LevelUIController.Parts GetParts()
        {
            return new LevelUIController.Parts
            {
                LevelText = null,
                Highlight = null,
                Icon = _icon
            };
        }
    }
}