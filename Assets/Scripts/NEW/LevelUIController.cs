using System;

namespace UI
{
    #region Parts

    public enum ELevelFormat
    {
        Level,
        Full
    }

    /// <summary>
    /// THIS IS AN EXAMPLE OF A SPECIFIC UI PART
    /// </summary>
    [Serializable]
    public class LevelTextsUIPart : TextUIPart
    {
        public ELevelFormat format = ELevelFormat.Level;

        public void UpdateText(int level, int maxLevel = 0)
        {
            if (format == ELevelFormat.Level)
            {
                SetText(level);
            }
            else
            {
                SetText(level + "-" + maxLevel);
            }
        }
    }

    #endregion

    /// <summary>
    /// THIS IS AN EXAMPLE OF A SPECIFIC UI CONTROLLER
    /// </summary>
    public partial class LevelUIController : BaseUIController<LevelUIController.Parts>
    {
        public partial class Parts : BaseParts
        {
            public LevelTextsUIPart LevelText;
            public ImageUIPart Icon;
            public GameObjectUIPart Highlight;

            public Parts(LevelTextsUIPart levelText, ImageUIPart icon, GameObjectUIPart highlight = null)
            {
                LevelText = NullCheck(levelText);
                Icon = NullCheck(icon);
                Highlight = highlight;
            }
        }

        private Observable<int> _level;
        private Observable<int> _maxLevel;

        #region Getter & Setters

        public int Level
        {
            get { return _level.Value; }
            set { _level.Value = value; }
        }

        public int MaxLevel
        {
            get { return _maxLevel.Value; }
            set { _maxLevel.Value = value; }
        }

        #endregion

        public LevelUIController(Parts parts, Observable<int> level)
            : base(parts)
        {
            if (level != null)
            {
                _level = level;
                _level.OnValueChange += OnLevelChange;
            }

            UpdateLevelText();
        }

        public LevelUIController(Parts parts, Observable<int> level, Observable<int> maxLevel)
            : base(parts)
        {
            if (level != null)
            {
                _level = level;
                _level.OnValueChange += OnLevelChange;
            }

            if (maxLevel != null)
            {
                _maxLevel = maxLevel;
                _maxLevel.OnValueChange += OnMaxLevelChange;
            }

            UpdateLevelText();
        }

        private void OnLevelChange(int level)
        {
            UpdateLevelText();
        }

        private void OnMaxLevelChange(int level)
        {
            UpdateLevelText();
        }

        private void UpdateLevelText()
        {
            if (_parts.LevelText != null)
            {
                _parts.LevelText.UpdateText(Level, MaxLevel);
            }
        }
    }
}
