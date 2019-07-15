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
        public struct UIStyle
        {
            public Sprite sprite;
        }

        public class Parts
        {
            public AmountUIPart LevelAmount;
            public ImageUIPart Icon;
            public GameObjectUIPart Highlight;

            public Parts() { }

            public Parts(AmountUIPart levelAmount, ImageUIPart icon, GameObjectUIPart highlight)
            {
                LevelAmount = levelAmount;
                Icon = icon;
                Highlight = highlight;
            }
        }

        private Observable<int> _level;
        private Observable<int> _maxLevel;

        private Parts _parts;
        private UIStyle _style;

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

        public static LevelUIController GetController(Parts parts)
        {
            var manager = LevelManager.Instance;
            return new LevelUIController(parts, manager.UIStyle, manager.LevelRaw, manager.MaxLevelRaw);
        }

        public LevelUIController(Parts parts, UIStyle style, Observable<int> level)
        {
            if (level != null)
            {
                _level = level;
                _level.OnValueChange += OnLevelChange;
            }

            Init(parts, style);
        }

        public LevelUIController(Parts parts, UIStyle style, Observable<int> level, Observable<int> maxLevel)
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

            Init(parts, style);
        }

        private void Init(Parts parts, UIStyle style)
        {
            _parts = parts;
            _style = style;

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
            if(_parts.Icon != null && _style.sprite != null)
            {
                _parts.Icon.SetSprite(_style.sprite);
            }
        }

        private void UpdateLevelText()
        {
            if (_parts.LevelAmount != null)
            {
                _parts.LevelAmount.SetAmount(Level, MaxLevel);
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
