using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UI_alt
{
    [Serializable]
    public class LevelUIData
    {
        public virtual bool Handle_SetText(string text)
        {
            return false;
        }

        public virtual bool Handle_SetIcon(Sprite icon)
        {
            return false;
        }

        public virtual bool Handle_SetActiveHighlight(bool enable)
        {
            return false;
        }
    }

    [Serializable]
    public class LevelTextUIData : LevelUIData
    {
        public Text levelText;

        public override bool Handle_SetText(string text)
        {
            if (levelText != null)
            {
                levelText.text = text;
            }
            return true;
        }
    }

    [Serializable]
    public class LevelDisplayUIData : LevelUIData
    {
        public Image levelIcon;

        public override bool Handle_SetIcon(Sprite sprite)
        {
            if (levelIcon != null)
            {
                levelIcon.sprite = sprite;
            }
            return true;
        }
    }

    [Serializable]
    public class LevelHighlightUIData : LevelUIData
    {
        public GameObject highlight;

        public override bool Handle_SetActiveHighlight(bool enable)
        {
            if (highlight != null)
            {
                highlight.SetActive(enable);
            }
            return true;
        }
    }


    public class LevelUIController_alt
    {
        private LevelUIData[] _dataParts;
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

        public LevelUIController_alt(LevelUIData[] dataParts, Observable<int> level = null, Sprite icon = null)
        {
            _dataParts = dataParts;
            if (level != null)
            {
                Level = level.Value;
                level.OnValueChange += newLevel => Level = newLevel;
            }

            SetIcon(icon);
        }

        private void OnLevelChange(int level)
        {
            SetText(_level.ToString());
        }

        public void SetIcon(Sprite icon)
        {
            if (icon == null) return;

            foreach (var part in _dataParts)
            {
                if (part.Handle_SetIcon(icon))
                {
                    return; //TODO: Reduce counter
                }
            }
        }

        public void SetText(string text)
        {
            if (string.IsNullOrEmpty(text)) return;

            foreach (var part in _dataParts)
            {
                if (part.Handle_SetText(text))
                {
                    return; //TODO: Reduce counter
                }
            }
        }

        public void SetActiveHighlight(bool enable)
        {
            foreach (var part in _dataParts)
            {
                if (part.Handle_SetActiveHighlight(enable))
                {
                    return; //TODO: Reduce counter
                }
            }
        }
    }
}
