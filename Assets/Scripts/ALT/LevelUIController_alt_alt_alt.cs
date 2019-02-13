using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UI_alt_alt_alt
{
    public enum ELevelUIAction
    {
        SetMaxText = 1,
        TOTAL = 2
    }

    #region Parts

    [Serializable]
    public abstract class BaseLevelUIPart : BaseUIPart
    {
        public override bool HandleAction<T>(T action, params object[] parameters)
        {
            if (action.Equals(ELevelUIAction.SetMaxText))
            {
                SetMaxText((string)parameters[0]);
            }
            else
            {
                return base.HandleAction(action, parameters);
            }
            return true;
        }

        public virtual void SetMaxText(string text) { }
    }

    public enum ELevelFormat
    {
        Level,
        Full
    }

    [Serializable]
    public class LevelTextsUIPart : TextUIPart
    {
        public ELevelFormat format;
        /*public Text maxText;

        public override bool CanHandleAction<T>(T action)
        {
            return action.Equals(ELevelUIAction.SetMaxText);
        }

        public override void SetMaxText(string text)
        {
            SetText(this.maxText, text);
        }*/

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

    public class LevelUIController_alt_alt_alt : BaseUIController<ELevelUIAction>
    {
        protected int _level;
        protected int _maxLevel;

        #region Getter & Setters

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

        public int MaxLevel
        {
            set
            {
                if (_maxLevel != value)
                {
                    _maxLevel = value;
                    OnMaxLevelChange(value); //TODO: SafeInvoke
                }
            }
            get { return _maxLevel; }
        }

        #endregion

        protected override int ActionsCount { get { return (int)ELevelUIAction.TOTAL; } }
        protected override int GetActionAsInt(ELevelUIAction action) { return (int)action; }
        protected override ELevelUIAction GetActionByIndex(int index) { return (ELevelUIAction)index; }

        public LevelUIController_alt_alt_alt(Observable<int> level = null, Sprite sprite = null, params BaseUIPart[] parts)
            : base(parts)
        {
            if (level != null)
            {
                Level = level.Value;
                level.OnValueChange += newLevel => Level = newLevel;
            }

            SetImage(sprite);
        }

        private void OnLevelChange(int level)
        {
            SetText(_level.ToString());
        }

        private void OnMaxLevelChange(int level)
        {
            SetMaxText(_level.ToString());
        }

        #region Actions

        public void SetMaxText(string text)
        {
            HandleAction(ELevelUIAction.SetMaxText, text);
        }

        #endregion
    }
}
