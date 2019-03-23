using System;
using UnityEngine;

namespace UI
{
    #region Parts

    public enum ELevelFormat
    {
        Level,
        Full
    }

    /// <summary>
    /// [EXAMPLE]
    /// This is a SPECIFIC part
    /// [EXAMPLE]
    /// </summary>
    [Serializable]
    public class LevelTextsUIPart : TextUIPart
    {
        [SerializeField] private ELevelFormat _format = ELevelFormat.Level;

        public void UpdateText(int level, int maxLevel = 0)
        {
            if (_format == ELevelFormat.Level)
            {
                SetText(level);
            }
            else
            {
                SetText(level + " /" + maxLevel);
            }
        }
    }

    #endregion

    /// <summary>
    /// [EXAMPLE]
    /// This is a SPECIFIC controller that handles the concept: LEVEL
    /// [EXAMPLE]
    /// </summary>
    public class LevelUIController
    {
        public partial class Parts
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
            set { _level.Value = value; }
        }

        public int MaxLevel
        {
            get { return _maxLevel.Value; }
            set { _maxLevel.Value = value; }
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
                _parts.LevelText.UpdateText(Level, MaxLevel);
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
