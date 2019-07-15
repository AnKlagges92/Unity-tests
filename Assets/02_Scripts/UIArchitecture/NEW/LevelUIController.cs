using System;
using UnityEngine;

namespace UI
{
    /// <summary>
    /// [EXAMPLE]
    /// This is a SPECIFIC controller that handles the concept: LEVEL
    /// UI Controllers have a subclass called Parts which contains ALL POSSIBLE UI Parts
    /// UI Controllers should consider that the parts could be NULL.
    /// UI Controllers use injection to receive the parts
    /// [EXAMPLE]
    /// </summary>
    public class LevelUIController
    {
        [Serializable]
        public class Configurations
        {
            public Sprite sprite;
        }

        public class Parts
        {
            public LevelTextsUIPart LevelText;
            public ImageUIPart Icon;
            public GameObjectUIPart Highlight;

            public Parts() { }

            public Parts(LevelTextsUIPart levelText, ImageUIPart icon, GameObjectUIPart highlight)
            {
                LevelText = levelText;
                Icon = icon;
                Highlight = highlight;
            }
        }

        private Observable<int> _level;
        private Observable<int> _maxLevel;

        private Parts _parts;
        private Configurations _configurations;

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

        public LevelUIController(Parts parts, Configurations configs, Observable<int> level)
        {
            if (level != null)
            {
                _level = level;
                _level.OnValueChange += OnLevelChange;
            }

            Init(parts, configs);
        }

        public LevelUIController(Parts parts, Configurations configs, Observable<int> level, Observable<int> maxLevel)
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

            Init(parts, configs);
        }

        private void Init(Parts parts, Configurations configs)
        {
            _parts = parts;
            _configurations = configs;

            UpdateLevelText();
            UpdateIcon();
            UpdateHighlight();
        }

        private void OnLevelChange(int level)
        {
            UpdateLevelText();
            UpdateHighlight();
        }

        private void OnMaxLevelChange(int level)
        {
            UpdateLevelText();
            UpdateHighlight();
        }

        private void UpdateIcon()
        {
            if(_parts.Icon != null && _configurations.sprite != null)
            {
                _parts.Icon.SetSprite(_configurations.sprite);
            }
        }

        private void UpdateLevelText()
        {
            if (_parts.LevelText != null)
            {
                _parts.LevelText.SetLevelText(Level, MaxLevel);
            }
        }

        private void UpdateHighlight()
        {
            if (_parts.Highlight != null)
            {
                _parts.Highlight.SetActive(Level == MaxLevel);
            }
        }
    }
}
