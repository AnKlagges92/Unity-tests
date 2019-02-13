using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UI_old
{
    public enum ELevelFormat
    {
        Level,
        Full
    }

    public class LevelUIController_old : MonoBehaviour
    {
        [SerializeField] private Text _levelText;

        [SerializeField] private ELevelFormat format = ELevelFormat.Level;

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

        public void Setup(Observable<int> level)
        {
            if (level != null)
            {
                _level = level;
                _level.OnValueChange += OnLevelChange;
            }

            UpdateLevelText();
        }

        public void Setup(Observable<int> level, Observable<int> maxLevel)
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
            if (_levelText != null)
            {
                if (format == ELevelFormat.Level)
                {
                    _levelText.text = Level.ToString();
                }
                else
                {
                    _levelText.text = Level + "/" + MaxLevel;
                }
            }
        }
    }
}
