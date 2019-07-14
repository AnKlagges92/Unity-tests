
namespace UI
{
    /// <summary>
    /// [EXAMPLE]
    /// This is a SPECIFIC controller that handles the concept: LEVEL
    /// UI Controllers have a subclass called Parts which contains ALL POSSIBLE PARTS
    /// UI Controllers should consider that the parts could be NULL.
    /// UI Controllers use injection to receive the parts
    /// [EXAMPLE]
    /// </summary>
    public class LevelUIController
    {
        public class Parts
        {
            public LevelTextsUIPart LevelText;
            public ImageUIPart Icon;
            public GameObjectUIPart Highlight;

            public Parts() { }
        }

        private Observable<int> _level;
        private Observable<int> _maxLevel;

        private Parts _parts;

        #region Getter & Setters

        public int Level
        {
            get { return _level.Value; }
        }

        public int MaxLevel
        {
            get { return _maxLevel.Value; }
        }

        #endregion

        public LevelUIController(Parts parts, Observable<int> level)
        {
            _parts = parts;
            if (level != null)
            {
                _level = level;
                _level.OnValueChange += OnLevelChange;
            }

            UpdateLevelText();
            UpdateLevelHighlight();
        }

        public LevelUIController(Parts parts, Observable<int> level, Observable<int> maxLevel)
        {
            _parts = parts;
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
            UpdateLevelHighlight();
        }

        private void OnLevelChange(int level)
        {
            UpdateLevelText();
            UpdateLevelHighlight();
        }

        private void OnMaxLevelChange(int level)
        {
            UpdateLevelText();
            UpdateLevelHighlight();
        }

        private void UpdateLevelText()
        {
            if (_parts.LevelText != null)
            {
                _parts.LevelText.SetLevelText(Level, MaxLevel);
            }
        }

        private void UpdateLevelHighlight()
        {
            if (_parts.Highlight != null)
            {
                _parts.Highlight.SetActive(Level == MaxLevel);
            }
        }
    }
}
