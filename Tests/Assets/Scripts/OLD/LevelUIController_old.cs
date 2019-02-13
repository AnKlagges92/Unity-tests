using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UI_old
{
    public class LevelUIController_old : MonoBehaviour
    {
        [SerializeField]
        private Text _levelText;

        private int _level;

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

        public void Setup(Observable<int> level = null)
        {
            if (level != null)
            {
                Level = level.Value;
                level.OnValueChange += OnLevelChange;
            }
        }

        private void OnLevelChange(int level)
        {
            UpdateUI();
        }

        private void UpdateUI()
        {
            if (_levelText != null)
            {
                _levelText.text = _level.ToString();
            }
        }
    }
}
