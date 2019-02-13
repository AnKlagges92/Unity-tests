using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UI_alt_alt
{
    [Serializable]
    public class LevelUIData
    {
        public Text levelText;
    }

    [Serializable]
    public class LevelDisplayUIData : LevelUIData
    {
        public Image levelIcon;
    }

    [Serializable]
    public class LevelDisplayFullUIData : LevelDisplayUIData
    {
        public GameObject highlight;
    }

    public abstract class LevelBaseUIController<T> where T : LevelUIData
    {
        protected T _data;
        protected int _level;

        public int Level
        {
            set
            {
                if (_level != value)
                {
                    _level = value;
                    OnLevelChange(value); //TODO: SafeInvoke
                }
            }
            get { return _level; }
        }

        public LevelBaseUIController(T data, Observable<int> level = null, Sprite icon = null)
        {
            _data = data;
            if (level != null)
            {
                Level = level.Value;
                level.OnValueChange += newLevel => Level = newLevel;
            }
        }

        private void OnLevelChange(int level)
        {
            UpdateLevelText();
        }

        private void UpdateLevelText()
        {
            if (_data.levelText != null)
            {
                _data.levelText.text = _level.ToString();
            }
        }
    }

    public class LevelUIController : LevelBaseUIController<LevelUIData>
    {
        public LevelUIController(LevelUIData data, Observable<int> level = null)
            : base(data, level) { }
    }

    public class LevelDisplayUIController : LevelBaseUIController<LevelDisplayUIData>
    {
        public LevelDisplayUIController(LevelDisplayUIData data, Observable<int> level = null, Sprite icon = null)
            : base(data, level)
        {
            if (_data.levelIcon != null)
            {
                _data.levelIcon.sprite = icon;
            }
        }
    }

    public class LevelDisplayFullUIController : LevelBaseUIController<LevelDisplayFullUIData>
    {
        public LevelDisplayFullUIController(LevelDisplayFullUIData data, Observable<int> level = null, Sprite icon = null)
            : base(data, level) { }

        public void SetActiveHighlight(bool enable)
        {
            if (_data.highlight != null)
            {
                _data.highlight.SetActive(enable);
            }
        }
    }
}
